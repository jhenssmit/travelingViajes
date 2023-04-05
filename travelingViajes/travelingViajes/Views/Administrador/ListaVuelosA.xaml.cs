using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travelingViajes.Models;
using travelingViajes.Views.Administrador;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace travelingViajes.Views.Administrador
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaVuelosA : ContentPage
    {
        ObservableCollection<ServiciosVuelos> vuelos = new ObservableCollection<ServiciosVuelos>();
        public ListaVuelosA()
        {
            InitializeComponent();
           
            lsVuelo.ItemsSource = vuelos;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            vuelos.Clear();
            var list = await App.SQLiteDB.GetServiciosVueloAsync();
            foreach (var item in list)
            {
                vuelos.Add(item);
            }
        }



        private async void Eliminar_Clicked(object sender, EventArgs e)
        {
            var vuelo = ((Button)sender).CommandParameter as ServiciosVuelos;
            if (vuelo != null)
            {
                await App.SQLiteDB.DeleteVuelo(vuelo);
                
                await DisplayAlert("Vuelo", "Se eliminó de manera exitosa", "Ok");
                vuelos.Remove(vuelo);
            }
        }

        private async void btnVolver_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}