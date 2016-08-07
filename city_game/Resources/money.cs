using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace city_game
{
    class money:resource
    {

        private string currency_name;
        private double strength = 1;
               
        public money(double initial_money, string currency_name_)
        {
            amount = initial_money;
            currency_name = currency_name_;
        }
        public double get_strength()
        {
            return strength;
        }
        public void set_strength(double total_goods_value, double total_minted_money)
        {

            if (total_minted_money == 0) strength = 0;
            else strength = total_goods_value / total_minted_money;
            
        }
        public string get_name()
        {
            return currency_name;
        }
        public void set_name(string new_name)
        {
            currency_name = new_name;
        }


    }
}
