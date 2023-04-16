using AutoMapper;
using MediatR;
using Sample_Web_App.Features.StoryBooks.Exceptions;
using Sample_Web_App.ServiceManager;

namespace Sample_Web_App.Features.StoryBooks.CQRS;

public class GetAllStoryBooksForAuthor
{
    public class GetStoryBooksQuery : IRequest<IEnumerable<StoryBookResult>>
    {
        public int AuthorId { get; set; }
    }

    public class StoryBookResult
    {
        public int StoryBookId { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
    }

    public class Handler : IRequestHandler<GetStoryBooksQuery, IEnumerable<StoryBookResult>>
    {
        private readonly IServiceManager _serviceManager;
        private readonly IMapper _mapper;

        public Handler(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StoryBookResult>> Handle(GetStoryBooksQuery request, CancellationToken cancellationToken)
        {
            var Author = await _serviceManager.Author.GetAuthorByIdAsync(request.AuthorId);

            if (Author == null)
                throw new NoAuthorExistsException(request.AuthorId);

            var StoryBooks = await _serviceManager.StoryBook.GetAllStoryBooksAsync(Author.AuthorId);

            var result = _mapper.Map<IEnumerable<StoryBookResult>>(StoryBooks);

            return result;
        }
    }
}