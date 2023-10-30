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
	public partial class StarsView : ContentView
	{
		public StarsView ()
		{
			InitializeComponent ();
            _ = RotateStarInfinite(star1, 5000);
            _ = RotateStarInfinite(star2, 7000);
            _ = RotateStarInfinite(star3, 9000);
        }

        /// <summary>
        /// Méthode qui fait tourner les étoiles champ image 
        /// </summary>
        private async Task RotateStarInfinite(View view, uint time)
        {
            while (true)
            {
                await view.RotateTo(360, time);
                view.Rotation = 0;
            }
        }
    }
}