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
    public partial class GetUser : ContentPage
    {
        public GetUser()
        {
            InitializeComponent();
        }

        private async void Showuserlist_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new ViewUserDetails()));
            
        }

        private async void Showticketlist_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new ViewTicketPage()));
        }
    }
}