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
    public partial class GamePage : ContentPage
    {
        private const int const_maxint = 10;
        private const int const_minint = 1;
        private const int const_maxNbEssai = 3;

        private int _numSearsh = new Random().Next(const_minint, const_maxint);
        private int _nbEssai = 0;

        public GamePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            MessageLabel.Text = $"Entre {const_minint} et {const_maxint}.";

            entry_Number.Completed += Entry_Number_OnChange; // évènement
            entry_Number.Focus();
        }

        /// <summary>
        /// évènement lors du changement 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Entry_Number_OnChange(object sender, EventArgs e)
        {
            

            if (sender is Entry entry_num )
            {
                int result;
                if (int.TryParse(entry_num.Text, out result) && (result < const_minint || result > const_maxint))
                { // remise par défaut de Entry
                    entry_num.Placeholder = "?";
                    entry_num.Text = string.Empty;
                }
                else if (!int.TryParse(entry_num.Text, out result))
                {
                    entry_num.Placeholder = "?";
                    entry_num.Text = string.Empty;
                }
            }
        }

        private async void Devinez_Button_Clicked(object sender, EventArgs e)
        {
            int result;

            _nbEssai++;
            if (int.TryParse(entry_Number.Text, out result) && (result >= const_minint && result <= const_maxint))
            {
                if (_numSearsh == result)
                {
                    //DisplayAlert("Win", "Bravo vous avez trouvé le nombre.", "Ok");
                    await this.Navigation.PushAsync(new WinPage(_numSearsh));
                    return;
                    //App.Current.MainPage = new WinPage(_numSearsh);
                }
                else if (_numSearsh < result)
                {
                    await DisplayAlert("Inférieur", $"Le nombre recherché est inférieur à {result}.", "Ok");
                    entry_Number.Focus();
                    entry_Number.Text = string.Empty;
                }
                else
                {
                    await DisplayAlert("Supérieur", $"Le nombre recherché est supérieur à {result}.", "Ok");
                    entry_Number.Focus();
                    entry_Number.Text = string.Empty;
                }

                if (_nbEssai >= const_maxNbEssai)
                {
                    await DisplayAlert("Lose", $"Vous avez perdu, vous avez droit à {const_maxNbEssai} essais", "Ok");
                    //await Task.Delay(2000);
                    await this.Navigation.PopAsync();
                }
            }
            else
            {
                entry_Number.Placeholder = "?";
                entry_Number.Text = string.Empty;
                await DisplayAlert("Erreur", $"le nombre recherché est compris entre {const_minint} et {const_maxint}", "Ok");
            }

            
        }

    }
}