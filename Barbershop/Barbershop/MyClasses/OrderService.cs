using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Barbershop.MyClasses
{
    public static class OrderService
    {
        private static string linq = "/api/Order";
        public static async Task<List<Order>> GetOrders()
        {
            var request = await ServerRequest.Request(linq, HttpMethod.Get);
            if (request != null)
                return JsonConvert.DeserializeObject<List<Order>>(request);
            return null;
        }
        public static async Task<string> PostOrders(Order order)
        {
            var request = await ServerRequest.Request(linq, HttpMethod.Post, order);
            if (request != null)
                return request;
            return null;
        }
        public static async Task<string> PutOrders(Order order)
        {
            var request = await ServerRequest.Request(linq, HttpMethod.Put, order);
            if (request != null)
                return request;
            return null;
        }
        public static async Task<string> DeleteOrders(int id)
        {
            var request = await ServerRequest.Request(linq + $"/id={id}", HttpMethod.Delete);
            if (request != null)
                return request;
            return null;
        }
    }
}
