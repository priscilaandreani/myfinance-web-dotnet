
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Models;



namespace myfinance_web_netcore.Controllers
{
    [Route("[controller]")]
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

        [HttpGet]
        public IActionResult Index()
        {
            var listAccount = _myFinanceDbContext.Account;

            var listAccountModel = new List<AccountModel>();

            foreach (var item in listAccount)
            {
                var accountModel = new AccountModel()
                {
                    Id = item.Id,
                    Description = item.Description,
                    Type = item.Type,
                };
                listAccountModel.Add(accountModel);
            }

            ViewBag.ListAccount = listAccountModel;
            return View();
        }


        [HttpGet]
        [Route("Register")]
        [Route("Register/{id}")]
        public IActionResult Register(int? id)
        {

            var account = new AccountModel();

            if (id != null)
            {
                var accountDomain = _myFinanceDbContext.Account.Where(x => x.Id == id).FirstOrDefault();

                account.Id = accountDomain.Id;
                account.Description = accountDomain.Description;
                account.Type = accountDomain.Type;
            }

            return View(account);
        }

        [HttpPost]
        [Route("Register")]
        [Route("Register/{id}")]
        public IActionResult Register(AccountModel input)
        {
            var account = new Account()
            {
                Id = input.Id,
                Description = input.Description,
                Type = input.Type,
            };

            if (account.Id == null)
            {
                _myFinanceDbContext.Account.Add(account);
            }
            else
            {
                _myFinanceDbContext.Account.Attach(account);
                _myFinanceDbContext.Entry(account).State = EntityState.Modified;
            }

            _myFinanceDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}