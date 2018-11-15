using System.Collections.Generic;
using DataAccess;
using Domain.Models;

namespace BusinessLogic
{
    public class EmployeeBusinessLogic : IEmployeeBusinessLogic
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeBusinessLogic(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public void Add(Employee item)
        {
            _repository.Insert(item);
        }

        public Employee Get(int id)
        {
            return _repository.GetById(id);
        }

        public void Update(Employee modifiedItem)
        {
            _repository.Update(modifiedItem);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _repository.GetAllActive();
        }

        public List<Employee> GetByStr(string searchStr)
        {
            return _repository.GetByStr(searchStr);
        }
        public IEnumerable<Employee> GetByDepartament(Departament departament)
        {
            return _repository.GetByDepartament(departament);
        }
    }
}