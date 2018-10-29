using FaceLoginApp.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FaceLoginApp.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaCrearEmpresa : ContentPage
    {
        public PaginaCrearEmpresa()
        {
            InitializeComponent();
        }

        //void Loading(bool mostrar)
        //{
        //    indicator.IsEnabled = mostrar;
        //    indicator.IsRunning = mostrar;
        //}

        async void btnCrearEmpresa_Clicked(object sender, EventArgs e)

        {

            var nombreEmpresa = txtNombreEmpresa.Text;
            var nombreArea = txtArea.Text;
            var descripcion = txtDescripcion.Text;


            if (string.IsNullOrEmpty(nombreEmpresa))
            {
                await DisplayAlert("Incorrecto", "Digite nombre de Empresa", "OK");
            }
            else if (string.IsNullOrEmpty(nombreArea))
            {
                await DisplayAlert("Incorrecto", "Digite nombre de Area", "OK");
            }
            else
            if (await ServicioFace.CrearGrupoEmpleados(nombreEmpresa, nombreArea, descripcion))
            {
                await DisplayAlert("Correcto", "Empresa creada correctamente", "OK");
                await Navigation.PushAsync(new PaginaRegistro());
            }
            else
            {
                await DisplayAlert("Error", "Error al crear empresa", "OK");
            }

        }

        async void btnLogin_Clicked(object sender, EventArgs e)

        {
            await Navigation.PushAsync(new PaginaLogin());
        }

        void Loading(bool mostrar)
        {
            Indicador.IsEnabled = mostrar;
            Indicador.IsRunning = mostrar;
            lblLoading.IsVisible = mostrar;
        }



        //async void btnLogin_Clicked(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Loading(true);
        //        var foto = await ServicioImagen.TomarFoto();

        //        if (foto != null)
        //        {
        //            imagen.Source = ImageSource.FromStream(foto.GetStream);

        //            var faceId = await ServicioFace.DetectarRostro(foto.GetStream());
        //            var personId = await ServicioFace.IdentificarEmpleado(faceId);

        //            if (personId != Guid.Empty)
        //            {
        //                var bd = new ServicioBaseDatos();
        //                var usuario = await bd.ObtenerUsuario(personId.ToString());
        //                usuario.FotoActual = foto.Path;

        //                var emocion = await ServicioFace.ObtenerEmocion(foto);
        //                usuario.EmocionActual = emocion.Nombre;
        //                usuario.ScoreActual = emocion.Score;
        //                var update = await bd.ActualizarUsuario(usuario);

        //                await DisplayAlert("Correcto", $"Bienvenido {usuario.Nombre}", "OK");
        //                await Navigation.PushAsync(new PaginaBienvenido(usuario));
        //            }
        //            else
        //            {
        //                await DisplayAlert("Error", "Persona no identificada", "OK");
        //            }
        //        }
        //        else
        //            await DisplayAlert("Error", "No se pudo tomar la fotografía.", "OK");

        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    finally
        //    {
        //        Loading(false);
        //    }
        //}

    }
}