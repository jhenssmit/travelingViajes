using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace travelingViajes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaUsuarios : ContentPage
    {
        public ListaUsuarios()
        {
            InitializeComponent();
           
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var usuarioList = await App.SQLiteDB.GetUsuarioAsync();
            if (usuarioList != null)
            {
                lsUsuario.ItemsSource = usuarioList;
            }
        }

        private async void btnVolver_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}