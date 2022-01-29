using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Barbershop.MyClasses
{
    public static class TypeServiceService
    {
        private static string linq = "/api/TypeService";
        public static async Task<List<TypeService>> GetServices()
        {
            var request = await ServerRequest.Request(linq, HttpMethod.Get);
            if (request != null)
                return JsonConvert.DeserializeObject<List<TypeService>>(request);
            return null;
        }
    }
}
