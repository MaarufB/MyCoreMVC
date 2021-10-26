using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCoreMVC.Models
{
    public class TestModel
    {

    }

    public class TodoListTestModel
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskStatus { get; set; }
    }
}
