using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace city_game
{
    class copper:resource
    {

        private double mine_yield = 100;

        public copper(double amount_)
        {
            amount = amount_;
        }
        public void set_num_mines(int num)
        {

            amount = mine_yield * num;

        }
    }
}
