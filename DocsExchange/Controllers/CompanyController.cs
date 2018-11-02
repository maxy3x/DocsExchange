using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
using DocsExchange.Models;
using DocsExchange.Models.Filters;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace DocsExchange.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyBusinessLogic _companyBusinessLogic;
        private readonly IContractsBusinessLogic _contractsBusinessLogic;

        public CompanyController(ICompanyBusinessLogic companyBusinessLogic, IContractsBusinessLogic contractsBusinessLogic)
        {
            _companyBusinessLogic = companyBusinessLogic;
            _contractsBusinessLogic = contractsBusinessLogic;
        }

        public IActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated == true)
            {
                ViewBag.Data = _companyBusinessLogic.GetActive().ToList();
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
            return View(company);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Company company)
        {
            try
            {
                _companyBusinessLogic.Update(company);
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
            return View(company);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Company company)
        {
            try
            {
                if ((_contractsBusinessLogic.GetByPartner(_companyBusinessLogic.Get(id)) == null)
                    && (_contractsBusinessLogic.GetByCompany(_companyBusinessLogic.Get(id)) == null))
                {
                    _companyBusinessLogic.Delete(id);
                    return RedirectToAction(nameof(Index));
                }
                return View(_companyBusinessLogic.Get(id));
            }
            catch
            {
                return View(_companyBusinessLogic.Get(id));
            }
        }

        public ActionResult Details(int id)
        {
            var company = _companyBusinessLogic.Get(id);
            return View(company);
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
            
            ViewBag.Data = companies.OrderBy(x => x.Name).ToList();
            return View(nameof(Index));
        }
        private bool FilterByName(Company @event, string companyFilter)
        {
            if (String.IsNullOrEmpty(companyFilter))
                return true;
            if (@event.Name == null)
                return false;
            var company = _companyBusinessLogic.GetByName(@event.Name);
            if (company.Name.Contains(companyFilter))
                return true;
            return false;
        }
    }
}