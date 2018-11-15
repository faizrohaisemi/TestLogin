using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TestLogin.Controller;
using TestLogin.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestLogin.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ViewUserDetails : ContentPage
	{
        public string token = "";

        public ViewUserDetails ()
		{
			InitializeComponent ();
            
            if (Application.Current.Properties.ContainsKey("login_token"))
            {
                token = Application.Current.Properties["login_token"] as string;
            }
            string url = "https://sapura.api.simdesk.co/users";

            ViewUserCtrl controller = new ViewUserCtrl();
            var usermodel = controller.GetUser(url, token);
           


            Debug.WriteLine("On VIEW USER DETAILS PAGE "+  usermodel);
            



        }
        
    }
}