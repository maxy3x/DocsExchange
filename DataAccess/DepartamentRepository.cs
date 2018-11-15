using System.Collections.Generic;
using System.Linq;
using DataAccess.Context;
using Domain.Models;

namespace DataAccess
{
    public class DepartamentRepository : IDepartamentRepository
    {
        private readonly DocsDbContext _context;

        public DepartamentRepository(DocsDbContext context)
        {
            _context = context;
        }

        public void Insert(Departament item)
        {
            Departament newDep = new Departament()
            {
                Name = item.Name
            };
            _context.Departament.Add(newDep);
            _context.SaveChanges();
        }

        public Departament Get(int id)
        {
            var departament = _context.Departament
                .Single(s => s.Id == id);
            return departament;
        }

        public void Update(Departament modifiedItem)
        {
            _context.Departament.Update(modifiedItem);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var departament = _context.Departament
                .Single(s => s.Id == id);
            departament.IsDeleted = true;
            _context.SaveChanges();
        }

        public IEnumerable<Departament> GetAll()
        {
            return _context.Departament.Where(x=>x.IsDeleted==false).ToList();
        }

        public List<Departament> GetByStr(string searchStr)
        {
            return _context.Departament.Where(c => c.Name.Contains(searchStr)).ToList();
        }
    }
}