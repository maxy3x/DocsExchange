using System.Collections.Generic;
using Domain.Models;

namespace DataAccess
{
    public interface IDepartamentRepository
    {
        void Insert(Departament item);
        Departament Get(int id);
        void Update(Departament modifiedItem);
        void Delete(int id);
        IEnumerable<Departament> GetAll();
        List<Departament> GetByStr(string searchStr);
    }
}