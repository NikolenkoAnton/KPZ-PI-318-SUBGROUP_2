using System;
using App.RegularPayments.Models;
using App.Configuration;
using App.RegularPayments.Interfaces;

namespace App.RegularPayments
{
    public class RegularPaymentsManager : IRegularPaymentsManager, ITransientDependency
    {
        private IRegularPaymentsRepository repository;
        public RegularPaymentsManager(IRegularPaymentsRepository repository)
        {
            this.repository = repository;
        }


        public void AddPayment(RegularPayment payment)
        {
            repository.Create(payment);
        }

        public RegularPayment GetPayment(int id)
        {
            return repository.Get(id);
        }
        public RegularPayment GetNext()
        {
            var payments = repository.GetAll();
            foreach (var payment in payments)
            {
                if (payment.Date > DateTime.Now)
                {
                    return payment;
                }
            }
            return null;
        }
    }
}
