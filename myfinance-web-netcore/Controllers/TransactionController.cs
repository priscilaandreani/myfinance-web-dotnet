
using System.IO.Compression;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Models;



namespace myfinance_web_netcore.Controllers
{
    [Route("[controller]")]
    public class TransactionController : Controller
    {
        private readonly ILogger<TransactionController> _logger;
        private readonly MyFinanceDbContext _myFinanceDbContext;

        public TransactionController(ILogger<TransactionController> logger,
            MyFinanceDbContext myFinanceDbContext)
        {
            _logger = logger;
            _myFinanceDbContext = myFinanceDbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var listTransaction = _myFinanceDbContext.Transaction.Include(x => x.Account);

            var listTransactionModel = new List<TransactionModel>();

            foreach (var item in listTransaction)
            {
                var accountModel = new AccountModel()
                {
                    Id = item.Account.Id,
                    Description = item.Account.Description,
                    Type = item.Account.Type,
                };

                var transactionModel = new TransactionModel()
                {
                    Id = item.Id,
                    History = item.History,
                    Date = item.Date,
                    Value = item.Value,
                    AccountId = item.AccountId,
                    ItemAccount = accountModel
                };
                listTransactionModel.Add(transactionModel);
            };

            ViewBag.Transactions = listTransactionModel;
            return View();
        }


        [HttpGet]
        [Route("Register")]
        [Route("Register/{id}")]
        public IActionResult Register(int? id)
        {
            var itensAccount = _myFinanceDbContext.Account;
            List<SelectListItem> itemsList = new();

            foreach (var item in itensAccount)
            {
                itemsList.Add(new SelectListItem() { Text = item.Description, Value = item.Id.ToString() });
            }
            var transactionModel = new TransactionModel();

            transactionModel.Accounts = itemsList;

            if (id != null)
            {
                var transaction = _myFinanceDbContext.Transaction.Where(x => x.Id == id).FirstOrDefault();
                transactionModel.Date = transaction.Date;
                transactionModel.History = transaction.History;
                transactionModel.Date = transaction.Date;
                transaction.Value = transaction.Value;
                transaction.AccountId = transaction.AccountId;

            }

            return View(transactionModel);
        }

        [HttpPost]
        [Route("Register")]
        [Route("Register/{id}")]
        public IActionResult Register(TransactionModel input)
        {
            var transaction = new Transaction()
            {
                Id = input.Id,
                History = input.History,
                Date = input.Date,
                Value = input.Value,
                AccountId = input.AccountId,
            };

            if (transaction.Id == null)
            {
                _myFinanceDbContext.Transaction.Add(transaction);
            }
            else
            {
                _myFinanceDbContext.Transaction.Attach(transaction);
                _myFinanceDbContext.Entry(transaction).State = EntityState.Modified;
            }

            _myFinanceDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var transaction = new Transaction() { Id = id };
            _myFinanceDbContext.Transaction.Remove(transaction);
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