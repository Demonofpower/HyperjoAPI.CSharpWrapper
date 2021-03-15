using System.Net.Http;
using System.Threading.Tasks;
using HyperjoAPI.CSharpWrapper.DTOs;
using Newtonsoft.Json;

namespace HyperjoAPI.CSharpWrapper
{
    public class HyperjoAPIWrapper
    {
        private readonly string currKey;
        
        public HyperjoAPIWrapper(string key = "")
        {
            currKey = key;
        }
        
        public GlobalStatistics GetGlobalStatistics()
        {
            string returnCall = GetAPICall(HyperjoConstants.CurrVersion, HyperjoConstants.GlobalStatisticsParamValue).Result;

            return JsonConvert.DeserializeObject<GlobalStatistics>(returnCall);
        }

        public GlobalGangStatistics GetGlobalGangStatistics()
        {
            string returnCall = GetAPICall(HyperjoConstants.CurrVersion, HyperjoConstants.GlobalGangStatisticsParamValue).Result;

            return JsonConvert.DeserializeObject<GlobalGangStatistics>(returnCall);
        }

        public Online GetOnline()
        {
            string returnCall = GetAPICall(HyperjoConstants.CurrVersion, HyperjoConstants.OnlineParamValue).Result;

            return JsonConvert.DeserializeObject<Online>(returnCall);
        }

        public FarmingTable GetFarming()
        {
            string returnCall = GetAPICall(HyperjoConstants.CurrVersion, HyperjoConstants.FarmingParamValue).Result;

            return JsonConvert.DeserializeObject<FarmingTable>(returnCall);
        }

        public NameStats GetName()
        {
            string returnCall = GetAPICall(HyperjoConstants.CurrVersion, HyperjoConstants.NameParamValue).Result;

            return JsonConvert.DeserializeObject<NameStats>(returnCall);
        }
        
        public MoneyStats GetMoney()
        {
            string returnCall = GetAPICall(HyperjoConstants.CurrVersion, HyperjoConstants.MoneyParamValue).Result;

            return JsonConvert.DeserializeObject<MoneyStats>(returnCall);
        }

        private async Task<string> GetAPICall(string version, string requestType)
        {
            var apiCall = BuildAPICall(version, requestType);
            
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(apiCall))
            using (HttpContent content = response.Content)
            {
                return await content.ReadAsStringAsync();
            }
        }
        
        private string BuildAPICall(string version, string requestType)
        {
            if (!string.IsNullOrEmpty(currKey))
            {
                return HyperjoConstants.Endpoint + "?" + HyperjoConstants.VersionParam + "=" + version + "&" + HyperjoConstants.RequestParam + "=" + requestType + "&" + HyperjoConstants.KeyParam + "=" + currKey;
            }

            return HyperjoConstants.Endpoint + "?" + HyperjoConstants.VersionParam + "=" + version + "&" + HyperjoConstants.RequestParam + "=" + requestType;
        }
    }
}
