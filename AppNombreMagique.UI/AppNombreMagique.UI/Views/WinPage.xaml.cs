using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace AppNombreMagique.UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WinPage : ContentPage
    {
        public int NbMagique; // nombre magique a affiché
        private int _nbSeconde = 5;

        public WinPage(int nbMagique)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            winLayout.Scale = 0.7;
            winLayout.ScaleTo(1, 1500, Easing.BounceIn);

            NbMagique = nbMagique;
            NombreMagiqueLabel.Text += $" {NbMagique}";

            _ = AffichageTime(_nbSeconde);
        }

        /// <summary>
        /// Affiche la page et au bout de x seconde va afficher la page d'accueil
        /// </summary>
        /// <param name="nbSeconde">temps en secondd'affiche de la page avant changement</param>
        private async Task AffichageTime (int nbSeconde)
        {
            
            await Task.Delay(nbSeconde*1000);
            await this.Navigation.PushAsync(new WelcomePage());

            /*Device.StartTimer(new TimeSpan(0, 0, nbSeconde), () =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    //App.Current.MainPage = new WelcomePage();
                    //this.Navigation.PopAsync();
                    await this.Navigation.PushAsync(new WelcomePage());
                }
                );

                return false;
            });*/
        }
    }
}