using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class SalesDetails
    {
        [Key]
        public int SalesDetailsId { get; set; }

        [Required]
        public int SaleId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public decimal Value { get; set; }

        public SalesDetails()
        {
            SalesDetailsId = 0;
            ProductId = 0;
            SaleId = 0;
            Quantity = 0;
            Price = 0;
            Value = 0;
        }
    }
}
