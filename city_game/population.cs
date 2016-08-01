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
        private double threshold_food_excess = 2;
        

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

        public void Update(food city_food)
        {
            //Debug.WriteLine("------------------");

            for (int i = 0; i < people_list.Count; i++)
            {

                //check type before
                citizen.types previous_type = people_list[i].get_type();

                //Debug.WriteLine(people_list[i].get_type());
                
                //kill citizen if true is returned
                if (people_list[i].Update(city_food.get_excess_rate(),city_food.get_amount()))
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
            
            num_citizens = people_list.Count;

            time_since_birth += 0.001;

            if (num_adults > 1)
            {
                time_to_birth = 1 / (birth_const *(city_food.get_excess_rate()-threshold_food_excess)* num_adults);

                if (time_since_birth > time_to_birth && city_food.get_excess_rate() >= threshold_food_excess) birth();
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
        public int get_employed_adults()
        {
            return 0;
        }



    }
}
