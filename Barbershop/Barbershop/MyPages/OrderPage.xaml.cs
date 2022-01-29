using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Barbershop.MyClasses;
using System.Collections.ObjectModel;

namespace Barbershop.MyPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderPage : ContentPage
    {
        public OrderPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        protected async override void OnAppearing()
        {
            var services = (await ServiceService.GetServices());
            list.ItemsSource = services;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void lv_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var answer = list.SelectedItem as Service;

            var answerD = await DisplayAlert("Уведомление","Вы хотите преобрести данную услугу?","Да","Нет");
            if (answerD == true)
            {
                GetItemStatic.ClientServices.Add(answer);
                await DisplayAlert("Уведомление", "Выбранный товар находится в корзине", "Ок");
            }
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Korzina());
        }
    }
}