using System;
using System.Collections.Generic;
using ClimaApp.Clases;

using Xamarin.Forms;

namespace ClimaApp.Paginas
{
    public partial class PaginaClim : ContentPage
    {
        public PaginaClim()
        {
            InitializeComponent();
            this.BindingContext = new Clima();
        }

        private async void btnBuscar_Clicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCiudad.Text))
            {
                var clima = await Servicios.ServicioClima.ConsultarClima(txtCiudad.Text);

                if (clima != null)
                {
                    this.BindingContext = clima;
                    btnBuscar.Text = "Buscar nuevamente";
                }
            }
        }

    }
}
