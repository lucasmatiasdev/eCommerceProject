﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceProject.Domain.Entities
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public string? Image { get; set; }
        public int Quantity { get; set; }
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
