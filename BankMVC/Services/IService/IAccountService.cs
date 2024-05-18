using BankMVC.Models;

namespace BankMVC.Services.IService
{
    public interface IAccountService
    {
        Task<T> GetAllAccounts<T>();

        Task<T> GetByAccountNumber<T>(string accountNumber);
        Task<T> GetByAccountId<T>(string accountId);
        Task<T> RegisterAccount<T> (RegisterNewAccountModel model);
    }
}
