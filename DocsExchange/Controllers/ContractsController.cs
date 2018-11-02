using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic;
using DataAccess;
using DocsExchange.Models;
using DocsExchange.Models.Filters;
using DocsExchange.ViewModels;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DocsExchange.Controllers
{
    public class ContractsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IDepartamentBusinessLogic _departamentBusinessLogic;
        private readonly IContractsBusinessLogic _contractsBusinessLogic;
        private readonly IEmployeeBusinessLogic _employeeBusinessLogic;
        private readonly ICompanyBusinessLogic _companyBusinessLogic;

        public ContractsController(IContractsRepository repository, IDepartamentBusinessLogic departamentBusinessLogic, IContractsBusinessLogic contractsBusinessLogic, IEmployeeBusinessLogic employeeBusinessLogic, ICompanyBusinessLogic companyBusinessLogic, IMapper mapper)
        {
            _departamentBusinessLogic = departamentBusinessLogic;
            _contractsBusinessLogic = contractsBusinessLogic;
            _employeeBusinessLogic = employeeBusinessLogic;
            _companyBusinessLogic = companyBusinessLogic;
            _mapper = mapper;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Filter(FilterContracts filtersEvents)
        {
            List<ContractsView> models = new List<ContractsView>();
            var dateStartFilter = filtersEvents.DateStart;
            var dateEndFilter = filtersEvents.DateEnd;
            var departamentFilter = filtersEvents.Departament;
            var responsibleFilter = filtersEvents.Responsible;
            var partnerFilter = filtersEvents.Partner;
            var companyFilter = filtersEvents.Comany;
            var numberFilter = filtersEvents.Number;

            var contracts = _contractsBusinessLogic
                .GetAll()
                .Where(@contract =>
                    FilterByDepartament(@contract, departamentFilter)
                    &&
                    FilterByResponsible(@contract, responsibleFilter)
                    &&
                    FilterByPartner(@contract, partnerFilter)
                    &&
                    FilterByCompany(@contract, companyFilter)
                    && 
                    FilterByStartDate(@contract, dateStartFilter)
                    &&
                    FilterByEndDate(@contract, dateEndFilter)
                    &&
                    FilterByNumber(@contract, numberFilter))
                .ToList();
            foreach (var item in contracts)
            {
                models.Add(_mapper.Map<ContractsView>(item));
            }
            
            ViewBag.Data = models.OrderBy(x => x.DateStart).ToList();
            return View(nameof(Index));
        }
        private bool FilterByNumber(Contracts @event, string number)
        {
            if (String.IsNullOrEmpty(number))
                return true;
            if (@event.DocNumber == null)
                return true;
            if (String.Compare(@event.DocNumber,number)>0)
                return true;
            return false;
        }
        private bool FilterByStartDate(Contracts @event, DateTime startDate)
        {
            if (startDate == DateTime.MinValue)
                return true;
            if (@event.DateStart == null)
                return false;
            if (@event.DateStart >= startDate)
                return true;
            return false;
        }
        private bool FilterByEndDate(Contracts @event, DateTime endDate)
        {
            if (endDate == DateTime.MinValue)
                return true;
            if (@event.DateEnd == null)
                return false;
            if (@event.DateEnd <= endDate)
                return true;
            return false;
        }
        private bool FilterByDepartament(Contracts @event, string departamentFilter)
        {
            if (String.IsNullOrEmpty(departamentFilter))
                return true;
            if (@event.Departament == null)
                return false;
            var departament = _departamentBusinessLogic.Get(@event.Departament);
            if (departament.Name.Contains(departamentFilter))
                return true;
            return false;
        }
        private bool FilterByResponsible(Contracts @event, string responsibleFilter)
        {
            if (String.IsNullOrEmpty(responsibleFilter))
                return true;
            if (@event.Responsible == null)
                return false;
            var responsible = _employeeBusinessLogic.Get(@event.Responsible);
            if (responsible.Name.Contains(responsibleFilter))
                return true;
            return false;
        }
        private bool FilterByPartner(Contracts @event, string partnerFilter)
        {
            if (String.IsNullOrEmpty(partnerFilter))
                return true;
            if (@event.Partner == null)
                return false;
            var partner = _companyBusinessLogic.Get(@event.Partner);
            if (partner.Name.Contains(partnerFilter))
                return true;
            return false;
        }
        private bool FilterByCompany(Contracts @event, string companyFilter)
        {
            if (String.IsNullOrEmpty(companyFilter))
                return true;
            if (@event.Company == null)
                return false;
            var company = _companyBusinessLogic.Get(@event.Company);
            if (company.Name.Contains(companyFilter))
                return true;
            return false;
        }
        public IActionResult Index()
        {
            if(HttpContext.User.Identity.IsAuthenticated == true)
            {
                ViewBag.Data = _contractsBusinessLogic.GetActive().Select(_mapper.Map<ContractsView>);
                return View();
            }
            else
            {
                return RedirectToAction("Error");
            }
            //var contracts = _repository.GetAll();
        }
        public ActionResult Create()
        {
            SelectList depsList = new SelectList(_departamentBusinessLogic.GetAll(), "Id", "Name");
            SelectList emploiesList = new SelectList(_employeeBusinessLogic.GetAll(), "Id", "Name");
            SelectList companiesList = new SelectList(_companyBusinessLogic.GetAll(), "Id", "Name");
            ViewData["companiesList"] = companiesList;
            ViewData["partnerList"] = companiesList;
            ViewData["emploiesList"] = emploiesList;
            ViewData["depsList"] = depsList;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContractsView contract)
        {
            try
            {
                if (contract.Files != null)
                    if (contract.Files.ContentType == "application/pdf")
                        { contract.FileName = contract.Files.FileName;}
                _contractsBusinessLogic.Add(_mapper.Map<Contracts>(contract));
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            var contract = _mapper.Map<ContractsView>(_contractsBusinessLogic.Get(id));
            return View(contract);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ContractsView contract)
        {
            try
            {
                if (contract.Files != null)
                    if (contract.Files.ContentType == "application/pdf")
                        {contract.FileName = contract.Files.FileName;}
                    else
                    { return View(); }
                _contractsBusinessLogic.Update(_mapper.Map<Contracts>(contract));
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View();
            }
        }
        public ActionResult Details(int id)
        {
            var contract = _mapper.Map<ContractsView>(_contractsBusinessLogic.Get(id));
            return View(contract);
        }
        public ActionResult Delete(int id)
        {
            var contract = _mapper.Map<ContractsView>(_contractsBusinessLogic.Get(id));
            return View(contract);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ContractsView contracts)
        {
            try
            {
                _contractsBusinessLogic.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public async Task<IActionResult> ShowPdf(int id)
        {
            var model = _contractsBusinessLogic.Get(id);
            return File(model.Files, "application/pdf");
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }
    }
}