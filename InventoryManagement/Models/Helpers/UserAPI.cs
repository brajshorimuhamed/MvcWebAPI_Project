using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace InventoryManagement.Models.Helpers
{
    public class UserAPI
    {
        public HttpClient Initial()
        {
            var clientApi = new HttpClient();
            clientApi.BaseAddress = new Uri("https://localhost:44322/");
            return clientApi;
        }
    }
}
