using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppNombreMagique.UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            _ = ScaleInfinite(Game_Button, 1500);
        }



        private async Task ScaleInfinite(View view, uint time)
        {
            while (true)
            {
                await view.ScaleTo(1.2, time);
                await view.ScaleTo(1.0,time);
            }
        }

        private void Game_Button_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new GamePage());
            //App.Current.MainPage = new GamePage();
        }
    }
}