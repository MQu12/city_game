using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace city_game
{
    class city
    {
        private string name = "Robeaton";        
        private double total_hapiness;
        private population people;        
        private double new_food;        
        private int num_famrers;
        private double farm_yield=5;
        private food city_food;
        private copper city_copper;
        private money city_money;
        private double city_goods_value;      

        public city()
        {
            people = new population(0, 2, 0);
            city_food = new food(0);
            city_copper = new copper(0);
            city_money = new money(0);
        }

        public void Update(int num_farms, int num_copper_mines)
        {            

            //food update
            num_famrers = people.get_num_adults(); //for now, every adult will be a farmer

            if (num_famrers > num_farms) new_food = num_farms * farm_yield;
            else new_food = num_famrers*farm_yield;            

            city_food.increment(new_food);

            //at each turn, total value of goods is calculated here
            //total value is newly generated food + that carried over from last turn
            city_goods_value = city_food.get_amount() * city_food.get_value();

            city_food.consume(people.get_num_children(), people.get_num_adults(), people.get_num_elderly());
            city_food.decay();
            people.Update(city_food);
            
            //curency strength is determined by those goods produced on this turn
            city_money.set_strength(new_food*city_food.get_value());

            //Debug.WriteLine("Copper: " + city_copper.get_amount());

        }

        public population get_population()
        {
            return people;
        }
        public money get_money()
        {
            return city_money;
        }
        public string get_name()
        {
            return name;
        }
        public food get_food()
        {
            return city_food;
        }
        public copper get_copper()
        {
            return city_copper;
        }
        public double get_goods_value()
        {
            return city_goods_value;
        }
    }
}
