namespace WebAppCustomers.Models
{
    public class Ticket
    {
        public int ID { get; set; }
        public string Title{ get; set; } = null!;
        public string Description { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public int CategoryID { get; set; }
        public Category Category { get; set; } = null!;
    }
}
