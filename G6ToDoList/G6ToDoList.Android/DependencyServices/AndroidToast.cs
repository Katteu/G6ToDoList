using Android.Widget;
using G6ToDoList.Dependency_Services;
using G6ToDoList;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

[assembly: Dependency(typeof(AndroidToast))]

namespace G6ToDoList.Dependency_Services
{

    public class AndroidToast : IToast
    {
        public void Show(string message)
        {
            Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short).Show();
        }
    }
}