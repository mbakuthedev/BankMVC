using AutoMapper;
using BankApi.Models;
using BankMVC.Models;

namespace BankMVC.Profiles
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Account, UpdateAccountModel>().ReverseMap();

            CreateMap<Account, GetAccountModel>().ReverseMap();

            CreateMap<Transaction,TransactionRequestDto>().ReverseMap();
        }
        
    }
}
