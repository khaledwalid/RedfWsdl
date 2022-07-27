using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RedfWsdl.Context.Context;
using RedfWsdl.Shared.Entities;
using RedfWsdl.Shared.Enums;

namespace RedfWsdl.Context.Seeders
{
    public class Seeder
    {
        private readonly RedfWsdlDbContext _context;

        public Seeder(RedfWsdlDbContext context)
        {
            _context = context;
        }

        public async Task SeedData()
        {
            await SeedBanks();
            await SeedBranches();
            await SeedUsers();
            await _context.SaveChangesAsync();
            await SeedCitizenProfile();
            await SeedCrm();
            await SeedDetermination();
            await SeedEmployer();
            await SeedService();
            await _context.SaveChangesAsync();
            await SeedRequests();
            await _context.SaveChangesAsync();
            await SeedLoan();
            await SeedLocation();

            await _context.SaveChangesAsync();
        }

        private async Task SeedRequests()
        {
            var requests = await _context.Requests.AnyAsync();
            var users = await _context.Users.ToListAsync();
            var service = await _context.Services.FirstAsync();
            if (!requests)
            {
                for (var i = 0; i < users.Count; i++)
                {
                    await _context.Requests.AddAsync(new Request
                    {
                        Id = Guid.NewGuid(),
                        RequestStatus = RequestStatus.Approved,
                        UserId = users[i].Id,
                        ServiceId = service.Id,
                        RequestNumber = i == 0 ? 8888 : 9999
                    });
                }
            }
        }

        private async Task SeedService()
        {
            var services = await _context.Services.AnyAsync();
            if (!services)
            {
                await _context.Services.AddRangeAsync(new List<Service>()
                {
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Code = "S1S",
                        NameArabic = "خدمه تحويل القرض",
                        NameEnglish = "Conversion Service"
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Code = "S2S",
                        NameArabic = "خدمه صد رد",
                        NameEnglish = "Go Outgo Service"
                    }
                });
            }
        }

        private async Task SeedLocation()
        {
            var locations = await _context.Locations.AnyAsync();
            if (!locations)
            {
                var users = await _context.Users.ToListAsync();
                foreach (var user in users)
                {
                    await _context.Locations.AddAsync(new Location()
                    {
                        Id = Guid.NewGuid(),
                        Building = "Building",
                        City = "City",
                        District = "District",
                        MailBox = "Mailbox",
                        State = "State",
                        Street = "Street",
                        UserId = user.Id
                    });
                }
            }
        }

        private async Task SeedLoan()
        {
            var loans = await _context.Loans.AnyAsync();
            var users = await _context.Users.ToListAsync();
            var service = await _context.Services.FirstAsync();
            if (!loans)
            {
                for (var i = 0; i < users.Count; i++)
                {
                    await _context.Loans.AddAsync(new Loan()
                    {
                        Id = Guid.NewGuid(),
                        AmountPaid = 5000,
                        BenefitCase = true,
                        ContractNumber =i == 0?  2020 : 1010,
                        ContractStatus = ContractStatus.Approved,
                        IbanNumber = 123456789,
                        InstallmentBenefits = 1000,
                        InstallmentDate = DateTime.UtcNow,
                        RequestNumber = i == 0 ? 9999: 8888,
                        InstallmentNumber = i == 0 ? 3030 : 4040,
                        ServiceId = service.Id,
                        InstallmentValue = 15,
                        MonthlySupport = 30,
                        OriginalInstallment = 6000,
                        PaymentDate = DateTime.UtcNow,
                        SadadInvoiceNumber = 98978,
                        Statement = "Lorem Ibsum",
                        SupportConversionDate = DateTime.UtcNow,
                        UpdateInformationStatus = true,
                        UserId = users[i].Id,

                    });
                }

            }
        }

