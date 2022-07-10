using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Refactoring.Web.Common;
using Refactoring.Web.Services.Interfaces;

namespace Refactoring.Web.Services
{

    public class ChamberOfCommerceApi : IChamberOfCommerceApi
    {
        private readonly IConfiguration _config;

        public ChamberOfCommerceApi(IConfiguration config)
        {
            _config = config;
        }
        public async Task<DataResult> GetFor(string district)
        {
            using var client = new HttpClient();
            var districtID = District.GetDistrictIDByName(district);
            var baseURL = _config["BaseUrl"].ToString();
            var absoluteURL = baseURL + "/" + districtID;
            var request = new HttpRequestMessage(HttpMethod.Get, absoluteURL);
            var response = client.SendAsync(request);
            var data = await response.Result.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<DataResult>(data);
            return result;
        }
    }

    public struct DataResult
    {
        public int Id { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Title { get; set; }
    }
}