using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLogin.Controller;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestLogin.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		}

        private async void loginbtn_Clicked(object sender, EventArgs e)
        {


            string url = "https://sapura.api.simdesk.co/users/token";
            string username = "jasdy3";
            string password = "admin1234";

            Loginctrl controller = new Loginctrl();
            await controller.GoLogin(url, username, password);

            await Navigation.PushAsync(new NavigationPage(new GetUser()));
        }
        
    }
}