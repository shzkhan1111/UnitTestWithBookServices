using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitTestWithBookServices.API.Models;
using UnitTestWithBookServices.API.Services;

namespace UnitTestWithBookServices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _svc;
        public BooksController(IBookService svc) => _svc = svc;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Book book)
        {
            var created = await _svc.AddBookAsync(book);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _svc.GetAllAsync());
        
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _svc.GetByIdAsync(id);
            if (book is null) return NotFound();
            return Ok(book);
        }
        [HttpPost("{id}/cover")]
        [Authorize]
        public async Task<IActionResult> UploadCover(int id, IFormFile cover)
        {
            if (cover == null || cover.Length == 0) return BadRequest("No file");
            using var ms = new MemoryStream();
            await cover.CopyToAsync(ms);
            return Ok(new { Size = ms.Length, FileName = cover.FileName });
        }
    }
}
