using System.Collections.Generic;
using Domain.Models;

namespace DataAccess
{
    public interface IEmployeeRepository
    {
        void Insert(Employee item);
        Employee GetById(int? id);
        void Update(Employee modifiedUser);
        void Delete(int id);
        List<Employee> GetByStr(string searchStr);
        IEnumerable<Employee> GetAll();
        IEnumerable<Employee> GetByDepartament(Departament departament);
    }
}