using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Barbershop.MyClasses
{
    public static class ServiceService
    {
        private static string linq = "/api/Service";
        public static async Task<List<Service>> GetServices()
        {
            var request = await ServerRequest.Request(linq, HttpMethod.Get);
            if (request != null)
                return JsonConvert.DeserializeObject<List<Service>>(request);
            return null;
        }
        public static async Task<string> PostServices(Service Service)
        {
            var request = await ServerRequest.Request(linq, HttpMethod.Post, Service);
            if (request != null)
                return request;
            return null;
        }
        public static async Task<string> DeleteServices(int id)
        {
            var request = await ServerRequest.Request(linq + $"/id={id}", HttpMethod.Delete);
            if (request != null)
                return request;
            return null;
        }
    }
}
