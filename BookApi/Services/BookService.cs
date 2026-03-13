using Microsoft.EntityFrameworkCore;

public class BookService : IBookService
{
    private readonly AppDbContext _context;

    public BookService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Book>> GetAllAsync()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task<Book> AddAsync(Book book)
    {
        _context.Books.Add(book);

        await _context.SaveChangesAsync();

        return book;
    }

    public async Task<Book?> UpdateAsync(int id, Book updated)
    {
        var book = await _context.Books.FindAsync(id);

        if (book == null)
            return null;

        book.Title = updated.Title;
        book.Author = updated.Author;
        book.Isbn = updated.Isbn;
        book.PublicationDate = updated.PublicationDate;

        await _context.SaveChangesAsync();

        return book;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var book = await _context.Books.FindAsync(id);

        if (book == null)
            return false;

        _context.Books.Remove(book);

        await _context.SaveChangesAsync();

        return true;
    }
}