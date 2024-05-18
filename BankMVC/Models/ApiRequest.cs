using static BankMVC.Models.StaticDetails;

namespace BankMVC.Models
{
    public class ApiRequest
    {
        public ApiType ApiType { get; set; } = StaticDetails.ApiType.GET;
        public string BaseUrl { get; set; }
        public object Data { get; set; }
    }


}
