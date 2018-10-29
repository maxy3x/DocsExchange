using System;
using System.Collections.Generic;
using Domain.Models;

namespace BusinessLogic
{
    public interface IDepartamentBusinessLogic
    {
        void Add(Departament item);
        Departament Get(int id);
        void Update(Departament modifiedItem);
        void Delete(int id);
        IEnumerable<Departament> GetAll();
        List<Departament> GetDepByStr(string searchStr);
    }
}