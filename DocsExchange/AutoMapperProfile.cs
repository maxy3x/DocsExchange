using System;
using System.IO;
using System.Linq;
using AutoMapper;
using BusinessLogic;
using DataAccess.Context;
using DocsExchange.ViewModels;
using Domain.Models;
using Microsoft.AspNetCore.Http;

namespace DocsExchange
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ContractsView, Contracts>()
                .ForMember(x => x.Departament, c => c.ResolveUsing<DepartamentResolverReverse>())
                .ForMember(x => x.Partner, c => c.ResolveUsing<PartnerResolverReverse>())
                .ForMember(x => x.Responsible, c => c.ResolveUsing<ResponsibleResolverReverse>())
                .ForMember(x => x.Company, c => c.ResolveUsing<CompanyResolverReverse>())
                .ForMember(x => x.Files, c => c.ResolveUsing<FileResolverReverse>());
            CreateMap<Contracts, ContractsView>()
                .ForMember(x => x.DepartamentName, c => c.ResolveUsing<DepartamentResolver>())
                .ForMember(x => x.PartnerName, c => c.ResolveUsing<PartnerResolver>())
                .ForMember(x => x.ResponsibleName, c => c.ResolveUsing<ResponsibleResolver>())
                .ForMember(x => x.CompanyName, c => c.ResolveUsing<CompanyResolver>())
                .ForMember(x => x.Files, c => c.ResolveUsing<FileResolverIFormFiles>());
            CreateMap<Company, CompanyView>()
                .ForMember(x => x.Message, c => c.ResolveUsing<MessageResolver>());
            CreateMap<CompanyView, Company>();

        }
    }
    public class DepartamentResolver : IValueResolver<Contracts, ContractsView, string>
    {
        private readonly IDepartamentBusinessLogic _departamentBusinessLogic;
        public DepartamentResolver(IDepartamentBusinessLogic departamentBusinessLogic)
        {
            _departamentBusinessLogic = departamentBusinessLogic;
        }
        public string Resolve(Contracts source, ContractsView destination, string destMember, ResolutionContext context)
        {
            var departament = _departamentBusinessLogic.Get(source.Departament);
            return departament.Name;
        }
    }
    public class DepartamentResolverReverse : IValueResolver<ContractsView, Contracts, int>
    {
        private readonly IDepartamentBusinessLogic _departamentBusinessLogic;
        public DepartamentResolverReverse(IDepartamentBusinessLogic departamentBusinessLogic)
        {
            _departamentBusinessLogic = departamentBusinessLogic;
        }
        public int Resolve(ContractsView source, Contracts destination, int destMember, ResolutionContext context)
        {
            var departament = _departamentBusinessLogic.GetDepByStr(source.DepartamentName).FirstOrDefault();
            return departament.Id;
        }
    }
    public class PartnerResolver : IValueResolver<Contracts, ContractsView, string>
    {
        private readonly ICompanyBusinessLogic _companyBusinessLogic;

        public PartnerResolver(ICompanyBusinessLogic companyBusinessLogic)
        {
            _companyBusinessLogic = companyBusinessLogic;
        }
        public string Resolve(Contracts source, ContractsView destination, string destMember, ResolutionContext context)
        {
            var partner = _companyBusinessLogic.Get(source.Partner);
            return partner.Name;
        }
    }
    public class PartnerResolverReverse : IValueResolver<ContractsView, Contracts, int>
    {
        private readonly ICompanyBusinessLogic _companyBusinessLogic;
        public PartnerResolverReverse(ICompanyBusinessLogic companyBusinessLogic)
        {
            _companyBusinessLogic = companyBusinessLogic;
        }
        public int Resolve(ContractsView source, Contracts destination, int destMember, ResolutionContext context)
        {
            var partner = _companyBusinessLogic.GetByStr(source.PartnerName).FirstOrDefault();
            return partner.Id;
        }
    }
    public class ResponsibleResolver : IValueResolver<Contracts, ContractsView, string>
    {
        private readonly IEmployeeBusinessLogic _employeeBusinessLogic;
        public ResponsibleResolver(IEmployeeBusinessLogic employeeBusinessLogic)
        {
            _employeeBusinessLogic = employeeBusinessLogic;
        }
        public string Resolve(Contracts source, ContractsView destination, string destMember, ResolutionContext context)
        {
            var responsible = _employeeBusinessLogic.Get(source.Responsible);
            return responsible.Name;
        }
    }
    public class ResponsibleResolverReverse : IValueResolver<ContractsView, Contracts, int>
    {
        private readonly IEmployeeBusinessLogic _employeeBusinessLogic;
        public ResponsibleResolverReverse(IEmployeeBusinessLogic employeeBusinessLogic)
        {
            _employeeBusinessLogic = employeeBusinessLogic;
        }
        public int Resolve(ContractsView source, Contracts destination, int destMember, ResolutionContext context)
        {
            var responsible = _employeeBusinessLogic.GetByStr(source.ResponsibleName).FirstOrDefault();
            return responsible.Id;
        }
    }
    public class CompanyResolver : IValueResolver<Contracts, ContractsView, string>
    {
        private readonly ICompanyBusinessLogic _companyBusinessLogic;

        public CompanyResolver(ICompanyBusinessLogic companyBusinessLogic)
        {
            _companyBusinessLogic = companyBusinessLogic;
        }
        public string Resolve(Contracts source, ContractsView destination, string destMember, ResolutionContext context)
        {
            var company = _companyBusinessLogic.Get(source.Company);
            return company.Name;
        }
    }
    public class CompanyResolverReverse : IValueResolver<ContractsView, Contracts, int>
    {
        private readonly ICompanyBusinessLogic _companyBusinessLogic;
        public CompanyResolverReverse(ICompanyBusinessLogic companyBusinessLogic)
        {
            _companyBusinessLogic = companyBusinessLogic;
        }
        public int Resolve(ContractsView source, Contracts destination, int destMember, ResolutionContext context)
        {
            var company = _companyBusinessLogic.GetByStr(source.CompanyName).FirstOrDefault();
            return company.Id;
        }
    }
    public class FileResolverReverse : IValueResolver<ContractsView, Contracts, byte[]>
    {
        public byte[] Resolve(ContractsView source, Contracts destination, byte[] file, ResolutionContext context)
        {
            byte[] fileData = null;
            if (source.Files != null)
            {
                using (var binaryReader = new BinaryReader(source.Files.OpenReadStream()))
                {
                    fileData = binaryReader.ReadBytes((int)source.Files.Length);
                }
            }
            return fileData;
        }
    }
    public class FileResolver : IValueResolver<Contracts, ContractsView, byte[]>
    {
        public byte[] Resolve(Contracts source, ContractsView destination, byte[] file, ResolutionContext context)
        {
            return source.Files;
        }

    }
    public class FileResolverIFormFiles : IValueResolver<Contracts, ContractsView, IFormFile>
    {
        public IFormFile Resolve(Contracts source, ContractsView destination, IFormFile file, ResolutionContext context)
        {
            return null;
        }

    }
    public class MessageResolver : IValueResolver<Company, CompanyView, String>
    {
        public string Resolve(Company source, CompanyView destination, string message, ResolutionContext context)
        {
            var messageNew = "";
            return messageNew;
        }
    }
}