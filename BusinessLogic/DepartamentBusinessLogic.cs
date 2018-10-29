using System.Collections.Generic;
using DataAccess;
using Domain.Models;

namespace BusinessLogic
{
    public class DepartamentBusinessLogic : IDepartamentBusinessLogic
    {
        private readonly IDepartamentRepository _repository;

        public DepartamentBusinessLogic(IDepartamentRepository repository)
        {
            _repository = repository;
        }

        public void Add(Departament item)
        {
            _repository.Insert(item);
        }

        public Departament Get(int id)
        {
            return _repository.Get(id);
        }

        public void Update(Departament modifiedItem)
        {
            _repository.Update(modifiedItem);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<Departament> GetAll()
        {
            return _repository.GetAll();
        }

        public List<Departament> GetDepByStr(string searchStr)
        {
            return _repository.GetByStr(searchStr);
        }
    }
}