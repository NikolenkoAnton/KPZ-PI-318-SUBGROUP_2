using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using App.RegularPayments.Interfaces;
using App.RegularPayments.Models;
using App.Configuration;

namespace App.RegularPayments.Repositories
{
    public class RegularPaymentsRepository : IRegularPaymentsRepository, ITransientDependency
    {

        private static IEnumerable<RegularPayment> payments;
        public RegularPaymentsRepository()
        {
            payments = Init.Initialize();
        }
        public void Create(RegularPayment payment)
        {
            payments.Append(payment);
        }

        public RegularPayment Get(int id)
        {
            return payments.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<RegularPayment> GetAll()
        {
            return payments;
        }

        private static class Init
        {
            public static IEnumerable<RegularPayment> Initialize()
            {
                var payment = new RegularPayment { Date = DateTime.Now.AddDays(-1), Description = "test payment", Id = 0, Sum = 10 };
                var payment1 = new RegularPayment { Date = DateTime.Now.AddDays(1), Description = "test payment1", Id = 1, Sum = 100 };
                var payment2 = new RegularPayment { Date =DateTime.Now, Description = "test payment2", Id = 2, Sum = 101 };

                var payments = new List<RegularPayment>();
                payments.Add(payment);
                payments.Add(payment1);
                payments.Add(payment2);

                return payments;
            }

        }
    }
}
