using BookStore.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.API.Repository
{
    public interface IBookRepository
    {
        Task<List<BookModel>> GetAllBooksAsync();

        Task<BookModel> GetBookbyIDAsync(int bookid);

        Task<int> AddBookAsync(BookModel bookModel);

        Task<int> UpdateBookAsync(int bookid, BookModel bookModel);

        Task<int> UpdateBookPatchAsync(int bookid, JsonPatchDocument bookModel);

        Task<int> DeleteBookbyIDAsync(int bookid);
    }
}
