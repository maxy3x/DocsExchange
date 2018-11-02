using System.Collections.Generic;
using DataAccess;
using Domain.Models;

namespace BusinessLogic
{
    public class CompanyBusinessLogic : ICompanyBusinessLogic
    {
        private readonly ICompanyRepository _repository;

        public CompanyBusinessLogic(ICompanyRepository repository)
        {
            _repository = repository;
        }

        public void Add(Company item)
        {
            _repository.Insert(item);
        }

        public Company Get(int id)
        {
            return _repository.Get(id);
        }

        public void Update(Company modifiedItem)
        {
            _repository.Update(modifiedItem);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<Company> GetAll()
        {
            return _repository.GetAll();
        }
        public IEnumerable<Company> GetActive()
        {
            return _repository.GetActive();
        }
        public List<Company> GetByStr(string searchStr)
        {
            return _repository.GetByStr(searchStr);
        }
        public Company GetByName(string searchStr)
        {
            return _repository.GetByName(searchStr);
        }
    }
}