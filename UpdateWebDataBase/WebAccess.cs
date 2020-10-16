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
    /// <summary>
    /// Contains a simple method for posting up to PGTtresources.com
    /// </summary>
    public static class WebAccess
    {
        private static string postUrl = "https://phtresources.com/api/readings/";
        /// <summary>
        /// methos takes a reading and sends it to the API at PHTResources.com
        /// </summary>
        /// <param name="reading"></param>
        /// <returns></returns>
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
