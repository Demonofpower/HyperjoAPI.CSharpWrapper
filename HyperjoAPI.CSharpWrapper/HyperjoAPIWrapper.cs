using System;
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
            string returnCall = GetAPICall(HyperjoConstants.CurrVersion, HyperjoConstants.GlobalStatisticsParamValue)
                .Result;

            return JsonConvert.DeserializeObject<GlobalStatistics>(returnCall);
        }

        public GlobalGangStatistics GetGlobalGangStatistics()
        {
            string returnCall =
                GetAPICall(HyperjoConstants.CurrVersion, HyperjoConstants.GlobalGangStatisticsParamValue).Result;

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
            CheckIfPlayerKeyIsSet();

            string returnCall = GetAPICall(HyperjoConstants.CurrVersion, HyperjoConstants.NameParamValue).Result;

            return JsonConvert.DeserializeObject<NameStats>(returnCall);
        }

        public MoneyStats GetMoney()
        {
            CheckIfPlayerKeyIsSet();

            string returnCall = GetAPICall(HyperjoConstants.CurrVersion, HyperjoConstants.MoneyParamValue).Result;

            return JsonConvert.DeserializeObject<MoneyStats>(returnCall);
        }

        public PhoneNumberStats GetPhoneNumber()
        {
            CheckIfPlayerKeyIsSet();

            string returnCall = GetAPICall(HyperjoConstants.CurrVersion, HyperjoConstants.PhoneNumberParamValue).Result;

            return JsonConvert.DeserializeObject<PhoneNumberStats>(returnCall);
        }

        public VehiclesStats GetVehicles()
        {
            CheckIfPlayerKeyIsSet();

            string returnCall = GetAPICall(HyperjoConstants.CurrVersion, HyperjoConstants.VehiclesParamValue).Result;

            return JsonConvert.DeserializeObject<VehiclesStats>(returnCall);
        }

        public ValidCheck GetValid(int ownId)
        {
            CheckIfPlayerKeyIsSet();

            string returnCall = GetAPICall(HyperjoConstants.CurrVersion, HyperjoConstants.ValidParamValue,
                new Tuple<string, string>(HyperjoConstants.CharacterIdParam, ownId.ToString())).Result;

            return JsonConvert.DeserializeObject<ValidCheck>(returnCall);
        }

        private async Task<string> GetAPICall(string version, string requestType,
            params Tuple<string, string>[] additionalParameters)
        {
            var apiCall = BuildAPICall(version, requestType, additionalParameters);

            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(apiCall))
            using (HttpContent content = response.Content)
            {
                var returnString = await content.ReadAsStringAsync();

                var errorObject = JsonConvert.DeserializeObject<ErrorReturn>(returnString);
                if (errorObject != null && errorObject.Error)
                {
                    throw new HttpRequestException("Error: " + errorObject.Error + "|" + "Message: " + errorObject.Message + "|" + "Info: " + errorObject.Info);
                }

                return returnString;
            }
        }

        private string BuildAPICall(string version, string requestType,
            params Tuple<string, string>[] additionalParameters)
        {
            var callString = HyperjoConstants.Endpoint + "?" + HyperjoConstants.VersionParam + "=" + version + "&" +
                             HyperjoConstants.RequestParam + "=" + requestType;

            if (!string.IsNullOrEmpty(currKey))
            {
                callString += "&" + HyperjoConstants.KeyParam + "=" + currKey;
            }

            foreach (var additionalParameter in additionalParameters)
            {
                callString += "&" + additionalParameter.Item1 + "=" + additionalParameter.Item2;
            }

            return callString;
        }

        private void CheckIfPlayerKeyIsSet()
        {
            if (string.IsNullOrWhiteSpace(currKey))
            {
                throw new FormatException("You need to specify a guid-key for this call. Use HyperjoAPIWrapper(KEY) constructor");
            }
        }
    }
}