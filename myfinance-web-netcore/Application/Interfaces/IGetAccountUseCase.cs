using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Application.Interfaces
{
    public interface IGetAccountUseCase
    {
        List<AccountModel> GetListAccountModel();
    }
}