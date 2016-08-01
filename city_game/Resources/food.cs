using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace city_game
{
    class food : resource
    {

        //increase when fertiliser becomes available
        private double effectiveness = 1;
        private double child_consumption = 1;
        private double adult_consumption = 2;
        private double elderly_consumption = 1.5;
        private double decay_const = 0.4;

        private double consumption_rate;
        private double production_rate;   

        public food(double food_amount)
        {
            amount = food_amount;
        }
        public void consume(int num_children, int num_adults, int num_elderly)
        {
            consumption_rate = num_children * child_consumption 
                + num_adults * adult_consumption 
                + num_elderly * elderly_consumption;
            amount -= consumption_rate;
            if (amount < 0) amount = 0;
        }
        public override void increment(double production)
        {
            production_rate = production;
            amount += production_rate;
        }
        public void decay()
        {
            amount -= decay_const * amount;
        }
        public double get_consumption_rate()
        {
            return consumption_rate;
        }
        public double get_production_rate()
        {
            return production_rate;
        }
        public double get_excess_rate()
        {
            return production_rate - consumption_rate;
        }

    }
}
