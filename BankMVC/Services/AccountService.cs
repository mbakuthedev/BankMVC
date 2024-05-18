using BankMVC.Models;
using BankMVC.Services.IService;
using System.IO.Pipes;
using System.Text.Json;

namespace BankMVC.Services
{
    public class AccountService : BaseService,IAccountService
    {
       // private readonly IAccountService _accountService;
        private readonly IHttpClientFactory _httpClientFactory;
        private string _bankApiUrl;

        public AccountService(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory)
        {

            _httpClientFactory = httpClientFactory;
            _bankApiUrl= configuration.GetValue<string>("ServiceUrls:BankApi");
            //_accountService = accountService;

        }



        public ApiResponse _responseModel { get; set; } = new();


        public Task<T> GetAllAccounts<T>()
        {
            return SendAsync<T>(new ApiRequest
            {
                ApiType = StaticDetails.ApiType.GET,
                BaseUrl = $"{_bankApiUrl}/api/v3/Account/getaccounts",
               // Data = _responseModel.Result
            });

        }

        public Task<T> GetByAccountId<T>(string accountId)
        {
            return SendAsync<T>(new ApiRequest
            {
                ApiType= StaticDetails.ApiType.GET,
                BaseUrl =  $"{_bankApiUrl}/api/v3/Account/getaccountbyid?Id={accountId}",
               // Data = _responseModel.Result
            });
        }
        public Task<T> GetByAccountNumber<T>(string accountNumber)
        {

            return SendAsync<T>(new ApiRequest
            {
                ApiType = StaticDetails.ApiType.GET,
                BaseUrl = $"{_bankApiUrl}/api/v3/Account/getaccountbynumber?Id={accountNumber}",
                Data = _responseModel.Result
            });
        }

        public Task<T> RegisterAccount<T>(RegisterNewAccountModel model)
        {
            return SendAsync<T>(new ApiRequest
            {
                ApiType = StaticDetails.ApiType.POST,
                BaseUrl = $"{_bankApiUrl}/api/v3/Account/register",
                Data = model
            });
        }

      
    }
}
