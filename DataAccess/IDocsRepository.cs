using System.Collections.Generic;
using Domain.Models;

namespace DataAccess
{
    public interface IDocsRepository
    {
        void Insert(Docs item);
        Docs Get(int id);
        void Update(Docs modifiedItem);
        void Delete(int id);
        IEnumerable<Docs> GetAll();
        IEnumerable<Docs> GetActive();
    }
}