using System;
using System.Collections.Generic;
using System.Text;

namespace App.Loans.Models
{
    public class Loan
    {
        private double money;//денежки
        public int time { get; set; }//кол-во платежей (ежемесячных)
        public double money_taked { get; set; }//скок взял
        public double money_back { get; set; }//скок вернул
        public double money_left { get { return money; } set { money = money_taked + (money_taked * (time/12) *percent) - money_back; } } //скок осталось вернуть 
        public double percent { get; set; }//процентная ставка/годовых
        public Loan(double money_take, double percent, int time)
        {
            this.time = time;
            this.money_taked = money_take;
            this.percent = percent;
            this.money_back = 0;
            money = money_taked + (money_taked * (time / 12) * percent) - money_back;
        }
        public void get_money_back(int money)
        {
            if(money>=money_left/time)
            money_back += money;
        }

        public override string ToString()
        {
            return "Money taked: " + money_taked + "for time: " + time + "month by " + percent + " percent";
        }
    }
}
