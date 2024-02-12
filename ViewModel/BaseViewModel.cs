using Exercise_8.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_8.ViewModel
{
    class BaseViewModel
    {
        public static StudentModel SelectedStudent { get; set; }
        public static ClassesModel SelectedClass { get; set; }

     
    }
}
