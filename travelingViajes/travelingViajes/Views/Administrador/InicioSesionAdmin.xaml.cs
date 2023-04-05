using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using travelingViajes.Data;
using travelingViajes.Models;
using travelingViajes.Views.Administrador;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace travelingViajes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InicioSesionAdmin : ContentPage
    {
        public InicioSesionAdmin()
        {
            InitializeComponent();
        }

        private async void btnIniciar_Clicked(object sender, EventArgs e)
        {
            string usuario = EntryUsuario.Text;
            string contrasena = EntryContasena.Text;
            var Admin = await App.SQLiteDB.VerifyAdminCredentialsAsync(usuario, contrasena);
            if (Admin)
            {
                await Navigation.PushModalAsync(new PaginaPrincipalAdmin());
            }
            else
            {
                await DisplayAlert("Error", "Usuario y/o Contraseña incorrectos", "Ok");
            }
        }

        private async void btnRegistro_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistroAdmin());
        }
    }
}