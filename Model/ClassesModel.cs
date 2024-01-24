using System;
using System.Collections.Generic;
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

        public string ID { get { return _id; } set { _id = value; OnPropertyChanged(nameof(ID)); } }
        public string Topic { get { return _topic; } set { _topic = value; OnPropertyChanged(nameof(Topic)); } }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ClassesModel()
        {
            ID = "Empty";
            Topic = "Empty";
        }
        public ClassesModel(string id, string topic)
        {
            ID = id;
            Topic = topic;
        }

        public override string ToString()
        {
            return $"{ID} : {Topic}";
        }
    }
}
