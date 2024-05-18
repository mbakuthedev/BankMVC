using BankMVC.Models;

namespace BankMVC.Services.IService
{
    public interface IBaseService
    {
        ApiResponse responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest request);
    }
}
