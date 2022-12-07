using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NewDatabase
{
    public static class DbwApiHelper
    {
        public static HttpClient DbwApiClient { get; set; }

        public static void InitializeDwbApiClient()
        {
            DbwApiClient = new HttpClient();

            DbwApiClient.DefaultRequestHeaders.Accept.Clear();
            DbwApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
}
