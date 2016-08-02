using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace city_game
{
    class food : resource
    {
        
                
        private double child_consumption = 1;
        private double adult_consumption = 2;
        private double elderly_consumption = 1;       

        private double consumption_rate;
        private double production_rate;

        //stores the amount of excess food produced up to 10 turns ago
        private List<double> previous_production;   

        public food(double food_amount)
        {
            amount = food_amount;
            previous_production = new List<double>();
            for (int i = 0; i < 10; i++) previous_production.Add(0);
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

            double excess = production_rate - consumption_rate;

            if (excess >= 0)
            {
                previous_production.Add(excess);

                //food from 10 turns ago decays
                amount -= previous_production[0];
                //remove element
                previous_production.RemoveAt(0);
            }
            else
            {
                previous_production.Add(0);
                //food from stockpile is being cosumed
                //citizens always start consuming oldest food first
                for(int i=0; i<10; i++)
                {
                    
                    if (previous_production[i] > -excess)
                    {
                        previous_production[i] += excess;
                        amount += excess;
                        break;
                    }
                    else
                    {
                        excess += previous_production[i];
                        amount -= previous_production[i];
                        previous_production[i] = 0;
                    }
                    
                }

                amount -= previous_production[0];
                if (amount < 0) amount = 0;

                previous_production.RemoveAt(0);

            }



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
