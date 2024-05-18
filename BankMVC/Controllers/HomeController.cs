
using BankApi.Models;
using BankMVC.Models;
using BankMVC.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Text.Json;

namespace BankMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAccountService _accountService;
        public HomeController(ILogger<HomeController> logger, IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }

        public  IActionResult Index()
        {
           return View();
        }
        
        public  IActionResult Privacy()
        {
            return View();
        }

      
    }
}
