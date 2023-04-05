using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travelingViajes.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace travelingViajes.Views.Usuario
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class Reservaciones : ContentPage
    {
        private ResumenReservaViewModel viewModel;
        public Reservaciones()
        {
            InitializeComponent();
            CargarReservasAsync();
        }
        private async void CargarReservasAsync()
        {
            // Obtener la lista de reservas y actualizar la propiedad ServiciosVuelos
            var reservas = await App.SQLiteDB.GetReservasByUserIdAsync(App.AppContext.UserId);
            var serviciosVuelos = new List<ServiciosVuelos>();

            foreach (var reserva in reservas)
            {
                var servicio = await App.SQLiteDB.GetServiciosVuelosByIdAsync(reserva.IdVuelos);
                serviciosVuelos.Add(servicio);
            }

            viewModel = new ResumenReservaViewModel(serviciosVuelos);
            BindingContext = viewModel;
        }
        
    }
}