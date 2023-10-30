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

            NbMagique = nbMagique;
            NombreMagiqueLabel.Text += $" {NbMagique}";

            AffichageTime(_nbSeconde);
        }

        /// <summary>
        /// Affiche la page et au bout de x seconde va afficher la page d'accueil
        /// </summary>
        /// <param name="nbSeconde">temps en secondd'affiche de la page avant changement</param>
        private void AffichageTime (int nbSeconde)
        {
            Device.StartTimer(new TimeSpan(0, 0, nbSeconde), () =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    //App.Current.MainPage = new WelcomePage();
                    //this.Navigation.PopAsync();
                    this.Navigation.PushAsync(new WelcomePage());
                }
                );

                return false;
            });
        }
    }
}