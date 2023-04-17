using AutoMapper;
using MediatR;
using Sample_Web_App.Features.StoryBooks.Exceptions;
using Sample_Web_App.ServiceManager;

namespace Sample_Web_App.Features.Authors.CQRS;

public class GetAuthorById
{
    public class GetAuthorByIdQuery : IRequest<AuthorResult>
    {
        public readonly int _authorId;

        public GetAuthorByIdQuery(int authorId)
        {        
            _authorId = authorId;
        }
    }

    public class AuthorResult
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
    }

    //Handler
    public class Handler : IRequestHandler<GetAuthorByIdQuery, AuthorResult>
    {
        private readonly IServiceManager _serviceManager;
        private readonly IMapper _mapper;

        public Handler(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }

        public async Task<AuthorResult> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var author = await _serviceManager.Author.GetAuthorByIdAsync(request._authorId);
            
            if (author.IsT1)
                throw new NoAuthorExistsException(request._authorId);
            
            var results = _mapper.Map<AuthorResult>(author);
            return results;
        }
    }
}