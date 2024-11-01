namespace WebAppCustomers.Models
{
    public class Ticket
    {
        public string ID { get; set; } = null!;
        public string Title{ get; set; } = null!;
        public string Description { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string? Email { get; set; }
        public Category Category { get; set; } = null!;
    }
}
