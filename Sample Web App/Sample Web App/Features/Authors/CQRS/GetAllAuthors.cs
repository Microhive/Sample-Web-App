using AutoMapper;
using MediatR;
using Sample_Web_App.ServiceManager;

namespace Sample_Web_App.Features.Authors.CQRS;

public class GetAllAuthors
{
    public class GetAuthorsQuery : IRequest<IEnumerable<AuthorResult>> { }

    public class AuthorResult
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
    }

    //Handler
    public class Handler : IRequestHandler<GetAuthorsQuery, IEnumerable<AuthorResult>>
    {
        private readonly IServiceManager _serviceManager;
        private readonly IMapper _mapper;

        public Handler(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AuthorResult>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
        {
            var authors = await _serviceManager.Author.GetAllAuthorsAsync();
            var results = _mapper.Map<IEnumerable<AuthorResult>>(authors.AsT0);
            return results;
        }
    }
}