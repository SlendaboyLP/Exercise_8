using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Exercise_8.Model;
using Exercise_8.View;
using GalaSoft.MvvmLight.Command;

namespace Exercise_8.ViewModel
{
    class StudentViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public ObservableCollection<StudentModel> Students { get; set; } = new ObservableCollection<StudentModel>();

        public ICommand AddEmptyStudentCommand { get; set; }
        private StudentModel _student;
        public StudentModel SelectedStudent
        {
            set
            {
                _student = value;
                OnPropertyChanged(nameof(SelectedStudent));
                OnPropertyChanged(nameof(Students));
            }
            get { return _student; }
        }


        public  void CreateStudents()
        {
            StudentModel model1 = new StudentModel("Norbert", "Ebner");
            StudentModel model2 = new StudentModel("Dovid", "Muttentaler");
            StudentModel model3 = new StudentModel("Hansi", "Scheiberl");

            Students.Add(model1);
            Students.Add(model2);
            Students.Add(model3);

            OnPropertyChanged(nameof(Students));


        }

        public void AddEmptyStudent()
        {
            Students.Add(new StudentModel());
            OnPropertyChanged(nameof(Students));
        }

        public StudentViewModel()
        {
            CreateStudents();
            AddEmptyStudentCommand = new RelayCommand(AddEmptyStudent);

        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            


            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));



        }
    }
}
