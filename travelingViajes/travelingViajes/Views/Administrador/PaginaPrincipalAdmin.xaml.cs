﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travelingViajes.Data;
using travelingViajes.Views.Administrador;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace travelingViajes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaPrincipalAdmin : ContentPage
    {
        public PaginaPrincipalAdmin()
        {
            InitializeComponent();
        }

        private async void btnLista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ListaUsuarios());
        }

        private async void btnRegistro_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RegistroVuelos());
        }

        private async void btnListaVuelos_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ListaVuelosA());
        }

        private async void CerrarSesion_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void btnListaVuelosReservados_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ListaVuelosReservados());
        }
    }
}