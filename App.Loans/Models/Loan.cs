using System;
using System.Collections.Generic;
using System.Text;

namespace App.Loans.Models
{
    public class Loan
    {
        public int Id { get; set; }
        private double money { get; set; }//денежки
        public int time { get; set; }//кол-во платежей (ежемесячных)
        public double moneyTaked { get; set; }//скок взял
        public double moneyBack { get; set; }//скок вернул
        public double percent { get; set; }//процентная ставка/годовых        
        public double moneyLeft { get; set; }//скок осталось вернуть 
        public Loan(int id,double moneyTake, double percent, int time)
        {
            this.Id = id;
            this.time = time;
            this.moneyTaked = moneyTake;
            this.percent = percent;
            this.moneyBack = 0;
            money = moneyTaked + (moneyTaked * (time / 12) * percent) - moneyBack;
            this.moneyLeft = money;
        }
        public Loan()
        {
        }
        public void GetMoneyBack(int money)
        {
            if(money>=moneyLeft/time)
            moneyBack += money;
        }

        public override string ToString()
        {
            return "Money taked: " + moneyTaked + "for time: " + time + "month by " + percent + " percent";
        }
    }
}
