using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyCoreMVC.Models
{
    public class TodoModel
    {
        [Key]
        public int TaskId { get; set; }
        
        [Required]
        public string TaskName { get; set; }
        
        [Required]
        public string TaskStatus { get; set; }
        // The use of Microsoft.AspNetCore.Mvc.Rendering;
    
    }
}
