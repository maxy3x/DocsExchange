using System;
using System.Collections.Generic;
using DataAccess;
using Domain.Models;

namespace BusinessLogic
{
    public class ContractsBusinessLogic : IContractsBusinessLogic
    {
        private readonly IContractsRepository _repository;
        public ContractsBusinessLogic(IContractsRepository repository)
        {
            _repository = repository;
        }

        public void Add(Contracts item)
        {
            _repository.Insert(item);
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
        public Contracts Get(int id)
        {
            return _repository.Get(id);
        }
        public IEnumerable<Contracts> GetByNumber(string number)
        {
            return _repository.GetByNumber(number);
        }
        public IEnumerable<Contracts> GetActive()
        {
            return _repository.GetActive();
        }
        public IEnumerable<Contracts> GetActiveByDate(DateTime dateStart, DateTime dateEnd)
        {
            return _repository.GetActiveByDate(dateStart, dateEnd);
        }
        public IEnumerable<Contracts> GetAll()
        {
            return _repository.GetAll();
        }
        public IEnumerable<Contracts> GetByDepartament(Departament departament)
        {
            return _repository.GetByDepartament(departament);
        }
        public IEnumerable<Contracts> GetByPartner(Company partner)
        {
            return _repository.GetByPartner(partner);
        }
        public IEnumerable<Contracts> GetByEmployee(Employee employee)
        {
            return _repository.GetByEmployee(employee);
        }
        public void Update(Contracts modifiedItem)
        {
            _repository.Update(modifiedItem);
        }
    }
}
