using Microsoft.EntityFrameworkCore;
using SomaShare.Data;
using SomaShare.Models;

namespace SomaShare.Services
{
    public class TextbookService
    {
        private readonly ApplicationDbContext _context;

        public TextbookService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Textbook>> GetAllAsync()
        {
            return await _context.Textbooks.ToListAsync();
        }

        public async Task CreateAsync(Textbook book)
        {
            _context.Textbooks.Add(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Textbook book)
        {
            _context.Textbooks.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var book = await _context.Textbooks.FindAsync(id);
            if (book != null)
            {
                _context.Textbooks.Remove(book);
                await _context.SaveChangesAsync();
            }
        }
    }
}