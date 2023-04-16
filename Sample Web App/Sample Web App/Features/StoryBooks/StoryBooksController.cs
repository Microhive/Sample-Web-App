using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Sample_Web_App.Features.StoryBooks;

[Route("api/[controller]")]
[ApiController]
public class StoryBooksController
{
    private readonly IMediator _mediator;
    public StoryBooksController(IMediator mediator)
    {
        _mediator = mediator;
    }
}