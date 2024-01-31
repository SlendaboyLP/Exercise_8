using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_8.Model
{
    class StudentModel : INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string FirstName { get { return _firstName; }  set { _firstName = value; OnPropertyChanged(nameof(FirstName)); OnPropertyChanged(nameof(FullName)); } }
        public string LastName { get { return _lastName; } set { _lastName = value; OnPropertyChanged(nameof(LastName)); OnPropertyChanged(nameof(FullName));  } }


        public string FullName { get { return $"{FirstName} {LastName}";  } }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public StudentModel()
        {
            FirstName = "Empty";
            LastName = "Empty";
        }
        public StudentModel(string fn, string ln) 
        {
            FirstName = fn;
            LastName = ln;
        }

       
    }

}
