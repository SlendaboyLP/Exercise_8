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

        public string FirstName { get { return _firstName; }  set { _firstName = value; OnPropertyChanged(nameof(FirstName)); } }
        public string LastName { get { return _lastName; } set { _lastName = value; OnPropertyChanged(nameof(LastName)); } }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public StudentModel(string fn, string ln) 
        {
            FirstName = fn;
            LastName = ln;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }

}
