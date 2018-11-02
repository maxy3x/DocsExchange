using System.Collections.Generic;
using Domain.Models;

namespace DataAccess
{
    public interface ICompanyRepository
    {
        void Insert(Company item);
        Company Get(int id);
        void Update(Company modifiedItem);
        void Delete(int id);
        IEnumerable<Company> GetAll();
        IEnumerable<Company> GetActive();
        List<Company> GetByStr(string searchStr);
        Company GetByName(string searchStr);
    }
}