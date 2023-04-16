using MediatR;
using Sample_Web_App.Features.StoryBooks.Exceptions;
using Sample_Web_App.ServiceManager;

namespace Sample_Web_App.Features.StoryBooks.CQRS;

public class RemoveStoryBookFromAuthor
{
    public class RemoveStoryBookCommand : IRequest<Unit>
    {
        public int AuthorId { get; set; }
        public int StoryBookId { get; set; }
    }

    public class Handler : IRequestHandler<RemoveStoryBookCommand, Unit>
    {
        private readonly IServiceManager _serviceManager;

        public Handler(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<Unit> Handle(RemoveStoryBookCommand request, CancellationToken cancellationToken)
        {
            var Author = await _serviceManager.Author.GetAuthorByIdAsync(request.AuthorId);

            if (Author == null)
                throw new NoAuthorExistsException(request.AuthorId);

            var StoryBook = await _serviceManager.StoryBook.GetStoryBookAsync(request.AuthorId, request.StoryBookId);

            if (StoryBook == null)
                throw new NoStoryBookExistsException(request.AuthorId, request.StoryBookId);

            _serviceManager.StoryBook.DeleteStoryBook(StoryBook);

            await _serviceManager.SaveAsync();

            return Unit.Value;
        }
    }
}