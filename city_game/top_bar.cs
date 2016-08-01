using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace city_game
{
    class top_bar
    {

        public enum options { normal, population, money, food };
        
        public static SpriteFont font;
        private double mouse_x;
        private double mouse_y;
        public static city player_city;
        private bool show_detail = false;
        private options current_option;
        
        public top_bar()
        {

            //not much to call really

        }

        public options mouse_over()
        {

            //if too far down, return normal
            if (mouse_y >= 40)
            {
                show_detail = false;
                return options.normal;
            }
            else if (show_detail) return current_option;
            else {
                show_detail = true;
                if (mouse_x < 320) return options.population;
                if (mouse_x < 520) return options.food;
                else if (mouse_x < 600) return options.money;
                else return options.normal;
            }
        }

        public void Update(double mouse_x_, double mouse_y_)
        {
            mouse_x = mouse_x_;
            mouse_y = mouse_y_;
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            string starvation = "";
            if (player_city.get_population().get_excess_food() < 0 && player_city.get_population().get_food_stockpile()==0) starvation = " Starvation!";

            current_option = mouse_over();

            switch (current_option)
            {
                case options.population:
                    spriteBatch.DrawString(font, "Population: " + player_city.get_population().get_population()
                + " Children: " + player_city.get_population().get_num_children()
                + " Adults: " + player_city.get_population().get_num_adults()
                + " Elderly: " + player_city.get_population().get_num_elderly() + starvation,
                new Vector2(10, 10), Color.Black);
                    break;

                case options.money:
                    spriteBatch.DrawString(font, "Money: " + player_city.get_money() + " Employed adults: -" + "Unemployed adults: -", new Vector2(10, 10), Color.Black);

                    break;

                case options.food:
                    spriteBatch.DrawString(font, "Food production: " + player_city.get_population().get_food_production() +
                        " Food consumption: "+player_city.get_population().get_food_consumption()+
                        " Food stockpile: "+Math.Round(player_city.get_population().get_food_stockpile(),1), new Vector2(10, 10), Color.Black);
                    break;

                default:
                    spriteBatch.DrawString(font, "Population: " + player_city.get_population().get_population() + starvation,
                new Vector2(10, 10), Color.Black);
                    spriteBatch.DrawString(font, "Food: " + player_city.get_population().get_food_production(), new Vector2(320, 10), Color.Black);
                    
                    spriteBatch.DrawString(font, "Money: " + player_city.get_money(), new Vector2(520, 10), Color.Black);
                    break;
            }

        }

    }
}
