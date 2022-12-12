﻿namespace ProductManagement.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public string? Description { get; set; }
        public Category Category { get; set; } = null!;
        public int CategoryId { get; set; }
    }
}
