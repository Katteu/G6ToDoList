using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace G6ToDoList.Models
{
    public class TaskModel : INotifyPropertyChanged
    {
        int _id { get; set; }
        string _title { get; set; }
        string _description { get; set; }
        bool _isDone { get; set; }

        public int id { get { return _id; } set { _id = value; OnPropertyChanged(nameof(id)); } }
        public string title { get { return _title; } set { _title = value; OnPropertyChanged(nameof(title)); } }

        public string description { get { return _description; } set { _description = value; OnPropertyChanged(nameof(description)); } }
        public bool isDone { get { return _isDone; } set { _isDone = value; OnPropertyChanged(nameof(isDone)); } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
