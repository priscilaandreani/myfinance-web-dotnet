using myfinance_web_netcore.Models;
using myfinance_web_netcore.Repository.Interfaces;
using myfinance_web_netcore.Services.Interfaces;

namespace myfinance_web_netcore.Services.Account
{

    public class AccountService : IAccountService
    {

        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public List<AccountModel> ListAccountModel()
        {
            var list = new List<AccountModel>();
            foreach (var item in _accountRepository.Accounts())
            {
                var accountModel = new AccountModel()
                {
                    Id = item.Id,
                    Description = item.Description,
                    Type = item.Type,
                };
                list.Add(accountModel);
            }

            return list;
        }

    }
}