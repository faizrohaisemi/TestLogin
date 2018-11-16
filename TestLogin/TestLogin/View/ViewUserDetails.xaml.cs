﻿using Newtonsoft.Json;
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
        public object store;

        

        public  ViewUserDetails ()
		{
			InitializeComponent ();
            


            if (Application.Current.Properties.ContainsKey("login_token"))
            {
                token = Application.Current.Properties["login_token"] as string;
            }
            sortinfo();
            
        }

        public async  void sortinfo()
        {

            string url = "https://sapura.api.simdesk.co/users";

            ViewUserCtrl controller = new ViewUserCtrl();
            UserListModel.RootObject usermodel = await controller.GetUser(url, token);


            var listView = new ListView();

            listView.HasUnevenRows = true;


            //int loop = 0;
            List<UserListModel.Datum> userlist = new List<UserListModel.Datum>();
            foreach (var item in usermodel.data)
            {
                int id = item.id;
                string username = item.username;
                string fullname = item.fullname;
                string email = item.email;
                string group_id = item.group_id;
                int tenant_id = item.tenant_id;

                userlist.Add(item);

                listview_user.ItemsSource = userlist;

            }
            //listView.ItemsSource = userlist;

            listView.ItemTapped += async (sender, e) => {
                await DisplayAlert("Tapped", e.Item + " row was tapped", "OK");
                Debug.WriteLine("Tapped: " + e.Item);
                ((ListView)sender).SelectedItem = null; // de-select the row
            };


            Padding = new Thickness(0,20,0,0);
            //Content = listView;






            Debug.WriteLine("On VIEW USER DETAILS PAGE " + usermodel);

        }

        void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e == null) return; // has been set to null, do not 'process' tapped event
            Debug.WriteLine("Tapped: " + e.Item);
            ((ListView)sender).SelectedItem = null; // de-select the row
        }
    }
}