using AutoMapper;
using BookStore.API.DataContext;
using BookStore.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public BookRepository(BookStoreContext context,IMapper mapper)
        {
            this._context = context;
            _mapper = mapper;
        }
        public async Task<List<BookModel>>  GetAllBooksAsync()
        { 
    
        //    var AllBooks = await _context.Books.Select(x=> new BookModel()
        //    {
        //        ID = x.ID,
        //        Name = x.Name,
        //        Description = x.Description
        //    }).ToListAsync();


        var AllBooks = await _context.Books.ToListAsync();

            return _mapper.Map<List<BookModel>>(AllBooks);
        }

        public async Task<BookModel> GetBookbyIDAsync(int bookid)
        {
            //var AllBooks = await _context.Books.Where(x=> x.ID== bookid).Select(x=> new BookModel()
            //{
            //    ID = x.ID,
            //    Name = x.Name,
            //    Description = x.Description
            //}).FirstOrDefaultAsync();


            //return AllBooks;

            // With Auto Mapper
            var book = await _context.Books.FindAsync(bookid);
            return _mapper.Map<BookModel>(book);
        }

        public async Task<int> AddBookAsync(BookModel bookModel)
        {
            var book = new Books()
            {
                Name = bookModel.Name,
                Description = bookModel.Description
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return book.ID;
        }

        public async Task<int> UpdateBookAsync(int bookid, BookModel bookModel)
        {

            // Two  DB Call

            //var book = await _context.Books.FindAsync(bookid);

            //if(book != null)
            //{

            //    book.Name = bookModel.Name;
            //    book.Description = bookModel.Description;

            //    await _context.SaveChangesAsync();
            //}


            // in single DB Call

            var book = new Books()
            {
                ID = bookid,
                Name = bookModel.Name,
                Description = bookModel.Description
            };

            _context.Books.Update(book);
            await _context.SaveChangesAsync();

            return book.ID;
        }

        public async Task<int> UpdateBookPatchAsync(int bookid,JsonPatchDocument bookModel)
        {

            var book = await _context.Books.FindAsync(bookid);

            if (book != null)
            {
                bookModel.ApplyTo(book);
                await _context.SaveChangesAsync();
            }

            return book.ID;
        }

        public async Task<int> DeleteBookbyIDAsync(int bookid)
        {
            // to find book without having primary key column
            //var book = _context.Books.Where(x => x.Name == "").FirstOrDefault();
            //_context.Books.Remove(book);

            var book = new Books() { ID = bookid };
            _context.Books.Remove(book);


            await _context.SaveChangesAsync();
            return bookid;
        }
    }
}
