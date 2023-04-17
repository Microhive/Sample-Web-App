using AutoMapper;
using MediatR;
using Sample_Web_App.Domain;
using Sample_Web_App.Features.StoryBooks.Exceptions;
using Sample_Web_App.ServiceManager;

namespace Sample_Web_App.Features.StoryBooks.CQRS;

public class AddStoryBookToAuthor
{
    //Input
    public class AddStoryBookCommand : IRequest<StoryBookResult>
    {
        public string Title { get; set; }
        public int AuthorId { get; set; }
    }

    //Output
    public class StoryBookResult
    {
        public int StoryBookId { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
    }

    //Handler
    public class Handler : IRequestHandler<AddStoryBookCommand, StoryBookResult>
    {
        private readonly IServiceManager _serviceManager;
        private readonly IMapper _mapper;

        public Handler(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }

        public async Task<StoryBookResult> Handle(AddStoryBookCommand request, CancellationToken cancellationToken)
        {
            var author = await _serviceManager.Author.GetAuthorByIdAsync(request.AuthorId);

            if (author.IsT1)
                throw new NoAuthorExistsException(request.AuthorId);

            var storyBook = new StoryBook()
            {
                Title = request.Title,
                AuthorId = request.AuthorId
            };

            _serviceManager.StoryBook.AddStoryBookToAuthor(request.AuthorId, storyBook);

            await _serviceManager.SaveAsync();

            var result = _mapper.Map<StoryBookResult>(storyBook);

            return result;
        }
    }
}