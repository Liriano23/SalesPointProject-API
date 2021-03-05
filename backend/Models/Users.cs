using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Users
    {
        [Key]
        [Required]
        public int UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string SocialId { get; set; } //Cedula

        [Required]
        public string SexType { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(10)]
        public string PhoneNumber { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(10)]
        public string CellPhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string UserRol { get; set; }

        [Required]
        public DateTime EntryDate { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string password { get; set; }

        public ICollection<Categories> Categories { get; set; }
        public ICollection<Employers> Employers { get; set; }
        public ICollection<Products> Products { get; set; }
        public ICollection<Suppliers> Supliers { get; set; }
        public ICollection<Sales> Sales { get; set; }
        public ICollection<Shops> Shops { get; set; }

        public Users()
        {
            UserId = 0;
            Name = string.Empty;
            LastName = string.Empty;
            SocialId = string.Empty;
            SexType = string.Empty;
            PhoneNumber = string.Empty;
            CellPhoneNumber = string.Empty;
            Address = string.Empty;
            Email = string.Empty;
            EntryDate = DateTime.Now;
            UserRol = string.Empty;
            UserName = string.Empty;
            password = string.Empty;
        }

    }
}
