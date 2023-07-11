using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Repository.Interfaces;

namespace myfinance_web_netcore.Repository.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly MyFinanceDbContext _myFinanceDbContext;
        public AccountRepository(MyFinanceDbContext myFinanceDbContext)
        {
            _myFinanceDbContext = myFinanceDbContext;
        }
        public List<Account> Accounts()
        {
            return _myFinanceDbContext.Account.ToList();
        }
    }
}