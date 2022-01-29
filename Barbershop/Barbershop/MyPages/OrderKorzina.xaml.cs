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
    public partial class OrderKorzina : ContentPage
    {
        public OrderKorzina()
        {
            InitializeComponent();
            GetItem();
        }

        public async void GetItem()
        {
            List<Service> services = new List<Service>();
            foreach (var item in (await OrderService.GetOrders()).Where(obj => obj.IdClient == GetItemStatic.ClientAuth.IdClient))
            {
                services.Add((Task.Run(async () => await ServiceService.GetServices()).Result).FirstOrDefault(obj => obj.IdService == item.IdService));
            }
            list.ItemsSource = services;
        }

        private async void list_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var answer = list.SelectedItem as Service;
            var answerD = await DisplayAlert("Уведомление", "Вы хотите удалить данную услугу?", "Да", "Нет");
            if (answerD == true)
            {
                var answerF = (await OrderService.GetOrders()).Where(obj => obj.IdClient == GetItemStatic.ClientAuth.IdClient).FirstOrDefault(obj => obj.IdService == answer.IdService);
                if (answerF.Done == false)
                {
                    await OrderService.DeleteOrders(answerF.IdOrder);
                    await DisplayAlert("Уведомление", "Выбранный услуга была удалена", "Ок");
                    GetItem();
                }
                else
                    await DisplayAlert("Уведомление", "Выбранную услугу не возможно удалить так как она уже выполнена", "Ок");
            }
        }
    }
}