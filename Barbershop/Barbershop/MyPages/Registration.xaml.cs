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
    public partial class Registration : ContentPage
    {
        public Registration()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (entryAddress.Text.Length != 0 && entryLogin.Text.Length != 0 &&
                entryName.Text.Length != 0 && entryNumberPhone.Text.Length != 0 &&
                entryPassword.Text.Length != 0 && entryPatronymic.Text.Length != 0 &&
                entrySurname.Text.Length != 0 && entryLogin.Text == "admin")
            {
                await ClientService.PostClients(new Client 
                {
                    Address = entryAddress.Text,
                    Login = entryLogin.Text,
                    Password = entryPassword.Text,
                    Name = entryName.Text,
                    NumberPhone = entryNumberPhone.Text,
                    Patronimyc = entryPatronymic.Text,
                    Surname = entrySurname.Text,
                });
                DisplayAlert("Уведомление","Вы успешно зарегистрировали аккаунт","Ок");
                Navigation.PopAsync();
            }
            else
                DisplayAlert("Уведомление", "Вы не ввели все данные или данный логин уже занят", "Ок");
        }

        private async void Button1_Clicked(object sender, EventArgs e)
        {

            var obj = await DisplayAlert("Уведомление", "Вы уверены что хотите выйти из меню регистрации?", "Да","Нет");
            if (obj == true)
            {
                Navigation.PopAsync();
            }
        }
    }
}