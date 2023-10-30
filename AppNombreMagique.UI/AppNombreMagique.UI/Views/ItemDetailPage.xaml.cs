using AppNombreMagique.UI.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AppNombreMagique.UI.Views
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