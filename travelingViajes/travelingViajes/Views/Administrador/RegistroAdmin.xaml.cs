using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travelingViajes.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace travelingViajes.Views.Administrador
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroAdmin : ContentPage
    {
        public RegistroAdmin()
        {
            InitializeComponent();
        }
        private async void btnRegistro_Clicked(object sender, EventArgs e)
        {
            if (ValidarDatosAdmin())
            {
                Admin admin = new Admin()
                {
                    Usuario = txtUsuario.Text,
                    Contraseña = txtContraseña.Text,
                };
                await App.SQLiteDB.SaveAdminAsync(admin);
                txtUsuario.Text = "";
                txtContraseña.Text = "";
                await DisplayAlert("Registro", "Administrador registrado exitosamente", "Ok");
            }
            else
            {
                await DisplayAlert("Advertencia", "Ingresar todos los Datos", "Ok");
            }
        }
        public bool ValidarDatosAdmin()
        {
            bool respuesta;
            if(string.IsNullOrEmpty(txtUsuario.Text))
            {
                respuesta = false;
            }
            else if(string.IsNullOrEmpty(txtContraseña.Text))
            {
                respuesta = false;
            }
            else
            {
                respuesta = true;
            }
            return respuesta;
        }
    }
}