using System;
using System.Collections.Generic;
using Domain.Models;

namespace DataAccess
{
    public interface IContractsRepository
    {
        void Insert(Contracts item);
        Contracts Get(int id);
        void Update(Contracts modifiedItem);
        void Delete(int id);
        IEnumerable<Contracts> GetByNumber(string number);
        IEnumerable<Contracts> GetAll();
        IEnumerable<Contracts> GetActive();
        IEnumerable<Contracts> GetActiveByDate(DateTime dateStart, DateTime dateEnd);
        IEnumerable<Contracts> GetByEmployee(Employee employee);
        IEnumerable<Contracts> GetByDepartament(Departament departament);
        IEnumerable<Contracts> GetByPartner(Company partner);
        IEnumerable<Contracts> GetByCompany(Company company);
    }
}