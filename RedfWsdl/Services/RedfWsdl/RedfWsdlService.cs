using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RedfWsdl.Context.Interfaces;
using RedfWsdl.Services.RedfWsdl.Models;
using RedfWsdl.Shared.Entities;
using RedfWsdl.Shared.Enums;

namespace RedfWsdl.Services.RedfWsdl
{
    public class RedfWsdlService : IRedfWsdlService
    {
        #region Properties

        private readonly IRepositoryBase<Branch> _branchRepository;
        private readonly IRepositoryBase<Service> _serviceRepository;
        private readonly IRepositoryBase<User> _userRepository;
        private readonly IRepositoryBase<CitizenProfile> _profileRepository;
        private readonly IRepositoryBase<Loan> _loanRepository;
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<Request> _requestRepository;
        private readonly IRepositoryBase<Determination> _determinationRepository;
        private readonly IRepositoryBase<Bank> _bankRepository;
        private readonly IRepositoryBase<Employer> _employerRepository;
        private readonly IRepositoryBase<Location> _locationRepository;

        #endregion

        #region Constructor

        public RedfWsdlService(IRepositoryBase<Branch> branchRepository, IRepositoryBase<Service> serviceRepository,
            IRepositoryBase<User> userRepository, IRepositoryBase<CitizenProfile> profileRepository,
            IRepositoryBase<Loan> loanRepository, IMapper mapper, IRepositoryBase<Request> requestRepository,
            IRepositoryBase<Determination> determinationRepository, IRepositoryBase<Bank> bankRepository,
            IRepositoryBase<Employer> employerRepository, IRepositoryBase<Location> locationRepository)
        {
            _branchRepository = branchRepository;
            _serviceRepository = serviceRepository;
            _userRepository = userRepository;
            _profileRepository = profileRepository;
            _loanRepository = loanRepository;
            _mapper = mapper;
            _requestRepository = requestRepository;
            _determinationRepository = determinationRepository;
            _bankRepository = bankRepository;
            _employerRepository = employerRepository;
            _locationRepository = locationRepository;
        }

        #endregion

        #region Methods

        public void XmlMethod(XElement xml)
        {
            Console.WriteLine(xml.ToString());
        }

        public List<LocationModel> GetWaselLocations(int identificationNumber)
        {
            var user = _userRepository.FindByCondition(a => a.IdentificationNumber == identificationNumber)
                .FirstOrDefaultAsync().Result;
            if (user == null) return null;

            var locations = _locationRepository.FindByCondition(a => a.UserId == user.Id).ToListAsync().Result;
            return _mapper.Map<List<LocationModel>>(locations);
        }

        public List<BankModel> GetBankList()
        {
            var bank = _bankRepository.FindAll().ToListAsync().Result;
            return _mapper.Map<List<BankModel>>(bank);
        }
        public List<DeterminationModel> GetDeterminationList()
        {
            var determination = _determinationRepository.FindAll().ToListAsync().Result;
            return _mapper.Map<List<DeterminationModel>>(determination);
        }
        public List<EmployerModel> GetEmployerList()
        {
            var employer = _employerRepository.FindAll().ToListAsync().Result;
            return _mapper.Map<List<EmployerModel>>(employer);
        }
        public LoanBenefitModel GetLoanBenefit(int identificationNumber)
        {
            var user = _userRepository.FindByCondition(a => a.IdentificationNumber == identificationNumber)
                .FirstOrDefaultAsync().Result;
            if (user == null) return null;
            var loan = _loanRepository.FindByCondition(a => a.UserId == user.Id).FirstOrDefaultAsync()
                .Result;
            return loan == null ? null : new LoanBenefitModel() { BenefitCase = loan.BenefitCase };
        }
        public RequestStatusModel GetRequestStatus(int requestNumber)
        {
            var request = _requestRepository.FindByCondition(a => a.RequestNumber == requestNumber)
                .FirstOrDefaultAsync().Result;
            return request == null ? null : new RequestStatusModel() { RequestStatus = request.RequestStatus };
        }
        public RequestNumberModel CreateRequest(RequestInputModel model)
        {
            var user = _userRepository.FindByCondition(a => a.IdentificationNumber == model.IdentificationNumber)
                .FirstOrDefaultAsync().Result;
            if (user == null) return null;
            var requestNumber = new Random().Next(2000);
            var request = new Request()
            {
                Id = Guid.NewGuid(),
                ServiceId = model.ServiceId,
                RequestNumber = requestNumber,
                RequestStatus = RequestStatus.Approved,
                UserId = user.Id
            };
            _requestRepository.Create(request);

            return new RequestNumberModel() { RequestNumber = requestNumber };
        }
        public LoanUpdateStatusModel GetLoanUpdateStatus(int identificationNumber)
        {
            var user = _userRepository.FindByCondition(a => a.IdentificationNumber == identificationNumber)
                .FirstOrDefaultAsync().Result;
            if (user == null) return null;

            var loan = _loanRepository.FindByCondition(a => a.UserId == user.Id).FirstOrDefaultAsync()
                .Result;
            return loan == null ? null : _mapper.Map<LoanUpdateStatusModel>(loan);
        }
        public SdadInvoiceModel GetSdadInvoice(SdadInvoiceInputModel model)
        {
            var user = _userRepository.FindByCondition(a => a.IdentificationNumber == model.IdentificationNumber)
                .FirstOrDefaultAsync().Result;
            if (user == null) return null;

            var loan = _loanRepository.FindByCondition(a => a.SupportConversionDate == model.SupportConversionDate && a.ServiceId == model.ServiceId).FirstOrDefaultAsync()
                .Result;
            return loan == null ? null : _mapper.Map<SdadInvoiceModel>(loan);
        }

