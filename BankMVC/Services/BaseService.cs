using BankMVC.Models;
using BankMVC.Services.IService;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using static BankMVC.Models.StaticDetails;

namespace BankMVC.Services
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;


        public ApiResponse responseModel { get; set; } = new ApiResponse();
        
        public BaseService(IHttpClientFactory httpClientFactory)
        {
            
            _httpClientFactory = httpClientFactory;
        }
        public async Task<T> SendAsync<T>(ApiRequest request)
        {

            try
            {
                ApiResponse response;
                var client = _httpClientFactory.CreateClient("BankApi");
                HttpRequestMessage requestMessage = new HttpRequestMessage();
                requestMessage.Headers.Add("Accept", "application/json");
                requestMessage.RequestUri = new Uri(request.BaseUrl);
                if (request.Data != null)
                {
                    requestMessage.Content = new StringContent(JsonConvert.SerializeObject(request.Data),
                        Encoding.UTF8, "application/json"
                        );
                }
                switch (request.ApiType)
                {
                    case ApiType.POST:
                        requestMessage.Method = HttpMethod.Post;
                        break;

                    case ApiType.PUT:
                        requestMessage.Method = HttpMethod.Put;
                        break;

                    case ApiType.DELETE:
                        requestMessage.Method = HttpMethod.Delete;
                        break;

                    default:
                        requestMessage.Method = HttpMethod.Get;
                        break;
                }

                HttpResponseMessage apiResponse = null;

                apiResponse = await client.SendAsync(requestMessage);

                var content = await apiResponse.Content.ReadAsStringAsync();

                var ApiResp = new ApiResponse
                {
                    Result = content
                };

                var res = JsonConvert.SerializeObject(ApiResp);

                var ApiResponse = JsonConvert.DeserializeObject<T>(res);

                return ApiResponse;
            }
            catch (Exception ex)
            {

                var ErrorResponse = new ApiResponse
                {
                    ErrorMessage = ex.Message,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };

                var res = JsonConvert.SerializeObject(ErrorResponse);
                var ApiResponse = JsonConvert.DeserializeObject<T>(res);

              return ApiResponse;
            }

        }
      
    }
}
