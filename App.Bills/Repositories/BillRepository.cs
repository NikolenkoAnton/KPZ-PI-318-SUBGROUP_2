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
        IEnumerable<String> GetActiveBillsList();
        IEnumerable<String> GetAllBillsList();
        string GetBillById(int id);
    }
    public class BillRepository : IBillsRepository, ITransientDependency
    {
        //костыль в виде статика чтобы сохранялись изменения после пост запроса
        private static Bill[] bills = {
            new Bill(34000, "Vasya", "Pupkin"),
            new Bill(17000, "Petro", "Poroshenko"),
            new Bill(7000, "Maria", "Ivanovna"),
            new Bill(-7, "Anna", "Ivanovna")};

        public BillRepository() {

            
        }

        public IEnumerable<string> GetActiveBillsList()
        {
            List<string> ActiveBillsList = new List<string>();
            for (int i = 0; i < bills.Length; i++)
            {
                if (!bills[i].GetIsBlocked())
                    ActiveBillsList.Add(bills[i].ToString());
            }
            return ActiveBillsList;
        }

        public IEnumerable<string> GetAllBillsList()
        {
            string[] billsStr = new string[4];
            billsStr[0] = bills[0].ToString();
            billsStr[1] = bills[1].ToString();
            billsStr[2] = bills[2].ToString();
            billsStr[3] = bills[3].ToString();
            return billsStr;
        }

        public string GetBillById(int id)
        {
            //TODO out of boundary exception
            bills[id].GetIsBlocked();
            return bills[id].ToString();
        }

        public string BlockBill(int id)
        {
            bills[id].SetIsBlocked(true);
            return bills[id].ToString();
        }

        public string UnblockBill(int id)
        {
            bills[id].SetIsBlocked(false);
            return bills[id].ToString();
        }
    }
}
