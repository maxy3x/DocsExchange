using System.Collections.Generic;
using Domain.Models;

namespace BusinessLogic
{
    public interface IEmployeeBusinessLogic
    {
        void Add(Employee item);
        Employee Get(int id);
        void Update(Employee modifiedItem);
        void Delete(int id);
        IEnumerable<Employee> GetAll();
        List<Employee> GetByStr(string searchStr);
    }
}