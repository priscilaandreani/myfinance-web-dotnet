
using Microsoft.AspNetCore.Mvc;
using myfinance_web_netcore.Models;



namespace myfinance_web_netcore.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly MyFinanceDbContext _myFinanceDbContext;

        public AccountController(ILogger<AccountController> logger,
            MyFinanceDbContext myFinanceDbContext)
        {
            _logger = logger;
            _myFinanceDbContext = myFinanceDbContext;
        }

        public IActionResult Index()
        {
            var listAccount = _myFinanceDbContext.Account;

            var listAccountModel = new List<AccountModel>();

            foreach (var item in listAccount)
            {
                var accountModel = new AccountModel(){
                    Id = item.Id,
                    Description = item.Description,
                    Type = item.Type,
                };
                listAccountModel.Add(accountModel);           
            }
            
            ViewBag.ListAccount = listAccountModel;
            return View();
        }


        public IActionResult Register()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}