using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using UpdateWebDataBase.Domain;

namespace UpdateWebDataBase
{
    public static class WebAccess
    {
        private static string postUrl = "https://phtresources.com/api/readings/";
        public static async Task<string> SendToApiAsync(Reading reading)
        {
            var readingJson = JsonConvert.SerializeObject(reading);
            var data = new StringContent(readingJson, Encoding.UTF8, "application/json");
            var client = new HttpClient();
            var response = await client.PostAsync(postUrl, data);
            if (response.IsSuccessStatusCode)
            {
                return $"Success at {DateTime.Now}";
            }
            else
            {
                return $"Failure at {DateTime.Now}";
            }
        }
    }
}
