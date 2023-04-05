using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travelingViajes.Models;
using travelingViajes.Views.Usuario;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace travelingViajes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InicioSesionUser : ContentPage
    {

        public InicioSesionUser()
        {
            InitializeComponent();
        }

        private async void btnRegistro_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistroUser());
        }

        private async void btnIniciar_Clicked(object sender, EventArgs e)
        {
            string correo = EntryCorreo.Text;
            string contrasena = EntryContasena.Text;
            var users = await App.SQLiteDB.VerifyUsuariosCredentialsAsync(correo, contrasena);
            if (users)
            {
                App.AppContext.UserId = Session.UserId.ToString();
                await Navigation.PushModalAsync(new PaginaPrincipalUsuario());
            }
            else
            {
                await DisplayAlert("Error", "Email y/o Contraseña incorrectos", "Ok");
            }

        }
    }
}