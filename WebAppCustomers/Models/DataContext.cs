using Microsoft.EntityFrameworkCore;

namespace WebAppCustomers.Models
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext (options)
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "TicketSystem");
        }

        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
    }
}
