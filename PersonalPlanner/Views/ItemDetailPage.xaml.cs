using System.ComponentModel;
using Xamarin.Forms;
using PersonalPlanner.ViewModels;

namespace PersonalPlanner.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}