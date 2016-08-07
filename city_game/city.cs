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
        private string currency = "Ningi";       
        private double total_hapiness;
        private population people;        
        private double new_food;        
        private int num_famrers;
        private double farm_yield=5;
        private food city_food;
        private copper city_copper;
        private money city_money;
        private double total_minted_money = 0;
        private double city_goods_value;
        private grid Grid;
        private Dictionary<citizen.occupations, double> wages = new Dictionary<citizen.occupations, double>();
        private double food_price = 0;

        public city()
        {
            people = new population(0, 2, 0);
            city_food = new food(0);
            city_copper = new copper(0);
            city_money = new money(0,currency);
            wages[citizen.occupations.farmer] = 0.01;           
        }

        public void Update(int num_farms, int num_copper_mines)
        {
            //set jobs
            people.set_jobs();

            //pay workers and charge for food
            if (total_minted_money > 0)
            {
                pay_wages();
                charge_for_food();
            }
            //food update
            num_famrers = people.get_employment()[citizen.occupations.farmer];
            new_food = num_famrers*farm_yield;            

            city_food.increment(new_food);

            //at each turn, total value of goods is calculated here
            //total value is newly generated food + that carried over from last turn
            city_goods_value = city_food.get_amount() * city_food.get_value();

            //calculate price of food
            food_price = total_minted_money / ( city_food.get_amount());

            

            city_food.consume(people.get_num_children(), people.get_num_adults(), people.get_num_elderly());
            city_food.decay();     

            people.Update(city_food);
            
            //curency strength is determined by those goods produced on this turn
            city_money.set_strength(new_food*city_food.get_value(),total_minted_money);

            //Debug.WriteLine("Copper: " + city_copper.get_amount());

        }

        private void pay_wages()
        {
            //farmers
            foreach (citizen person in people.get_citizens())
            {
                if (person.get_occupation() == citizen.occupations.farmer)
                {
                    //pay worker
                    person.pay(wages[citizen.occupations.farmer], currency);
                    //subtract from city money
                    city_money.increment(-wages[citizen.occupations.farmer]);
                }
            }
        }
        private void charge_for_food()
        {
            foreach(citizen person in people.get_citizens())
            {
                if (person.get_type() == citizen.types.child) continue; //children get free food
                double excess = person.charge(food_price, currency); //charge each citizen for food and store the amount unpaid
                city_money.increment(food_price - excess); //increment city money
            }
        }

        public population get_population()
        {
            return people;
        }
        public money get_money()
        {
            return city_money;
        }
        public double get_total_minted_money()
        {
            return total_minted_money;
        }
        public void incremenet_total_minted_money(double change)
        {
            total_minted_money += change;
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
        public void set_grid(grid Grid_)
        {
            Grid = Grid_;
        }
    }
}
