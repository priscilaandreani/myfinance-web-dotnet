using myfinance_web_netcore.Application.Interfaces;
using myfinance_web_netcore.Models;
using myfinance_web_netcore.Services.Interfaces;

namespace myfinance_web_netcore.Application.GetAccountUseCase
{
  public class GetAccountUseCase : IGetAccountUseCase
  {

    private readonly IAccountService _accountService;
    public GetAccountUseCase(IAccountService accountService)
    {
      _accountService = accountService;
    }

    public List<AccountModel> GetListAccountModel()
    {
      return _accountService.ListAccountModel();
    }
  }
}