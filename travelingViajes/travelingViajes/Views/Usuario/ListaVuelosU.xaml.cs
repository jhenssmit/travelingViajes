using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
    }
}