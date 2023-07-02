
using Microsoft.AspNetCore.Mvc;


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
            var listAccount = _myFinanceDbContext.Account.;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}