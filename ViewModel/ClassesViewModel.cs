using Exercise_8.Model;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
                BaseViewModel.SelectedClass = value;
                OnPropertyChanged(nameof(SelectedClass));
                OnPropertyChanged(nameof(Classes));
            }
            get { return _class; }
        }

        public ICommand AddEmptyClassCommand { get; set; }

        public void AddEmptyClass()
        {
            Classes.Add(new ClassesModel());
            OnPropertyChanged(nameof(Classes));
        }


        public ICommand AddStudentCommand { get; set; }
        public void AddStudent()
        {
            if (SelectedClass.StudentsInClass.Contains(BaseViewModel.SelectedStudent))
                return; 


            SelectedClass.StudentsInClass.Add(BaseViewModel.SelectedStudent);
            OnPropertyChanged(nameof(SelectedClass.StudentsInClass));
        }

        public ICommand RemoveStudentCommand { get; set; }
        public void RemoveStudent()
        {
            if (!SelectedClass.StudentsInClass.Contains(BaseViewModel.SelectedStudent))
                return;
            SelectedClass.StudentsInClass.Remove(BaseViewModel.SelectedStudent);
            OnPropertyChanged(nameof(SelectedClass.StudentsInClass));
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

            AddEmptyClassCommand = new RelayCommand(AddEmptyClass);
            AddStudentCommand = new RelayCommand(AddStudent);
            RemoveStudentCommand = new RelayCommand(RemoveStudent);


        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
