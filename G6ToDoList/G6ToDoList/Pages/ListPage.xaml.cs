using G6ToDoList.Models;
using Sample;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Android.Icu.Text.CaseMap;

namespace G6ToDoList.Pages  
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
        }
        public ListPage(string titleNew,string descNew)
        {
            DataRepository.taskList.Add(new TaskModel() { id = DataRepository.taskList.Count, title = titleNew, description = descNew, isDone = false });
            InitializeComponent();
        }

        private void addHeader_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        private async void editHeader_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Wait first!", "You have to choose a task to edit.", "OK");
        }

        private void doneBtn_Clicked(object sender, EventArgs e)
        {
            Label txt = sender as Label;
            foreach(var indx in DataRepository.taskList)
            {
                if(indx.id == Convert.ToInt32(txt.ClassId))
                {
                    indx.isDone = !indx.isDone;

                    if (Device.RuntimePlatform == Device.Android)
                        DependencyService.Get<IToast>().Show(indx.isDone ? "Task done!" : "Task unchecked!");
                }
            }
        }

        private async void delBtn_Clicked(object sender, EventArgs e)
        {
            Label txt = sender as Label;
            bool response = await DisplayAlert("Delete Task", "Are you sure you want to delete this task?", "Yes", "No");
            if (response)
            {
                TaskModel task = new TaskModel();
                foreach (var indx in DataRepository.taskList)
                {
                    if (indx.id == Convert.ToInt32(txt.ClassId))
                        task = indx;
                }
                DataRepository.taskList.Remove(task);
                if (Device.RuntimePlatform == Device.Android)
                    DependencyService.Get<IToast>().Show("Task Deleted!");
            }
        }

        private void editBtn_Clicked(object sender, EventArgs e)
        {
            Label txt = sender as Label;
            TaskModel task = new TaskModel();
            foreach (var indx in DataRepository.taskList)
            {
                if (indx.id == Convert.ToInt32(txt.ClassId))
                 task = indx;
            }
            Navigation.PushAsync(new UpdatePage(task));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            taskListView.ItemsSource = DataRepository.taskList;
        }


    }
}