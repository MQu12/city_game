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

        public food(double food_amount)
        {
            amount = food_amount;
        }
    }
}
