using G6ToDoList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace G6ToDoList.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UpdatePage : ContentPage
	{
        TaskModel taskNew;
		public UpdatePage ()
		{
			InitializeComponent ();
		}

        public UpdatePage(TaskModel task)
        {
            taskNew = task;
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

        private void listHeader_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListPage());
        }

        private void updateButt_Clicked(object sender, EventArgs e)
        {
            string title, desc;
            int currID = taskNew.id;
            if (!string.IsNullOrEmpty(TitleEntry.Text) && !string.IsNullOrEmpty(DescEdit.Text))
            {
                title = TitleEntry.Text;
                desc = DescEdit.Text;
                foreach(var indx in DataRepository.taskList)
                {
                    if(indx.id == currID)
                    {
                        indx.title= title;
                        indx.description= desc;
                    }
                }
                TitleEntry.Text = DescEdit.Text = string.Empty;
                Navigation.PushAsync(new ListPage());
            }
            else
            {
                DisplayAlert("Error!", "Cannot add empty entries to list. Fill in all fields to update the task.", "OK");
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            TitleEntry.Text = taskNew.title;
            DescEdit.Text = taskNew.description;
        }
    }
}