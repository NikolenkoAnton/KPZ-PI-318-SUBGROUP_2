﻿using System.Collections.Generic;
using App.Configuration;
using App.Repositories;
using AutoMapper;
using App.Loans.Models;
using App.Loans.Repositories;

namespace App.Loans
{
    public interface ILoansManager
    {
        List<Loans> GetList();
        Loans GetItem(int id);
        IEnumerable<string> GetValues();
        double Get_money_left(int id);
    }

    public class LoansManager : ILoansManager
    {
        readonly LoansRepository _repository;

        IMapper MLoan = new MapperConfiguration(cfg => cfg.CreateMap<Loan, Loan>()).CreateMapper();
        
        public List<Loan> GetList() => MLoan.Map<IEnumerable<Loan>, List<Loan>>(_repository.GetAll());

        public Loans GetItem(int id) => _repository.Get(id);

        public LoansManager(LoansRepository repository)
        {
            _repository = repository;
        }

        public double Get_money_left(int id)
        {
           return _repository.Get(id).money_left;
        }

        public IEnumerable<string> GetValues()
        {
            return _repository.GetInfo();
        }
    }
}
