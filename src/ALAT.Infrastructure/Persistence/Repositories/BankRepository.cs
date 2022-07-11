using ALAT.Core.DTOs;
using ALAT.Core.Interfaces;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ALAT.Infrastructure.Persistence.Repositories
{
    public class BankRepository : IBankRepository
    {
        public async Task<BankResponse> GetAllBanks(string url, string subscriptionKey)
        {
            var resData = new BankResponse();
            var result = new Bank();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResult = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<Bank>(jsonResult);

                    resData.status = (int)response.StatusCode;
                    resData.message = "success";
                }
                else
                {
                    resData.message = response.ReasonPhrase;
                }
                
                resData.status = (int)response.StatusCode;
                resData.data = result;
            }
            return resData;
        }
    }
}
