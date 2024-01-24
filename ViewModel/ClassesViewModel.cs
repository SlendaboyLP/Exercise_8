using Exercise_8.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_8.ViewModel
{
    internal class ClassesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public ObservableCollection<ClassesModel> Classes { get; set; } = new ObservableCollection<ClassesModel>();
        private ClassesModel _class;
        public ClassesModel SelectedClass
        {
            set
            {
                _class = value;
                OnPropertyChanged(nameof(SelectedClass));
                OnPropertyChanged(nameof(Classes));
            }
            get { return _class; }
        }


        public void CreateClasses()
        {
            ClassesModel class1 = new ("MEDT1", "Medientechnische Inhalte");
            ClassesModel class2 = new("NAWI3", "Naturwissenschaftliche Themen");
            ClassesModel class3 = new("NWTK2", "Kabeln stöpseln");

            Classes.Add(class1);
            Classes.Add(class2);
            Classes.Add(class3);

            OnPropertyChanged(nameof(Classes));


        }


        public ClassesViewModel()
        {
            CreateClasses();

        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
