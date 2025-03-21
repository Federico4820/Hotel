using Hotel.Data;
using Hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Services
{
    public class ReservationService
    {
        private readonly ApplicationDbContext _context;

        public ReservationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reservation>> GetAllAsync()
        {
            return await _context.Reservations
                .Include(p => p.CustumerId)
                .Include(p => p.RoomId)
                .ToListAsync();
        }

        public async Task<Reservation> GetByIdAsync(Guid id)
        {
            return await _context.Reservations
                .Include(p => p.CustumerId)
                .Include(p => p.RoomId)
                .FirstOrDefaultAsync(p => p.ReservationId == id);
        }

        public async Task AddAsync(Reservation prenotazione)
        {
            _context.Reservations.Add(prenotazione);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Reservation prenotazione)
        {
            _context.Reservations.Update(prenotazione);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var prenotazione = await _context.Reservations.FindAsync(id);
            if (prenotazione != null)
            {
                _context.Reservations.Remove(prenotazione);
                await _context.SaveChangesAsync();
            }
        }
    }
}
