using Hotel.Data;
using Hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Services
{
    public class CustomerService
    {
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(Guid id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task AddAsync(Customer cliente)
        {
            _context.Customers.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Customer cliente)
        {
            _context.Customers.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var cliente = await _context.Customers.FindAsync(id);
            if (cliente != null)
            {
                _context.Customers.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }
    }
}
