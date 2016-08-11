using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace city_game
{
    class side_menu_townhall:side_menu_base
    {

        //town hall will hold info about the city, so keep player_city object here
        private static city player_city;

        public side_menu_townhall()
        {
            buttons = new List<side_menu_button>();
            buttons.Add(new show_citizen_list(sidebar.get_start() + 10, 140, player_city.get_population().get_citizens()));            
            buttons.Add(new cancel_button(sidebar.get_start() + 10, 180));
        }

        public override void Update(float mouse_x, float mouse_y)
        {
            for (int i = 0; i < buttons.Count; i++)
            {

                buttons[i].Update(mouse_x, mouse_y);

            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < buttons.Count; i++)
            {

                spriteBatch.DrawString(menu_font, "Town of " + player_city.get_name(), new Vector2(sidebar.get_start() + 10, 100), Color.Black);

                buttons[i].Draw(spriteBatch);

            }

            spriteBatch.DrawString(menu_font, "Farmers: " + player_city.get_population().get_employment()[citizen.occupations.farmer]
                + "\nBuilders: " + player_city.get_population().get_employment()[citizen.occupations.builder],
                new Vector2(sidebar.get_start() + 10, 260), Color.Black);

        }

        public static void set_city(city City)
        {

            player_city = City;

        }
        

    }
}
