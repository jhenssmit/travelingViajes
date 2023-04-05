using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using travelingViajes.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace travelingViajes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroVuelos : ContentPage
    {
        public RegistroVuelos()
        {
            InitializeComponent();
        }

        private async void btnRegistro_Clicked(object sender, EventArgs e)
        {
            if (validarDatosVuelos())
            {
                ServiciosVuelos serviciosVuelos = new ServiciosVuelos
                {
                    PaisDestino = txtPais.Text,
                    Descripcion = txtServicio.Text,
                    Precio = txtPrecio.Text,
                    DiaSalida = txtDiaSalida.Text,
                    HoraSalida = txtHoraSalida.Text,
                };
                await App.SQLiteDB.SaveVuelosAsync(serviciosVuelos);
                txtPais.Text = "";
                txtServicio.Text = "";
                txtPrecio.Text = "";
                txtDiaSalida.Text = "";
                txtHoraSalida.Text = "";
                await DisplayAlert("Registro", "Se registro el vuelo correctamente", "Ok");

            }
            else
            {
                await DisplayAlert("Advertencia", "Porfavor Ingresar todos los Datos", "Ok");
            }
            
        }
        //Validar Datos
        public bool validarDatosVuelos()
        {
            bool respuesta;
            if (string.IsNullOrEmpty(txtPais.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtServicio.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtPrecio.Text))
            {
                respuesta = false;
            }
            else
            {
                respuesta = true;
            }
            return respuesta;
        }

        private async void btnVolver_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}