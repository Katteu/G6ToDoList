using Android.Widget;
using G6ToDoList.Dependency_Services;
using Sample;
using System;
using System.Collections.Generic;
using System.Text;
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
