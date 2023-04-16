using AutoMapper;
using MediatR;
using Sample_Web_App.Features.StoryBooks.Exceptions;
using Sample_Web_App.ServiceManager;

namespace Sample_Web_App.Features.StoryBooks.CQRS;

public class UpdateStoryBookForAuthor
{
    public class UpdateStoryBookCommand : IRequest<Unit>
    {
        public int StoryBookId { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
    }

    public class UpdateStoryBookResult
    {
        public int StoryBookId { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
    }

    public class Handler : IRequestHandler<UpdateStoryBookCommand>
    {
        private readonly IServiceManager _serviceManager;
        private readonly IMapper _mapper;

        public Handler(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }
        
        public async Task<Unit> Handle(UpdateStoryBookCommand request, CancellationToken cancellationToken)
        {
            var author = await _serviceManager.Author.GetAuthorByIdAsync(request.AuthorId);

            if (author == null)
                throw new NoAuthorExistsException(request.AuthorId);

            var storyBook = await _serviceManager.StoryBook.GetStoryBookAsync(request.AuthorId, request.StoryBookId);

            if (storyBook == null)
                throw new NoStoryBookExistsException(request.AuthorId, request.StoryBookId);

            storyBook.Title = request.Title;
            storyBook.AuthorId = request.AuthorId;

            await _serviceManager.SaveAsync();

            return Unit.Value;
        }
    }
}