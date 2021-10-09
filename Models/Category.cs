using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyCoreMVC.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; } // This will become our primary key for our Category table in Database
        public string Name { get; set; }
        public int DisplayOrder { get; set; }

    }
}
