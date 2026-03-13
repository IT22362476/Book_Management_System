using AutoMapper;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/books")]
public class BooksController : ControllerBase
{
    private readonly IBookService _service;
    private readonly IMapper _mapper;

    public BooksController(IBookService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
    {
        var books = await _service.GetAllAsync();

        return Ok(_mapper.Map<IEnumerable<BookDto>>(books));
    }

    [HttpPost]
    public async Task<ActionResult<BookDto>> Create(CreateBookDto dto)
    {
        var book = _mapper.Map<Book>(dto);

        var created = await _service.AddAsync(book);

        return Ok(_mapper.Map<BookDto>(created));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateBookDto dto)
    {
        var book = _mapper.Map<Book>(dto);

        var updated = await _service.UpdateAsync(id, book);

        if (updated == null)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _service.DeleteAsync(id);

        if (!success)
            return NotFound();

        return NoContent();
    }
}