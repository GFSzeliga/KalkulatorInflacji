using NewDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace NewDatabase
{
    public class DbwApiProcessor
    {
        public async Task<IEnumerable<AreaModel>?> LoadDbwDataObszar()
        {
            string url = $"https://api-dbw.stat.gov.pl/api/1.1.0/area/area-area";

            using (HttpResponseMessage response = await DbwApiHelper.DbwApiClient.GetAsync(url))
            {
                IEnumerable<AreaModel>? areaModels = await response.Content.ReadFromJsonAsync<IEnumerable<AreaModel>>();
                return areaModels;

            }
        }
        
        public async Task<IEnumerable<AreaVariable>?> LoadDbwDataObszarTematyczny(int areaVariableId)
        {
            string url = $"https://api-dbw.stat.gov.pl/api/1.1.0/area/area-variable?id-obszaru={areaVariableId}";

            using (HttpResponseMessage response = await DbwApiHelper.DbwApiClient.GetAsync(url))
            {
                IEnumerable<AreaVariable>? areaModels = await response.Content.ReadFromJsonAsync<IEnumerable<AreaVariable>>();
                return areaModels;

            }
        }

    }
}