        public LoanStatusModel GetLoanStatus(int requestNumber)
        {
            var loan = _loanRepository.FindByCondition(a => a.RequestNumber == requestNumber).FirstOrDefaultAsync()
                .Result;
            return loan == null ? null : _mapper.Map<LoanStatusModel>(loan);
        }
        public LoanModel GetLoan(int contractNumber)
        {
            var loan = _loanRepository.FindByCondition(a => a.ContractNumber == contractNumber).FirstOrDefaultAsync()
                .Result;
            return loan == null ? null : _mapper.Map<LoanModel>(loan);
        }
        public CitizenProfileModel GetCitizenProfile(int identificationNumber)
        {
            var user = _userRepository.FindByCondition(a => a.IdentificationNumber == identificationNumber)
                .FirstOrDefaultAsync().Result;
            if (user == null) return null;

            var profile = _profileRepository.FindByCondition(a => a.UserId == user.Id).FirstOrDefaultAsync().Result;
            if (profile == null) return null;

            return new CitizenProfileModel
            {
                Gender = profile.Gender,
                LifeStatus = profile.LifeStatus,
                MaritalStatus = profile.MaritalStatus,
                Dependents = profile.Dependents,
                FullName = profile.FullName
            };
        }
        public LoginOutputModel AuthenticateByNationalNumber(int nationalNumber)
        {
            LoginOutputModel profile = null;
            var user = _userRepository.FindByCondition(a => a.NationalId == nationalNumber)
                .FirstOrDefaultAsync().Result;
            if (user != null)
            {
                profile = new LoginOutputModel { BirthDate = user.BirthDate, IdentificationNumber = user.IdentificationNumber };
            }

            return profile;
        }
        public LoginOutputModel Authenticate(LoginModel model)
        {
            LoginOutputModel profile = null;
            var user = _userRepository.FindByCondition(a => a.Email == model.Email && a.Password == model.Password)
                .FirstOrDefaultAsync().Result;
            if (user != null)
            {
                profile = new LoginOutputModel() { BirthDate = user.BirthDate, IdentificationNumber = user.IdentificationNumber };
            }

            return profile;

        }
        public List<BranchModel> GetBranchesList()
        {
            var list = new List<BranchModel>();
            var branches = _branchRepository.FindAll().ToList();
            branches.ForEach(branch =>
            {
                list.Add(new BranchModel
                {
                    Code = branch.Code,
                    Id = branch.Id,
                    Location = branch.Location,
                    NameArabic = branch.NameArabic,
                    NameEnglish = branch.NameEnglish
                });
            });
            return list;
        }
        public List<ServiceModel> GetServicesList()
        {
            var list = new List<ServiceModel>();
            var services = _serviceRepository.FindAll().ToList();
            services.ForEach(service =>
            {
                list.Add(new ServiceModel
                {
                    Code = service.Code,
                    Id = service.Id,
                    NameArabic = service.NameArabic,
                    NameEnglish = service.NameEnglish
                });
            });
            return list;
        }

        #endregion
    }
}