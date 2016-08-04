using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace city_game
{
    class money:resource
    {

        private string currency_name = "Ningi";
        private double strength = 1;

        public money(double initial_money)
        {
            amount = initial_money;
        }
        public double get_strength()
        {
            return strength;
        }
        public void set_strength(double total_goods_value)
        {

            if (amount == 0) strength = 0;
            else strength = total_goods_value / amount;
            
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
