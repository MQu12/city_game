using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace city_game
{
    class citizen
    {

        public enum occupations { unemployed, farmer, shop_assistant};
        public enum types { child, adult, elderly}; //0-17 child 18-59 adult 60+ elderly

        private double age = 0;
        private double lifetime;
        private double lifetime_stddev = 10;
        private occupations occupation = occupations.unemployed;
        private types type;
        private static Random random = new Random();
        private string name = "Dave Trotter"; //this will be variable at some point
        private int happiness = 1;
        private double hunger = 0;
       
        //creates a child
        public citizen()
        {
            type = types.child;
            set_lifetime();
            Debug.WriteLine("Lifetime: " + lifetime);

        }
        //create specified type
        public citizen(types type_)
        {
            if (type_ == types.adult)
            {
                age = 18;
                type = types.adult;
                do
                {
                    set_lifetime();
                } while (lifetime < age); //ensure citizen doesn't die straight away
            }
            else if (type_ == types.elderly)
            {
                age = 65;
                type = types.elderly;
                do
                {
                    set_lifetime();
                } while (lifetime < age); //ensure citizen doesn't die straight away                                
            }
            else
            {
                type = types.child;
                age = 0;
                set_lifetime();
            }
            Debug.WriteLine("Lifetime: " + lifetime);

        }

        private void set_lifetime()
        {
            lifetime = 80;
            //copied from stackoverflow
            //generate a random gaussian distributed number
            //lifetime is a Gaussian random variable, mean of 80 std deviation of 10
            double u1 = random.NextDouble(); //these are uniform(0,1) random doubles
            double u2 = random.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                         Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
            lifetime += randStdNormal * lifetime_stddev;

            Debug.WriteLine("Rand: " + randStdNormal);
                        
        }
        
        public void set_occupation(occupations new_occupation)
        {
            if (type == types.adult) ; //set occupation here
            else new_occupation = occupations.unemployed; //only adults can be employed
        }

        public bool kill()
        {
            //kill the citizen once they reach their max age

            if (age < lifetime) return false; //survive
            else return true; // ...sorry
        }

        public bool Update()
        {
            //advance age
            age += 0.1;

            //now check if type needs to change
            if (age < 18) type = types.child;
            else if (age < 65) type = types.adult;
            else type = types.elderly;

            return kill();

        }
        public types get_type()
        {

            return type;

        }
        public double get_food_consumption()
        {
            if (type == types.child) return 1;
            else if (type == types.adult) return 2;
            else return 1.5;
        }
        public int get_happiness()
        {
            return happiness;
        }


    }
}
