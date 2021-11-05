using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCoreMVC.Models;

namespace MyCoreMVC.DTOs
{
    public class CategorDtos
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}