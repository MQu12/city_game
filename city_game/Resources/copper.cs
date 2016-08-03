using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace city_game
{
    class copper:resource
    {

        private static double mine_yield = 100;

        public copper(double amount_)
        {
            amount = amount_;
        }
      
        public static double get_yield()
        {
            return mine_yield;
        }
    }
}
