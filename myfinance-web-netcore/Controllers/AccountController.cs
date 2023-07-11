
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore.Application.Interfaces;
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Models;



namespace myfinance_web_netcore.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly MyFinanceDbContext _myFinanceDbContext;
        private readonly IGetAccountUseCase _getAccountUseCase;

        public AccountController(ILogger<AccountController> logger,
            MyFinanceDbContext myFinanceDbContext,
            IGetAccountUseCase getAccountUseCase
            )

        {
            _logger = logger;
            _myFinanceDbContext = myFinanceDbContext;
            _getAccountUseCase = getAccountUseCase;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.ListAccount = _getAccountUseCase.GetListAccountModel();
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

        [HttpGet]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var account = new Account() { Id = id };
            _myFinanceDbContext.Account.Remove(account);
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