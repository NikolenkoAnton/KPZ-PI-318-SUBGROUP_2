using System.Collections.Generic;
using App.Configuration;
using App.Repositories;
using AutoMapper;
using App.Loans.Models;
using App.Loans.Repositories;

namespace App.Loans.Services
{
    public interface ILoansManager
    {
        List<Loan> GetList();
        Loan GetItem(int id);
        IEnumerable<string> GetValues();
        double GetMoneyLeft(int id);
    }

    public class LoansManager : ILoansManager, ITransientDependency
    {
        readonly LoansRepository _repository;

        IMapper MLoan = new MapperConfiguration(cfg => cfg.CreateMap<Loan, Loan>()).CreateMapper();

        public List<Loan> GetList() => MLoan.Map<IEnumerable<Loan>, List<Loan>>(_repository.GetAll());

        public Loan GetItem(int id) => _repository.Get(id);

        public LoansManager(LoansRepository repository)
        {
            _repository = repository;
        }

        public double GetMoneyLeft(int id)
        {
            return _repository.Get(id).moneyLeft;
        }

        public IEnumerable<string> GetValues()
        {
            return _repository.GetValues();
        }
    }
}
