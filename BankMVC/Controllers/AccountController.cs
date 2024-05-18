
using AutoMapper;
using BankApi.Models;
using BankMVC.Models;
using BankMVC.Services;
using BankMVC.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BankMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountController(IAccountService accountService, ILogger<AccountController> logger, IMapper mapper)
        {
            _logger = logger;
            _accountService = accountService;
            _mapper = mapper;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Accounts")]
        public async Task<IActionResult> GetAccounts()
        {
            List<GetAccountModel> accounts = new();

            var response = await _accountService.GetAllAccounts<ApiResponse>();

            if (response != null && response.isSuccessful)
            {
                accounts = JsonConvert.DeserializeObject<List<GetAccountModel>>(Convert.ToString(response.Result));
            }
            return View(accounts);
        }

        [HttpGet]
        [Route("getaccountbyid")]

        public async Task<IActionResult> GetAccountById(string accountId)
        
        {
            GetAccountModel account = null;

            var response = await _accountService.GetByAccountId<ApiResponse>(accountId);

           // var acc = (GetAccountModel)response.Result;

            if (response.Result != null && response.isSuccessful)
            {
                 account = JsonConvert.DeserializeObject<GetAccountModel>(Convert.ToString(response.Result));
            }
            return View(account);
        }
    }
}
