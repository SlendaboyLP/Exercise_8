using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_8.Model
{
    internal class ClassesModel : INotifyPropertyChanged
    {
        private string _id;
        private string _topic;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string ID { get { return _id; } set { _id = value; OnPropertyChanged(nameof(ID)); OnPropertyChanged(nameof(FullID)); } } 
        public string Topic { get { return _topic; } set { _topic = value; OnPropertyChanged(nameof(Topic)); OnPropertyChanged(nameof(FullID)); } }

        public string FullID { get { return $"{ID} : {Topic}"; } }

        public ObservableCollection<StudentModel> StudentsInClass {  get; set; }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ClassesModel()
        {
            ID = "Empty";
            Topic = "Empty";
            StudentsInClass = new ObservableCollection<StudentModel>();

        }
        public ClassesModel(string id, string topic)
        {
            ID = id;
            Topic = topic;
            StudentsInClass = new ObservableCollection<StudentModel>();

        }

        public override string ToString()
        {
            return $"{ID} : {Topic}";
        }
    }
}
