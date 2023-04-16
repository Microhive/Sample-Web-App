using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sample_Web_App.Features.StoryBooks.CQRS;
using Sample_Web_App.Features.StoryBooks.Exceptions;

namespace Sample_Web_App.Features.StoryBooks;

[Route("api/[controller]")]
[ApiController]
public class StoryBooksController : ControllerBase
{
    private readonly IMediator _mediator;
    public StoryBooksController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet(Name = "GetStoryBooksForAuthor")]
        public async Task<ActionResult<IEnumerable<AddStoryBookToAuthor.StoryBookResult>>> GetStoryBooksForAuthor(int authorId)
        {
            try
            {
                var query = new GetAllStoryBooksForAuthor.GetStoryBooksQuery
                {
                    AuthorId = authorId
                };

                var result = await _mediator.Send(query);

                return Ok(result);
            }
            catch (NoAuthorExistsException ex)
            {
                return Conflict(new
                {
                    ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddStoryBook(AddStoryBookToAuthor.AddStoryBookCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);

                return CreatedAtRoute("GetStoryBooksForAuthor", new { authorId = result.AuthorId }, result);
            }
            catch (NoAuthorExistsException ex)
            {
                return Conflict(new
                {
                    ex.Message
                });
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateStoryBookForAuthor(int authorId, UpdateStoryBookForAuthor.UpdateStoryBookCommand command)
        {
            try
            {
                command.AuthorId = authorId;

                var result = await _mediator.Send(command);

                return NoContent();
            }
            catch (NoAuthorExistsException ex)
            {
                return Conflict(new
                {
                    ex.Message
                });
            }
            catch (NoStoryBookExistsException ex)
            {
                return Conflict(new
                {
                    ex.Message,
                    ex.AuthorId,
                    ex.StoryBookId
                });
            }
        }

        [HttpDelete]
        public async Task<ActionResult> RemoveStoryBookFromAuthor(int authorId, RemoveStoryBookFromAuthor.RemoveStoryBookCommand command)
        {
            try
            {
                command.AuthorId = authorId;

                await _mediator.Send(command);

                return NoContent();
            }
            catch (NoAuthorExistsException ex)
            {
                return Conflict(new
                {
                    ex.Message
                });
            }
            catch (NoStoryBookExistsException ex)
            {
                return Conflict(new
                {
                    ex.Message,
                    ex.AuthorId,
                    ex.StoryBookId
                });
            }
        }
}