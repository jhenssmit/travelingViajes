using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travelingViajes.Views;
using Xamarin.Forms;

namespace travelingViajes
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnUser_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InicioSesionUser());
        }

        private async void btnAdmin_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InicioSesionAdmin());
        }
    }
}
