using System;
using System.Collections.Generic;
using System.Text;

namespace App.Loans.Models
{
    public class Loan
    {
        private double money;//денежки
        public int time { get; set; }//кол-во платежей (ежемесячных)
        public double moneyTaked { get; set; }//скок взял
        public double moneyBack { get; set; }//скок вернул
        public double moneyLeft { get { return money; } }//скок осталось вернуть 
        public double percent { get; set; }//процентная ставка/годовых
        public Loan(double moneyTake, double percent, int time)
        {
            this.time = time;
            this.moneyTaked = moneyTake;
            this.percent = percent;
            this.moneyBack = 0;
            money = moneyTaked + (moneyTaked * (time / 12) * percent) - moneyBack;
        }
        public void get_money_back(int money)
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
