using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class ShopsDetails
    {
        [Key]
        [Required]
        public int ShopDetailId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int ShopId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public decimal Value { get; set; }

        public ShopsDetails()
        {
            ShopDetailId = 0;
            ProductId = 0;
            ShopId = 0;
            Quantity = 0;
            Price = 0;
            Value = 0;
        }
    }
}
