using G6ToDoList.Pages;
using G6ToDoList.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace G6ToDoList
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void listHeader_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListPage());
        }

        private async void editHeader_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Wait first!", "You have to choose a task to edit.", "OK");
        }

        private void addButt_Clicked(object sender, EventArgs e)
        {
            string title, desc;
            if (!string.IsNullOrEmpty(TitleEntry.Text) && !string.IsNullOrEmpty(DescEdit.Text))
            {
                title = TitleEntry.Text;
                desc = DescEdit.Text;
                TitleEntry.Text = DescEdit.Text = string.Empty;
                Navigation.PushAsync(new ListPage(title, desc));
            }
            else
            {
                DisplayAlert("Error!", "Cannot add empty entries to list.", "OK");
            }
        }
    }
}
