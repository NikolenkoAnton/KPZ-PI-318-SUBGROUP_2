using System;
using System.Collections.Generic;
using System.Text;
using App.Bills.Models;
using App.Configuration;
using App.Repositories;

namespace App.Bills.Repositories
{
    public interface IBillsRepository
    {
        IEnumerable<Bill> GetActiveBillsList();
        IEnumerable<Bill> GetAllBillsList();
        Bill GetBillById(int id);
    }
    public class BillRepository : IBillsRepository, ITransientDependency
    {
       
        private static Bill[] bills = {
            new Bill(34000, "Vasya", "Pupkin"),
            new Bill(17000, "Petro", "Poroshenko"),
            new Bill(7000, "Maria", "Ivanovna"),
            new Bill(-15000, "Anna", "Ivanovna")};

        public IEnumerable<Bill> GetActiveBillsList()
        {
            List<Bill> ActiveBillsList = new List<Bill>();
            for (int i = 0; i < bills.Length; i++)
            {
                if (!bills[i].IsBlocked)
                    ActiveBillsList.Add(bills[i]);
            }
            return ActiveBillsList;
        }

        public IEnumerable<Bill> GetAllBillsList()
        {
            List<Bill> AllBillsList = new List<Bill>();
            for (int i = 0; i < bills.Length; i++)
            {
                 AllBillsList.Add(bills[i]);
            }

            return AllBillsList;
        }

        public Bill GetBillById(int id)
        {
            return bills[id];
        }

        public Bill BlockBill(int id)
        {
            bills[id].IsBlocked = true;
            return bills[id];
        }

        public Bill UnblockBill(int id)
        {
            bills[id].IsBlocked = false;
            return bills[id];
        }
    }
}
