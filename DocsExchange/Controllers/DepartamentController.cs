using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
    public class DepartamentController : Controller
    {
        private readonly IContractsBusinessLogic _contractsBusinessLogic;
        private readonly IDepartamentBusinessLogic _departamentBusinessLogic;
        private readonly IMapper _mapper;

        public DepartamentController(IContractsBusinessLogic contractsBusinessLogic, IMapper mapper, IDepartamentBusinessLogic departamentBusinessLogic)
        {
            _contractsBusinessLogic = contractsBusinessLogic;
            _mapper = mapper;
            _departamentBusinessLogic = departamentBusinessLogic;
        }

        public IActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated == true)
            {
                ViewBag.Data = _departamentBusinessLogic.GetAll().Select(_mapper.Map<DepartamentView>);
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
        public IActionResult Create(Departament dep)
        {
            try
            {
                _departamentBusinessLogic.Add(dep);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            var dep = _departamentBusinessLogic.Get(id);
            return View(_mapper.Map<DepartamentView>(dep));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DepartamentView dep)
        {
            try
            {
                _departamentBusinessLogic.Update(_mapper.Map<Departament>(dep));
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var dep = _departamentBusinessLogic.Get(id);
            return View(_mapper.Map<DepartamentView>(dep));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Departament dep)
        {
            try
            {
                if ((_contractsBusinessLogic.GetByDepartament(_departamentBusinessLogic.Get(id)).Any()))
                {
                    var depView = _mapper.Map<DepartamentView>(_departamentBusinessLogic.Get(id));
                    depView.Message = "Відділ використовується!";
                    return View(depView);
                }
                _departamentBusinessLogic.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(_mapper.Map<DepartamentView>(_departamentBusinessLogic.Get(id)));
            }
        }

        public ActionResult Details(int id)
        {
            var dep = _departamentBusinessLogic.Get(id);
            return View(_mapper.Map<DepartamentView>(dep));
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Filter(FilterDepartaments filtersEvents)
        {
            var depFilter = filtersEvents.Name;
            var deps = _departamentBusinessLogic
                .GetAll()
                .Where(@dep =>
                    FilterByName(@dep, depFilter))
                .ToList();
            List<DepartamentView> models = new List<DepartamentView>();
            foreach (var item in deps)
            {
                models.Add(_mapper.Map<DepartamentView>(item));
            }
            ViewBag.Data = models.OrderBy(x => x.Name).ToList();
            return View(nameof(Index));
        }
        private bool FilterByName(Departament @event, string depFilter)
        {
            if (String.IsNullOrEmpty(depFilter))
                return true;
            if (@event.Name == null)
                return false;
            var dep = _departamentBusinessLogic.GetDepByStr(@event.Name).FirstOrDefault();
            if (dep != null && dep.Name.Contains(depFilter))
                return true;
            return false;
        }
    }
}