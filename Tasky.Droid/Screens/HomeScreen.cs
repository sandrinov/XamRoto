using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Tasky.Shared.BusinessLayer;

namespace Tasky.Droid.Screens
{
    [Activity(Label = "Tasky Pro", MainLauncher = true)]
    public class HomeScreen : Activity
    {
        protected IList<Task> tasks;
        protected ListView taskListView = null;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }
    }
}