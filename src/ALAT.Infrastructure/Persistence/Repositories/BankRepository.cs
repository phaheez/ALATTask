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
        public async Task<Bank> GetAllBanks(string url, string subscriptionKey)
        {
            var result = new Bank();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Subscription key", subscriptionKey);
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResult = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<Bank>(jsonResult);
                }
            }
            return result;
        }
    }
}
