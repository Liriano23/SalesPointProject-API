using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Employers
    {
        [Key]
        [Required]
        public int EmployerId { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        public string LastName { get; set; }

        [Required]
        [MinLength(11)]
        [MaxLength(11)]
        public string SocialId { get; set; }

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
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(3)]
        public string JobRol { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public DateTime EntryDate { get; set; }

        [Required]
        public int UserId { get; set; }
        public Users Users { get; set; }

        public ICollection<Sales> Sales { get; set; }

        public Employers()
        {
            EmployerId = 0;
            Name = string.Empty;
            LastName = string.Empty;
            SocialId = string.Empty;
            PhoneNumber = string.Empty;
            CellPhone = string.Empty;
            Address = string.Empty;
            Email = string.Empty;
            JobRol = string.Empty;
            Salary = 0;
            BirthDate = DateTime.Now;
            EntryDate = DateTime.Now;
            UserId = 0;
        }
    }
}