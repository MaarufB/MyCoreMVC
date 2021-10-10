using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MyCoreMVC.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; } // This will become our primary key for our Category table in Database
        
        [Required]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Display Order for category must be grater than 0")]
        public int DisplayOrder { get; set; }

    }
}
