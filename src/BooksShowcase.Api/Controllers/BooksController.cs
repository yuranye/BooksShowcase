using BooksShowcase.Api.ExceptionFilters;
using BooksShowcase.Api.Views;
using BooksShowcase.Core.Handlers.Create;
using BooksShowcase.Core.Handlers.Delete;
using BooksShowcase.Core.Handlers.Get;
using BooksShowcase.Core.Handlers.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BooksShowcase.Api.Controllers;

[ApiController]
[TypeFilter(typeof(NotFoundExceptionFilter))]
public class BooksController : ControllerBase
{
    private readonly ILogger<BooksController> _logger;
    private readonly IMediator _mediator;

    public BooksController(ILogger<BooksController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet(BooksApiRoutes.Books)]
    public async Task<ActionResult<BooksPagedView>> Get([FromQuery] string? nameFilter)
    {
        var response = await _mediator.Send(new GetBooksRequest
        {
            NameFilter = nameFilter,
        });

        return Ok(new BooksPagedView
        {
            PageIndex = response.PageIndex,
            TotalPages = response.TotalPages,
            TotalRecords = response.TotalRecords,
            Data = response.Data.Select(b => new BookView
            {
                Name = b.Name,
                Uuid = b.Uuid,
            }),
        });
    }

    [HttpGet(BooksApiRoutes.Books + "/{bookUuid:guid}")]
    public async Task<ActionResult<BooksPagedView>> Get([FromRoute] Guid bookUuid)
    {
        var book = await _mediator.Send(new GetBookRequest
        {
            BookUuid = bookUuid,
        });

        return Ok(new BookView
        {
            Name = book.Name,
            Uuid = book.Uuid,
        });
    }

    [HttpPost(BooksApiRoutes.Books)]
    public async Task<ActionResult<BookView>> Create(CreateBookRequest request)
    {
        var book = await _mediator.Send(request);

        return Ok(new BookView
        {
            Name = book.Name,
            Uuid = book.Uuid,
        });
    }

    [HttpPut(BooksApiRoutes.Books)]
    public async Task<ActionResult<BookView>> Update(UpdateBookRequest request)
    {
        var book = await _mediator.Send(request);

        return Ok(new BookView
        {
            Name = book.Name,
            Uuid = book.Uuid,
        });
    }

    [HttpDelete(BooksApiRoutes.Books + "/{bookUuid:guid}")]
    public async Task<ActionResult<BookView>> Delete([FromRoute] Guid bookUuid)
    {
        await _mediator.Send(new DeleteBookRequest { BookUuid = bookUuid });

        return NoContent();
    }
}