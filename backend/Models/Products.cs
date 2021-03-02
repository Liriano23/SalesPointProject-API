using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Products
    {
        [Key]
        [Required]
        public int ProductId { get; set; }

        [Required]
        [MinLength(3)]
        public string ProductName { get; set; }

        [Required]
        [MinLength(3)]
        public string ProductBrand { get; set; }

        [Required]
        public int QuantityInStock { get; set; }

        [Required]
        public decimal SalePrice { get; set; }

        [Required]
        public decimal BuyPrince { get; set; }

        [Required]
        public DateTime EntryDate { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Categories Categories { get; set; }

        [Required]
        public int supplierId { get; set; }
        public Suppliers Suppliers { get; set; }

        [Required]
        public int UserId { get; set; }
        public Users Users { get; set; }

        public Products()
        {
            ProductId = 0;
            ProductName = string.Empty;
            ProductBrand = string.Empty;
            QuantityInStock = 0;
            EntryDate = DateTime.Now;
            SalePrice = 0;
            BuyPrince = 0;
            CategoryId = 0;
            supplierId = 0;
            UserId = 0;
        }
    }
}
