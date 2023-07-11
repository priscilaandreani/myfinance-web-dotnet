using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Services.Interfaces
{
    public interface IAccountService
    {
        List<AccountModel> ListAccountModel();
    }
}