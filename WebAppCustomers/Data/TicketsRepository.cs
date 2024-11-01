using Microsoft.EntityFrameworkCore;
using WebAppCustomers.Models;

namespace WebAppCustomers.Data
{
    public class TicketsRepository
    {
        private readonly DataContext _context;

        public TicketsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Ticket>> GetTicketsAsync()
        {
            return await _context.Tickets.ToListAsync();
        }
    }
}
