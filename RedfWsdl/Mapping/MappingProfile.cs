using AutoMapper;
using RedfWsdl.Services.RedfWsdl.Models;
using RedfWsdl.Shared.Entities;

namespace RedfWsdl.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Loan, LoanModel>().ReverseMap();
            CreateMap<Loan, LoanStatusModel>().ReverseMap();
            CreateMap<Loan, SdadInvoiceModel>().ReverseMap();
            CreateMap<Loan, LoanUpdateStatusModel>().ReverseMap();
            CreateMap<Bank, BankModel>().ReverseMap();
            CreateMap<Employer, EmployerModel>().ReverseMap();
            CreateMap<Determination, DeterminationModel>().ReverseMap();
            CreateMap<Location, LocationModel>().ReverseMap();
        }
    }
}