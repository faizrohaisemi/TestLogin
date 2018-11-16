using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLogin.Controller;
using TestLogin.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestLogin.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewTicketPage : ContentPage
    {


        public string token = "";

        public ViewTicketPage()
        {
            InitializeComponent();

            if (Application.Current.Properties.ContainsKey("login_token"))
            {
                token = Application.Current.Properties["login_token"] as string;
            }
            showticket();
        }
        public async void showticket()
        {

            string url = "https://sapura.api.simdesk.co/tickets/1";

            ViewTicket controller = new ViewTicket();
            TicketModel.RootObject getticketmodel = await controller.UpdateTicket(url, token);


            var listView = new ListView();

            listView.HasUnevenRows = true;


            //int loop = 0;
            List<TicketModel.Ticket> ticketlist = new List<TicketModel.Ticket>();
            foreach (var item in getticketmodel.tickets)
            {

                int id = item.id;
                int tenant_id = item.tenant_id;
                string requester = item.requester;
                string mesra_link_log_no = item.mesra_link_log_no;
                string title = item.title;
                DateTime date_created = item.date_created;
                DateTime time_created = item.time_created;
                int created_by = item.created_by;

                ticketlist.Add(item);

                listview_ticket.ItemsSource = ticketlist;

            }
            //listView.ItemsSource = userlist;

            listView.ItemTapped += async (sender, e) => {
                await DisplayAlert("Tapped", e.Item + " row was tapped", "OK");
                Debug.WriteLine("Tapped: " + e.Item);
                ((ListView)sender).SelectedItem = null; // de-select the row
            };


            Padding = new Thickness(0, 20, 0, 0);
            //Content = listView;






            Debug.WriteLine("On VIEW USER DETAILS PAGE " + ticketlist);

        }

        void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e == null) return; // has been set to null, do not 'process' tapped event
            Debug.WriteLine("Tapped: " + e.Item);
            ((ListView)sender).SelectedItem = null; // de-select the row
        }



    }
}

