using G6ToDoList.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace G6ToDoList.Pages
{
    public static class DataRepository
    {
        public static ObservableCollection<TaskModel> taskList = new ObservableCollection<TaskModel>();
    }
}
