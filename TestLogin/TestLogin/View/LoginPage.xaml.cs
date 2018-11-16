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
            string username = usernametxt.Text; //"jasdy3";
            string password = passwordtxt.Text; //"admin1234";

            

            Loginctrl controller = new Loginctrl();
            string status = await controller.GoLogin(url, username, password);

            if(status == "false")
            {
                await DisplayAlert("Error", "Please Insert Correct Username and Password", "Okay");

            }
            else
            {
                await Navigation.PushAsync(new GetUser());
            }

            
        }
        
    }
}