        private async Task SeedEmployer()
        {
            var employer = await _context.Employers.AnyAsync();
            if (!employer)
            {
                await _context.Employers.AddRangeAsync(new List<Employer>()
                {
                    new Employer()
                    {
                        Name = "جهه عمل حكوميه واحد",
                        Id = Guid.NewGuid()
                    }
                });
            }
        }

        private async Task SeedDetermination()
        {
            var determination = await _context.Determinations.AnyAsync();
            if (!determination)
            {
                await _context.Determinations.AddRangeAsync(new List<Determination>()
                {
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "حساب مقترض"
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "راتب مقترض"
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "راتب كفيل"
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "حساب كفيل"
                    }
                });
            }
        }

        private async Task SeedCrm()
        {
            var crm = await _context.Crm.AnyAsync();
            if (!crm)
            {
                await _context.Crm.AddAsync(new Crm
                {
                    Id = Guid.NewGuid(),
                    ContractNumber = 1010,
                    FundsRecommendation = "Lorem Ibsum Lorem Ibsum Lorem Ibsum Lorem Ibsum",
                    Recommendation = "Lorem Ibsum Lorem Ibsum Lorem Ibsum Lorem Ibsum"
                });
                await _context.Crm.AddAsync(new Crm
                {
                    Id = Guid.NewGuid(),
                    ContractNumber = 2020,
                    FundsRecommendation = "Lorem Ibsum Lorem Ibsum Lorem Ibsum Lorem Ibsum",
                    Recommendation = "Lorem Ibsum Lorem Ibsum Lorem Ibsum Lorem Ibsum"
                });
            }
        }

        private async Task SeedCitizenProfile()
        {
            var strings = new List<string> { "Khder Karawita", "Qabnawy" };
            var profiles = await _context.CitizenProfiles.AnyAsync();
            if (!profiles)
            {
                var users = await _context.Users.ToListAsync();
                for (var i = 0; i < users.Count; i++)
                {
                    await _context.CitizenProfiles.AddAsync(
                        new CitizenProfile
                        {
                            Dependents = 1,
                            FullName = $"{strings[i]}",
                            Gender = Gender.Male,
                            Id = Guid.NewGuid(),
                            LifeStatus = LifeStatus.Alive,
                            MaritalStatus = MaritalStatus.Single,
                            UserId = users[i].Id
                        });
                }
            }
        }

        private async Task SeedUsers()
        {
            var users = await _context.Users.AnyAsync();
            if (!users)
            {
                var parentId = Guid.NewGuid();
                await _context.Users.AddRangeAsync(new List<User>()
                {
                    new()
                    {
                        Id = parentId,
                        BirthDate = DateTime.UtcNow.AddDays(-5),
                        Email = "khderkarawita@redf.com",
                        IdentificationNumber = 12345,
                        NationalId = 100200300,
                        RelationShipStatus = null,
                        Parent = null,
                        Password = "123qwe",
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        BirthDate = DateTime.UtcNow.AddDays(-10),
                        Email = "qabnawy@redf.com",
                        IdentificationNumber = 678910,
                        NationalId = 400500600,
                        RelationShipStatus = RelationShipStatus.Aunt,
                        ParentId = parentId,
                        Password = "123qwe",
                    }
                });
            }
        }

        private async Task SeedBranches()
        {
            var branches = await _context.Branches.AnyAsync();
            if (!branches)
            {
                await _context.Branches.AddRangeAsync(new List<Branch>()
                {
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Code = "BBBC",
                        Location = "El Ryiad",
                        NameArabic = "فرع الرياض",
                        NameEnglish = "El Ryiad Branch"
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Code = "BBBT",
                        Location = "Mccah",
                        NameArabic = "فرع مكه المكرمه",
                        NameEnglish = "Mccah Branch"
                    }
                });
            }
        }

        private async Task SeedBanks()
        {
            var banks = await _context.Banks.AnyAsync();
            if (!banks)
            {
                await _context.Banks.AddAsync(new Bank()
                {
                    BankName = "El Rajhi Bank",
                    Id = Guid.NewGuid()
                });
            }
        }
    }
}