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

            if (author.IsT1)
                throw new NoAuthorExistsException(request.AuthorId);

            var storyBook = await _serviceManager.StoryBook.GetStoryBookAsync(request.AuthorId, request.StoryBookId);

            if (storyBook.IsT1)
                throw new NoAuthorExistsException(request.AuthorId);
            
            if (storyBook.IsT2)
                throw new NoStoryBookExistsException(request.AuthorId, request.StoryBookId);

            storyBook.AsT0.Title = request.Title;
            storyBook.AsT0.AuthorId = request.AuthorId;

            await _serviceManager.SaveAsync();

            return Unit.Value;
        }
    }
}