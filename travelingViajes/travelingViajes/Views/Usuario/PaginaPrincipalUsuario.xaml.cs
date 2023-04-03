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
        }

        private async void btnDisponible_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaVuelosU());
        }

        private void btnReservado_Clicked(object sender, EventArgs e)
        {

        }
    }
}