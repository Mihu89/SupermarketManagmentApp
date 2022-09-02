﻿using System.ComponentModel.DataAnnotations;

namespace CoreBusiness
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }

        // navigation properties
        public Category Category { get; set; }
    }
}
