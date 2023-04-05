using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travelingViajes.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Firebase.Auth;

namespace travelingViajes.Views.Usuario
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaVuelosU : ContentPage
    {
        public ListaVuelosU()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var vuelosList = await App.SQLiteDB.GetServiciosVueloAsync();
            if (vuelosList != null)
            {
                lsVuelo.ItemsSource = vuelosList;
            }
        }

        private async void btnVolver_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }



        private async void Reservar_Clicked(object sender, EventArgs e)
        {
            var selectedVuelo = (ServiciosVuelos)((Button)sender).BindingContext;
            if (string.IsNullOrEmpty(App.AppContext.UserId))
            {
                await DisplayAlert("Error", "No se ha iniciado sesión.", "OK");
                return;
            }

            if (await App.SQLiteDB.SaveReservaAsync(selectedVuelo, App.AppContext.UserId))
            {
                await DisplayAlert("Reserva realizada", "Se ha realizado la reserva con éxito.", "OK");
            }
            else
            {
                await DisplayAlert("Error", "No se pudo realizar la reservación.", "OK");
            }
        }
    }
}