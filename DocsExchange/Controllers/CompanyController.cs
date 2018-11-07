using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoMapper;
using BusinessLogic;
using DocsExchange.Models;
using DocsExchange.Models.Filters;
using DocsExchange.ViewModels;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocsExchange.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CompanyController : Controller
    {
        private readonly ICompanyBusinessLogic _companyBusinessLogic;
        private readonly IContractsBusinessLogic _contractsBusinessLogic;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyBusinessLogic companyBusinessLogic, IContractsBusinessLogic contractsBusinessLogic, IMapper mapper)
        {
            _companyBusinessLogic = companyBusinessLogic;
            _contractsBusinessLogic = contractsBusinessLogic;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated == true)
            {
                ViewBag.Data = _companyBusinessLogic.GetActive().Select(_mapper.Map<CompanyView>);
                return View();
            }
            else
            {
                return RedirectToAction("Error");
            }
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Company company)
        {
            try
            {
                _companyBusinessLogic.Add(company);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            var company = _companyBusinessLogic.Get(id);
            return View(_mapper.Map<CompanyView>(company));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CompanyView company)
        {
            try
            {
                _companyBusinessLogic.Update(_mapper.Map<Company>(company));
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var company = _companyBusinessLogic.Get(id);
            return View(_mapper.Map<CompanyView>(company));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Company company)
        {
            try
            {
                if ((_contractsBusinessLogic.GetByPartner(_companyBusinessLogic.Get(id)).Any()) ||
                    (_contractsBusinessLogic.GetByCompany(_companyBusinessLogic.Get(id)).Any()))
                {
                    var companyView = _mapper.Map<CompanyView>(_companyBusinessLogic.Get(id));
                    companyView.Message = "Компанія використовується!";
                    return View(companyView);
                }
                _companyBusinessLogic.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(_mapper.Map<CompanyView>(_companyBusinessLogic.Get(id)));
            }
        }

        public ActionResult Details(int id)
        {
            var company = _companyBusinessLogic.Get(id);
            return View(_mapper.Map<CompanyView>(company));
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Filter(FilterCompanies filtersEvents)
        {
            var companyFilter = filtersEvents.Name;
            
            var companies = _companyBusinessLogic
                .GetAll()
                .Where(@company =>
                    FilterByName(@company, companyFilter))
                .ToList();
            List<CompanyView> models = new List<CompanyView>();
            foreach (var item in companies)
            {
                models.Add(_mapper.Map<CompanyView>(item));
            }

            ViewBag.Data = models.OrderBy(x => x.Name).ToList();
            return View(nameof(Index));
        }
        private bool FilterByName(Company @event, string companyFilter)
        {
            if (String.IsNullOrEmpty(companyFilter))
                return true;
            if (@event.Name == null)
                return false;
            var company = _companyBusinessLogic.GetByStr(@event.Name).FirstOrDefault();
            if (company != null && company.Name.Contains(companyFilter))
                return true;
            return false;
        }
    }
}