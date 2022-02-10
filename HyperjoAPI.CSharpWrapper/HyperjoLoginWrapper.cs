using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HyperjoAPI.CSharpWrapper.DTOs;
using Newtonsoft.Json;

namespace HyperjoAPI.CSharpWrapper
{
    public class HyperjoLoginWrapper
    {
        public Login Login(string characterName, string password, string permissions, string redirect)
        {
            var result = LoginPostCall(characterName, password, permissions, redirect).Result;
            return JsonConvert.DeserializeObject<Login>(result);
        }
        
        private async Task<string> LoginPostCall(string characterName, string password, string permissions, string redirect)
        {
            var values = new Dictionary<string, string>
            {
                { "characterName", characterName },
                { "password", password },
                { "permissions", permissions },
                { "redirect", redirect }
            };

            var data = new FormUrlEncodedContent(values);

            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.PostAsync(HyperjoConstants.LoginEndpoint, data))
            using (HttpContent content = response.Content)
            {
                return await content.ReadAsStringAsync();
            }
        }
    }
}
