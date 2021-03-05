using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Shops
    {
        [Key]
        [Required]
        public int ShopId { get; set; }

        [Required]
        public int SupplierId { get; set; }

        [Required]
        public DateTime ShopDate { get; set; }

        [Required]
        public decimal SubTotal { get; set; }

        [Required]
        public double ITBIS { get; set; }

        public decimal Discount { get; set; }

        [Required]
        public decimal Total { get; set; }

        [ForeignKey("ShopId")]
        public virtual IList<ShopsDetails> ShopsDetails { get; set; }

        public int UserId { get; set; }

        public Users Users { get; set; } //Users navigation property
        public Suppliers Suppliers { get; set; } //Suppliers navigation property


        public Shops()
        {
            ShopId = 0;
            SupplierId = 0;
            ShopDate = DateTime.Now;
            SubTotal = 0;
            ITBIS = 0;
            Discount = 0;
            Total = 0;
            UserId = 0;
        }

    }
}