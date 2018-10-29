using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Context;
using Domain.Models;

namespace DataAccess
{
    public class ContractsRepository : IContractsRepository
    {
        private readonly DocsDbContext _context;

        public ContractsRepository(DocsDbContext context)
        {
            _context = context;
        }
        
        public void Insert(Contracts item)
        {
            Contracts newContract = new Contracts()
            {
                DateStart = item.DateStart,
                DateEnd = item.DateEnd,
                DocNumber = item.DocNumber,
                Departament = _context.Departament.FirstOrDefault(c => c.Id == item.Departament).Id,
                Partner = _context.Company.FirstOrDefault(c => c.Id == item.Partner).Id,
                Attachments = new Attachments[]{
                    new Attachments(){Name = "file"}
                },
                Responsible = _context.Employee.FirstOrDefault(c => c.Id == item.Responsible).Id,
                Company = _context.Company.FirstOrDefault(c => c.Id == item.Company).Id
            };
            _context.Contracts.Add(newContract);
            _context.SaveChanges();
        }
        public Contracts Get(int id)
        {
            var contract = _context.Contracts
                .Single(s => s.Id == id);
            return contract;
        }
        public void Update(Contracts modifiedItem)
        {
            _context.Contracts.Update(modifiedItem);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var contract = _context.Contracts
                .Single(s => s.Id == id);
            contract.IsDeleted = true;
            _context.SaveChanges();
        }

        public IEnumerable<Contracts> GetByNumber(string number)
        {
            return _context.Contracts.Where(c => c.DocNumber.Contains(number)).ToList();
        }
        public IEnumerable<Contracts> GetAll()
        {
            return _context.Contracts.ToList();
        }
        public IEnumerable<Contracts> GetActive()
        {
            return _context.Contracts.Where(c => c.IsDeleted == false).ToList();
        }
        public IEnumerable<Contracts> GetActiveByDate(DateTime dateStart, DateTime dateEnd)
        {
            return _context.Contracts.Where(c => c.DateStart >= dateStart && c.DateEnd <= dateEnd).ToList();
        }
        public IEnumerable<Contracts> GetByEmployee(Employee employee)
        {
            return _context.Contracts.Where(c => c.Responsible == employee.Id).ToList();
        }
        public IEnumerable<Contracts> GetByDepartament(Departament departament)
        {
            return _context.Contracts.Where(c => c.Departament == departament.Id).ToList();
        }
        public IEnumerable<Contracts> GetByPartner(Company partner)
        {
            return _context.Contracts.Where(c => c.Partner == partner.Id).ToList();
        }
    }
}