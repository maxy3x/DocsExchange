using System.Collections.Generic;
using System.Linq;
using DataAccess.Context;
using Domain.Models;

namespace DataAccess
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DocsDbContext _context;

        public EmployeeRepository(DocsDbContext context)
        {
            _context = context;
        }

        public void Insert(Employee item)
        {
            Employee newEmployee = new Employee()
            {
                Name = string.Concat(item.FirstName, " ",item.Departament, " ", item.SecondName),
                FirstName = item.FirstName,
                SecondName = item.SecondName,
                Patronymic = item.Patronymic,
                Departament = item.Departament,
                User = item.User,
                IsDeleted = false
            };
            _context.Employee.Add(newEmployee);
            _context.SaveChanges();
        }

        public Employee GetById(int? id)
        {
            var employee = _context.Employee
                .Single(s => s.Id == id);
            return employee;
        }

        public List<Employee> GetByStr(string searchStr)
        {
            return _context.Employee.Where(c => c.Name.Contains(searchStr)).ToList();
        }

        public void Update(Employee modifiedItem)
        {
            _context.Employee.Update(modifiedItem);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var employee = _context.Employee
                .Single(s => s.Id == id);
            employee.IsDeleted = true;
            _context.SaveChanges();
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employee.ToList();
        }
        public IEnumerable<Employee> GetAllActive()
        {
            return _context.Employee.Where(x => x.IsDeleted == false).ToList();
        }
        public IEnumerable<Employee> GetByDepartament(Departament departament)
        {
            return _context.Employee.Where(c => c.Departament == departament.Id).ToList();
        }
    }
}