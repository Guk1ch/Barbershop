using Barbershop.MyClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Barbershop.MyPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Authorization : ContentPage
    {
        public Authorization()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (entryLogin.Text == "admin" && entryPassword.Text == "adminPas")
            {
                await Navigation.PushAsync(new AdminMenu());
            }
            else
            {
                var clients = await ClientService.GetClients();
                if (clients != null)
                {
                    var client = clients.FirstOrDefault(obj => obj.Login == entryLogin.Text && obj.Password == entryPassword.Text);
                    if (client != null)
                    {
                        GetItemStatic.ClientAuth = client;
                        await Navigation.PushAsync(new MainPage());
                    }
                }
            }
        }

        private void Button1_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registration());
        }
    }
}