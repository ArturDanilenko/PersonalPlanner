using System;
using System.Collections.Generic;
using PersonalPlanner.ViewModels;
using PersonalPlanner.Views;
using Xamarin.Forms;

namespace PersonalPlanner
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
