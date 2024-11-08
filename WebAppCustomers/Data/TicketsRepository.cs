﻿using Microsoft.EntityFrameworkCore;
using WebAppCustomers.Models;

namespace WebAppCustomers.Data
{
    public class TicketsRepository
    {
        private readonly DataContext _context;

        public TicketsRepository(DataContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public async Task<List<Ticket>> GetTicketsAsync()
        {
            return await _context.Tickets.ToListAsync();
        }

        public async Task<Ticket> GetTicketByIdAsync(int id)
        {
            var tickets = await GetTicketsAsync();

            foreach (var ticket in tickets)
            {
                if (ticket.ID == id)
                {
                    return ticket;
                    
                }
                await Task.Delay(200);
            }
            return null;
        }
    }
}
