using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Sales
    {
        [Key]
        public int SalesId { get; set; }

        [Required]
        public DateTime ActualDate { get; set; }

        [Required]
        public decimal SubTotal { get; set; }

        [Required]
        public double ITBIS { get; set; }

        [Required]
        public decimal Discount { get; set; }

        [Required]
        public decimal Total { get; set; }

        [Required]
        public int UserId { get; set; }
        public Users Users { get; set; }

        [Required]
        public int EmployerId { get; set; }
        public Employers Employers { get; set; }

        public virtual IList<SalesDetails> SalesDetails { get; set; }

        public Sales()
        {
            SalesId = 0;
            EmployerId = 0;
            ActualDate = DateTime.Now;
            SubTotal = 0;
            ITBIS = 0;
            Discount = 0;
            Total = 0;
            UserId = 0;
            EmployerId = 0;
        }
    }
}
