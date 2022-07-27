using System.Collections.Generic;
using System.ServiceModel;
using RedfWsdl.Services.RedfWsdl.Models;

namespace RedfWsdl.Services.RedfWsdl
{
    [ServiceContract]
    public interface IRedfWsdlService
    {
        [OperationContract]
        void XmlMethod(System.Xml.Linq.XElement xml);
        [OperationContract]
        List<BranchModel> GetBranchesList();
        [OperationContract]
        List<ServiceModel> GetServicesList();
        [OperationContract]
        LoginOutputModel Authenticate(LoginModel model);
        [OperationContract]
        LoginOutputModel AuthenticateByNationalNumber(int nationalNumber);

        [OperationContract]
        CitizenProfileModel GetCitizenProfile(int identificationNumber);

        [OperationContract]
        LoanModel GetLoan(int contractNumber);

        [OperationContract]
        LoanStatusModel GetLoanStatus(int requestNumber);

        [OperationContract]

        SdadInvoiceModel GetSdadInvoice(SdadInvoiceInputModel model);

        [OperationContract]

        LoanUpdateStatusModel GetLoanUpdateStatus(int identificationNumber);


        [OperationContract]
        RequestNumberModel CreateRequest(RequestInputModel model);


        [OperationContract]
        RequestStatusModel GetRequestStatus(int requestNumber);


        [OperationContract]
        LoanBenefitModel GetLoanBenefit(int identificationNumber);

        [OperationContract]
        List<EmployerModel> GetEmployerList();
        [OperationContract]
        List<DeterminationModel> GetDeterminationList();
        [OperationContract]
        List<BankModel> GetBankList();

        [OperationContract]
        List<LocationModel> GetWaselLocations(int identificationNumber);
    }
}