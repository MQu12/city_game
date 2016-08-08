using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace city_game
{
    class citizen
    {

        public enum occupations { unemployed, farmer, builder, miner};
        public enum types { child, adult, elderly}; //0-17 child 18-59 adult 60+ elderly

        private double age = 0;
        private double lifetime;
        private double lifetime_stddev = 10;
        private occupations occupation = occupations.unemployed;
        private types type;
        private static Random random = new Random();
        private static Random rand_name = new Random();        
        private string name = "Dave Trotter";
        private int happiness = 1;
        private double hunger = 0;
        private Dictionary<string,money> person_money = new Dictionary<string, money>(); //string stores the name of the currency        
       
        //creates a child
        public citizen()
        {
            type = types.child;
            set_lifetime();
            //Debug.WriteLine("Lifetime: " + lifetime);
            int i = rand_name.Next(0, citizen_names.get_num_forenames());
            int j = rand_name.Next(0, citizen_names.get_num_surnames());

            name = citizen_names.get_name(i, j);

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
            //Debug.WriteLine("Lifetime: " + lifetime);

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

            //Debug.WriteLine("Rand: " + randStdNormal);
                        
        }
        
        public void set_occupation(occupations new_occupation)
        {
            if (type == types.adult) occupation = new_occupation; //set occupation here
            else new_occupation = occupations.unemployed; //only adults can be employed            
        }

        public bool kill()
        {
            //kill the citizen once they reach their max age

            if (age < lifetime) return false; //survive
            else {
                //Debug.WriteLine("Citizen " + name + " died of old age");
                return true; // ...sorry
            }
        }

        public bool Update(double excess_food, double food_stockpile)
        {
            //advance age
            age += 0.1;

            //now check if type needs to change
            if (age < 18) type = types.child;
            else if (age < 65) type = types.adult;
            else type = types.elderly;
                

            //test  death conditions
            //starvation
            if (excess_food < 0 && food_stockpile ==0)
            {
                                
                hunger += 0.01;

                //if hunger is greater than max allowable, kill
                if (hunger > threshold_hunger())
                {
                    Debug.WriteLine("Citizen " + name + " died of starvation");

                    return true;

                }

            }
            //old age
            else if (hunger > 0) hunger -= 0.01;

            return kill();

        }

        public void pay(double amount, string currency)
        {

            if (amount < 0)
            {
                Debug.WriteLine("Error. Negative argument in citizen.pay method.");
                Environment.Exit(1);
            }

            bool paid = false; //true when person has been paid

            foreach(KeyValuePair<string,money> kvp in person_money)
            {
                if(kvp.Key == currency) //currency exists in map
                {
                    person_money[kvp.Key].increment(amount);
                    paid = true; //now paid
                    Debug.WriteLine("Citizen " + name + " was paid " + amount + "N.");
                    break;
                }
            }
            if (!paid) //if not paid, create a new entry in the dictionary
            {
                person_money[currency] = new money(amount, currency);
            }

        }

        public double charge(double amount, string currency) //charge the person
            //returns the amount that hasn't been charged
        {           

            foreach (KeyValuePair<string, money> kvp in person_money)
            {
                if (kvp.Key == currency) //currency exists in map
                {
                    person_money[kvp.Key].increment(-amount);
                    if (person_money[kvp.Key].get_amount() < 0)
                    {
                        double unpaid = -person_money[kvp.Key].get_amount();
                        person_money[kvp.Key].set_amount(0);
                        Debug.WriteLine("Citizen " + name + " was charged " + amount + "N for food, "+unpaid + " unpaid.");
                        return unpaid;
                    }
                    else
                    {
                        Debug.WriteLine("Citizen " + name + " was charged " + amount + "N for food, 0 unpaid.");
                        return 0;
                    }
                }
            }
            Debug.WriteLine("Citizen " + name + " was charged " + amount + "N for food, all unpaid.");
            return amount;
            
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
        public occupations get_occupation()
        {
            return occupation;
        }

        private double threshold_hunger()
        {
            //complicated function to determine max allowable hunger
            double a = -2.45;
            double c = 0.00008;
            double d = 2.49;

            double threshold = 1 + (1 - age / a) * Math.Exp(c * (1 - Math.Pow(age, d)));

            return threshold;
        }


    }
}
