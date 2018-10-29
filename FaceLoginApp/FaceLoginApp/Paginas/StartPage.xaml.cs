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
	public partial class StartPage : ContentPage
	{
		public StartPage ()
		{
			InitializeComponent ();
            loadPage();
		}

        async void loadPage()
        {
            Loading(true);
            await Task.Delay(5000);
            Loading(false);
            await Navigation.PushAsync(new TabPageRegister());
        }

        void Loading(bool mostrar)
        {
            Indicador.IsEnabled = mostrar;
            Indicador.IsRunning = mostrar;
        }
    }
}