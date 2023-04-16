using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Sample_Web_App.Features.Authors.CQRS;

namespace Sample_Web_App.Features.Authors;

[Route("api/[controller]")]
[ApiController]
public class AuthorsController : ControllerBase
{
    private readonly IMediator _mediator;
    public AuthorsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetAllAuthors.AuthorResult>>> GetAuthorsAsync()
    {
        var result = await _mediator.Send(new GetAllAuthors.GetAuthorsQuery());

        if (result == null)
            return NotFound();

        return Ok(result);
    }
}