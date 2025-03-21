using Hotel.Data;
using Hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Services
{
    public class RoomService
    {
        private readonly ApplicationDbContext _context;

        public RoomService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Room>> GetAllAsync()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task<Room> GetByIdAsync(Guid id)
        {
            return await _context.Rooms.FindAsync(id);
        }

        public async Task AddAsync(Room camera)
        {
            _context.Rooms.Add(camera);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Room camera)
        {
            _context.Rooms.Update(camera);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var camera = await _context.Rooms.FindAsync(id);
            if (camera != null)
            {
                _context.Rooms.Remove(camera);
                await _context.SaveChangesAsync();
            }
        }
    }
}
