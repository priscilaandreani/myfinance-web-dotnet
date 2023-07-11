
using myfinance_web_netcore.Domain;

namespace myfinance_web_netcore.Repository.Interfaces
{
    public interface IAccountRepository
    {
        List<Account> Accounts();
    }
}