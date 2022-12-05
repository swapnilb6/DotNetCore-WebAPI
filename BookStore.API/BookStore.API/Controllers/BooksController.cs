using BookStore.API.Models;
using BookStore.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository )
        {
          _bookRepository = bookRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooksAsync();

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookbyID([FromRoute]int id)
        {
            var book = await _bookRepository.GetBookbyIDAsync(id);

            if(book==null)
            {
                return NotFound();
            }

            return Ok(book);
        }


        [HttpPost("")]
        public async Task<IActionResult> AddNewBook([FromBody] BookModel book)
        {
            var id = await _bookRepository.AddBookAsync(book);

            return CreatedAtAction(nameof(GetBookbyID), new { id =id, Controller = "Books"},id); 
        }

        [HttpPut("{bookid}")]
        public async Task<IActionResult> UpdateBookAsync([FromBody] BookModel book,[FromRoute] int bookid)
        {
            var id = await _bookRepository.UpdateBookAsync(bookid,book);

            return Ok();
        }

        [HttpPatch("{bookid}")]
        public async Task<IActionResult> UpdateBookPatchAsync([FromBody] JsonPatchDocument book, [FromRoute] int bookid)
        {
            var id = await _bookRepository.UpdateBookPatchAsync(bookid, book);

            return Ok(); 
        }


        [HttpDelete("{bookid}")]
        public async Task<IActionResult> DeleteBookbyIDAsync([FromRoute] int bookid)
        {
            var id = await _bookRepository.DeleteBookbyIDAsync(bookid);

            return Ok();
        }
    }
}
