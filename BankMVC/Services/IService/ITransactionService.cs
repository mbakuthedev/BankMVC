using BankMVC.Models;

namespace BankMVC.Services.IService
{
    public interface ITransactionService
    {
        Task<T> MakeDeposit<T>(string AccountNumber, string Amount, string Pin);
        Task<T> MakeWithdrawal<T>(string AccountNumber, string Amount, string Pin);
        Task<T> Transfer<T>(string AccountNumber, string DestinationAccount, string Amount, string Pin);
        Task<T> CreateNewTransaction<T>(TransactionRequestDto model);

    }
}
