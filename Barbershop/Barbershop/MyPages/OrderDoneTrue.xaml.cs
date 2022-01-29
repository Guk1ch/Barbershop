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
    public partial class OrderDoneTrue : ContentPage
    {
        public OrderDoneTrue()
        {
            InitializeComponent();
            GetItem();
        }

        public async void GetItem()
        {
            List<Service> services = new List<Service>();
            foreach (var item in (await OrderService.GetOrders()).Where(obj => obj.Done == true))
            {
                services.Add((Task.Run(async () => await ServiceService.GetServices()).Result).FirstOrDefault(obj => obj.IdService == item.IdService));
            }
            list.ItemsSource = services;
        }
    }
}