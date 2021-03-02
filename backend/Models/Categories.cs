using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Categories
    {
        [Key]
        [Required]
        public int CategoryId { get; set; }

        [Required]
        [MinLength(3)]
        public string CategoryName { get; set; }

        [Required]
        public DateTime EntryDate { get; set; }

        [Required]
        public int UserId { get; set; }
        public Users User { get; set; }

        public ICollection<Products> Products { get; set; }

        public Categories()
        {
            CategoryId = 0;
            CategoryName = string.Empty;
            EntryDate = DateTime.Now;
            UserId = 0;
        }
    }
}
