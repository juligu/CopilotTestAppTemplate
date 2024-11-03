﻿namespace WebAppCustomers.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public virtual ICollection<Ticket>? Tickets { get;set; }
    }
}
