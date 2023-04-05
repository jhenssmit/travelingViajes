using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace travelingViajes.Views.Usuario
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaPrincipalUsuario : ContentPage
    {
        public PaginaPrincipalUsuario()
        {
            InitializeComponent();
            hola.Text = App.AppContext.UserId;
        }

        private async void btnDisponible_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ListaVuelosU());
        }

        private async void btnReservado_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Reservaciones());
        }

        private async void btnCerrarSesion_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}