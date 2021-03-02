using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Suppliers
    {
        [Key]
        [Required]
        public int SuplierId { get; set; }

        [Required]
        [MinLength(3)]
        public string SuplierName { get; set; }

        [Required]
        [MinLength(3)]
        public string SuplierLastName { get; set; }

        [Required]
        [MinLength(3)]
        public string CompanyName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(10)]
        public string PhoneNumber { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(10)]
        public string CellPhone { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public DateTime EntryDate { get; set; }

        [Required]
        public int UserId { get; set; }
        public Users Users { get; set; }

        public ICollection<Products> Products { get; set; }

        public Suppliers()
        {
            SuplierId = 0;
            SuplierName = string.Empty;
            SuplierLastName = string.Empty;
            CompanyName = string.Empty;
            Address = string.Empty;
            PhoneNumber = string.Empty;
            CellPhone = string.Empty;
            City = string.Empty;
            EntryDate = DateTime.Now;
            UserId = 0;
        }
    }
}
