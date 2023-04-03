using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travelingViajes.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace travelingViajes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroUser : ContentPage
    {
        public RegistroUser()
        {
            InitializeComponent();
        }
        //Botón para Registrar Usuario
        private async void btnRegistro_Clicked(object sender, EventArgs e)
        {
            if (validarDatosUsuario())
            {
                Usuarios user = new Usuarios
                {
                    Nombres = txtNombre.Text,
                    AplellidoPaterno = txtApellidoP.Text,
                    AplellidoMaterno = txtApellidoM.Text,
                    DNI = txtDNI.Text,
                    Celular = txtCelular.Text,
                    Correo = txtGmail.Text,
                    Contrasena = txtContraseña.Text,
                };
                await App.SQLiteDB.SaveUsuarioAsync(user);
                txtNombre.Text = "";
                txtApellidoP.Text = "";
                txtApellidoM.Text = "";
                txtDNI.Text = "";
                txtCelular.Text = "";
                txtGmail.Text = "";
                txtContraseña.Text = "";
                await DisplayAlert("Registro", "Usted se registro Exitosamente", "Ok");
                
            }
            else
            {
                await DisplayAlert("Advertencia", "Ingresar todos los Datos", "Ok");
            }
        }
        //Validar Datos
        public bool validarDatosUsuario()
        {
            bool respuesta;
            if (string.IsNullOrEmpty(txtNombre.Text)) 
            {
              respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtApellidoP.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtApellidoM.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtDNI.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtCelular.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtGmail.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtContraseña.Text))
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