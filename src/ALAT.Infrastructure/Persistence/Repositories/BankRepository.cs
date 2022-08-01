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
        public async Task<BankResponse> GetAllBanks(string url)
        {
            var resData = new BankResponse();

            if (string.IsNullOrWhiteSpace(url))
            {
                resData.status = 500;
                resData.message = "Invalid Request URI";
            }
            else
            {
                using var client = new HttpClient();
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResult = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Bank>(jsonResult);

                    resData.message = "success";
                    resData.data = result;
                }
                else
                {
                    resData.message = response.ReasonPhrase;
                }

                resData.status = (int)response.StatusCode;
            }
            
            return resData;
        }
    }
}
