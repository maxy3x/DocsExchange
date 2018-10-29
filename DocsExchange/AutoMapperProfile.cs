using System;
using System.Linq;
using AutoMapper;
using BusinessLogic;
using DataAccess.Context;
using DocsExchange.ViewModels;
using Domain.Models;

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
                .ForMember(x => x.Company, c => c.ResolveUsing<CompanyResolverReverse>());
            CreateMap<Contracts, ContractsView>()
                .ForMember(x => x.DepartamentName, c => c.ResolveUsing<DepartamentResolver>())
                .ForMember(x => x.PartnerName, c => c.ResolveUsing<PartnerResolver>())
                .ForMember(x => x.ResponsibleName, c => c.ResolveUsing<ResponsibleResolver>())
                .ForMember(x => x.CompanyName, c => c.ResolveUsing<CompanyResolver>());
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
}