using System.Collections.Generic;
using System.Linq;
using DataAccess.Context;
using Domain.Models;

namespace DataAccess
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DocsDbContext _context;

        public CompanyRepository(DocsDbContext context)
        {
            _context = context;
        }

        public void Insert(Company item)
        {
            Company newCompany = new Company()
            {
                Name = item.Name
            };
            _context.Company.Add(newCompany);
            _context.SaveChanges();
        }

        public Company Get(int id)
        {
            var company = _context.Company
                .Single(s => s.Id == id);
            return company;
        }

        public void Update(Company modifiedItem)
        {
            _context.Company.Update(modifiedItem);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var company = _context.Company
                .Single(s => s.Id == id);
            company.IsDeleted = true;
            _context.SaveChanges();
        }
        
        public IEnumerable<Company> GetAll()
        {
            return _context.Company.ToList();
        }

        public IEnumerable<Company> GetActive()
        {
            return _context.Company.Where(c => c.IsDeleted == false).ToList();
        }
        public List<Company> GetByStr(string searchStr)
        {
            return _context.Company.Where(c => c.Name.Contains(searchStr)).ToList();
        }
    }
}