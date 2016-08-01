using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace city_game
{
    class population
    {
        
        private List<citizen> people_list;
        private double time_since_birth = 0; //time since last birth        
        private double time_to_birth = 0;
        private int num_citizens = 0;
        private int num_children = 0;
        private int num_adults = 0;
        private int num_elderly = 0;
        private int birth_const = 2;
        private double excess_food=0;
        private double threshold_food_excess = 2;
        private double food_stockpile = 0;
        private double food_decay_const = 0.4;
        private double food_consumption = 0;
        private double food_production = 0;

        public population()
        {

            people_list = new List<citizen>();

        }
        public population(int initial_children, int initial_adults, int initial_elderly)
        {
            
            people_list = new List<citizen>();

            for (int i = 0; i < initial_children; i++) people_list.Add(new citizen(citizen.types.child));
            for (int i = 0; i <initial_adults; i++) people_list.Add(new citizen(citizen.types.adult));
            for (int i = 0; i < initial_elderly; i++) people_list.Add(new citizen(citizen.types.elderly));

            num_adults = initial_adults;
            num_children = initial_children;
            num_elderly = initial_elderly;
            num_citizens = initial_adults + initial_children + initial_elderly;

        }

        public void Update(double available_food)
        {

            food_production = available_food;
            //Debug.WriteLine("------------------");

            for (int i = 0; i < people_list.Count; i++)
            {

                //check type before
                citizen.types previous_type = people_list[i].get_type();

                //Debug.WriteLine(people_list[i].get_type());
                
                //kill citizen if true is returned
                if (people_list[i].Update(excess_food,food_stockpile))
                {

                    //Debug.WriteLine("Killing citizen :'( ");

                    //returns true if citizen dies                    
                    
                    //decrement relevant counters
                    num_citizens--;
                    if (people_list[i].get_type() == citizen.types.child) num_children--;
                    else if (people_list[i].get_type() == citizen.types.adult) num_adults--;
                    else num_elderly--;

                    //remove from list
                    people_list.RemoveAt(i);

                    //element i has been removed so i+1 is now i, decrement i so element is not skipped
                    i--;
                }
                // not killed, so check if they change type
                else
                {
                    //check type after
                    if (previous_type != people_list[i].get_type())
                    {
                        //Debug.WriteLine("Someone grew!");
                        //Debug.WriteLine("From "+previous_type + " to "+people_list[i].get_type());
                        //Debug.WriteLine("Entries in people list:" + people_list.Count);
                        //if there's a change, update relevant counters
                        if (people_list[i].get_type() == citizen.types.adult)
                        {
                            num_adults++;
                            num_children--;
                        }
                        else
                        {
                            num_elderly++;
                            num_adults--;
                        }
                    }         
                }    
            }
            
            //get food consumption
            food_consumption = 2 * num_adults + num_children + 1.5 * num_elderly;

            excess_food = available_food - food_consumption;

            //excess food is added to stockpile
            //this will drain if excess is negative
            food_stockpile += excess_food;
            //food decays exponentially
            food_stockpile -= food_stockpile * food_decay_const;
            //set to 0 if below 0
            if (food_stockpile < 0) food_stockpile = 0;
            
            num_citizens = people_list.Count;

            time_since_birth += 0.001;

            if (num_adults > 1)
            {
                time_to_birth = 1 / (birth_const *(excess_food-threshold_food_excess)* num_adults);

                if (time_since_birth > time_to_birth && excess_food >= threshold_food_excess) birth();
            }
            //Debug.WriteLine("------------------");

        }

        public void birth()
        {
            time_since_birth = 0;
            people_list.Add(new citizen());
            num_citizens++;
            num_children++;

        }
        public int get_population()
        {
            return num_citizens;
        }
        public int get_num_children()
        {
            return num_children;
        }
        public int get_num_adults()
        {
            return num_adults;
        }
        public int get_num_elderly()
        {
            return num_elderly;
        }
        public double get_excess_food()
        {
            return excess_food;
        }
        public double get_food_stockpile()
        {
            return food_stockpile;
        }
        public double get_food_production()
        {
            return food_production;
        }
        public double get_food_consumption()
        {
            return food_consumption;
        }
        public int get_employed_adults()
        {
            return 0;
        }



    }
}
