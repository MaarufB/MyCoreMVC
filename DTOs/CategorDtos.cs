using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCoreMVC.Models;

namespace MyCoreMVC.DTOs
{
    public class CategorDtos
    {


        public int Id { get; set; } // This will become our primary key for our Category table in Database
        public string Name { get; set; }
        public string DisplayOrder { get; set; }
    //     private Category _category;
    //     public CategorDtos(Category category)
    //     {
    //         _category = category;
    //     }

    //     public Category category 
    //     { 
    //         get { return _category;} 
    //     }
    // }

    // public interface ICategoryDTos
    // {
    //     CategorDtos GetCategory(CategorDtos cat);
    // }

    // public class BaseCategory: ICategoryDTos
    // {
    //     CategorDtos GetCategory(CategorDtos cat)
    //     {
    //         return new CategorDtos{
    //             category = cat.category
    //         }
    //     }
    }
}