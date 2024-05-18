using System.Net;

namespace BankMVC.Models
{
    public class ApiResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool isSuccessful => ErrorMessage == null;
        public object Result { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class ApiResponse<T> : ApiResponse
    {
        public new T Result { get; set; }
    }
}
