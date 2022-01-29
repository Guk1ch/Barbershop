using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Barbershop.MyClasses
{
    public static class ClientService
    {
        private static string linq = "/api/Client";
        public static async Task<List<Client>> GetClients()
        {
            var request = await ServerRequest.Request(linq, HttpMethod.Get);
            if (request != null)
                return JsonConvert.DeserializeObject<List<Client>>(request);
            return null;
        }
        public static async Task<string> PostClients(Client client)
        {
            var request = await ServerRequest.Request(linq, HttpMethod.Post, client);
            if (request != null)
                return request;
            return null;
        }
    }
}
