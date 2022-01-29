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
    public partial class Korzina : ContentPage
    {
        public Korzina()
        {
            InitializeComponent();
            list.ItemsSource = GetItemStatic.ClientServices;
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            var answerD = await DisplayAlert("Уведомление", "Вы хотите преобрести выбранные товары?", "Да", "Нет");
            if (answerD == true)
            {
                var client = GetItemStatic.ClientAuth;
                foreach (var item in GetItemStatic.ClientServices)
                {
                    await OrderService.PostOrders(new Order 
                    {
                        IdService = item.IdService,
                        Done = false,
                        IdClient = client.IdClient,
                        DateOfCompletion = DateTime.Now.AddDays(1),
                    });
                }
                GetItemStatic.ClientServices = new List<Service>();
                list.ItemsSource = null;
                await DisplayAlert("Уведомление", "Вы успешно приобрели товары, завтра приходите вас будут ждать.", "Ок");
            }
        }

        private async void Button_Clicked_3(object sender, EventArgs e)
        {
            var answerD = await DisplayAlert("Уведомление", "Вы что хотите очистить корзину?", "Да", "Нет");
            if (answerD == true)
            {
                GetItemStatic.ClientServices = new List<Service>();
                list.ItemsSource = null;
                list.ItemsSource = GetItemStatic.ClientServices;
                await DisplayAlert("Уведомление", "Корзина была очищена", "Ок");
            }
        }
    }
}