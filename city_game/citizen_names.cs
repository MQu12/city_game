using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace city_game
{
    static class citizen_names
    {

        private static List<string> forenames;
        private static List<string> surnames;
        private static bool initialised = false;      

        private static void intialise_names()
        {
            forenames = new List<string>();
            surnames = new List<string>();

            forenames.Add("Adam");
            forenames.Add("Alison");
            forenames.Add("Bert");
            forenames.Add("Beth");
            forenames.Add("Charlie");
            forenames.Add("Cara");
            forenames.Add("Dave");
            forenames.Add("Dora");
            forenames.Add("Euan");
            forenames.Add("Edith");
            forenames.Add("Fred");
            forenames.Add("Fenchurch");
            forenames.Add("Gareth");
            forenames.Add("Ginny");
            forenames.Add("Harold");
            forenames.Add("Hannah");
            forenames.Add("Ian");
            forenames.Add("Inge");
            forenames.Add("John");
            forenames.Add("Jill");
            forenames.Add("Kyle");
            forenames.Add("Kylie");
            forenames.Add("Luke");
            forenames.Add("Lauren");
            forenames.Add("Mike");
            forenames.Add("Megan");
            forenames.Add("Neil");
            forenames.Add("Natasha");
            forenames.Add("Peter");
            forenames.Add("Petra");
            forenames.Add("Richard");
            forenames.Add("Rosie");
            forenames.Add("Sam");
            forenames.Add("Tom");
            forenames.Add("Tina");

            surnames.Add("Adams");
            surnames.Add("Beeblebrox");
            surnames.Add("Clark");
            surnames.Add("Denman");
            surnames.Add("Edge");
            surnames.Add("Frewin");
            surnames.Add("Godfrey");
            surnames.Add("Hill");
            surnames.Add("Ingle");
            surnames.Add("Jones");
            surnames.Add("Knott");
            surnames.Add("Laurie");
            surnames.Add("Martin");
            surnames.Add("Newman");
            surnames.Add("Powell");
            surnames.Add("Reynolds");
            surnames.Add("Sharp");
            surnames.Add("Trotter");
            surnames.Add("Vallance");
            surnames.Add("Woods");

        }

        public static string get_name(int i, int j)
        {
            if (!initialised) intialise_names();

            string name = forenames[i] + " " + surnames[j];

            return name;
        }
        public static int get_num_forenames()
        {
            if (!initialised) intialise_names();
            return forenames.Count;
        }
        public static int get_num_surnames()
        {
            if (!initialised) intialise_names();
            return surnames.Count;
        }

    }
}
