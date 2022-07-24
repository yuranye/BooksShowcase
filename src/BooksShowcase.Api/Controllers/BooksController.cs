using AutoMapper;
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
    private readonly IMapper _mapper;

    public BooksController(ILogger<BooksController> logger, IMediator mediator, IMapper mapper)
    {
        _logger = logger;
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet(BooksApiRoutes.Books)]
    public async Task<ActionResult<BooksPagedView>> Get([FromQuery] string? nameFilter, [FromQuery] int? pageSize, [FromQuery] string? pageToken)
    {
        var response = await _mediator.Send(new GetBooksRequest
        {
            NameFilter = nameFilter,
            PageSize = pageSize,
            PageToken = pageToken,
        });

        return Ok(new BooksPagedView
        {
            CurrentPageToken = response.CurrentPageToken,
            NextPageToken = response.NextPageToken,
            Data = response.Data.Select(b => _mapper.Map<BookView>(b)),
        });
    }

    [HttpGet(BooksApiRoutes.Books + "/{bookUuid:guid}")]
    public async Task<ActionResult<BooksPagedView>> Get([FromRoute] Guid bookUuid)
    {
        var book = await _mediator.Send(new GetBookRequest
        {
            Uuid = bookUuid,
        });

        return Ok(_mapper.Map<BookView>(book));
    }

    [HttpPost(BooksApiRoutes.Books)]
    public async Task<ActionResult<BookView>> Create(CreateBookRequest request)
    {
        var book = await _mediator.Send(request);

        return Ok(_mapper.Map<BookView>(book));
    }

    [HttpPut(BooksApiRoutes.Books)]
    public async Task<ActionResult<BookView>> Update(UpdateBookRequest request)
    {
        var book = await _mediator.Send(request);

        return Ok(_mapper.Map<BookView>(book));
    }

    [HttpDelete(BooksApiRoutes.Books + "/{bookUuid:guid}")]
    public async Task<ActionResult<BookView>> Delete([FromRoute] Guid bookUuid)
    {
        await _mediator.Send(new DeleteBookRequest { BookUuid = bookUuid });

        return NoContent();
    }
}