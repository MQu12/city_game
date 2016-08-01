using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace city_game
{
    abstract class resource
    {

        protected double amount;
        //for use with inflation
        protected double value = 1;

        public void set_amount(double new_amount)
        {
            amount = new_amount;
            return;
        }
        public double get_amount()
        {
            return amount;
        }
        public virtual void increment(double change)
        {
            amount += change;
            return;
        }
        

    }
}
