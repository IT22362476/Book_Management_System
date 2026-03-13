public interface IBookService
{
    Task<List<Book>> GetAllAsync();

    Task<Book> AddAsync(Book book);

    Task<Book?> UpdateAsync(int id, Book book);

    Task<bool> DeleteAsync(int id);
}