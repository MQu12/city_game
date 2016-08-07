using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
namespace city_game
{
    class side_menu_mint:side_menu_base
    {        

        public side_menu_mint(city City)
        {
            buttons = new List<side_menu_button>();
            buttons.Add(new demolish_button(sidebar.get_start() + 10, 100));
            buttons.Add(new mint_money_button(sidebar.get_start() + 10, 140, City));
            buttons.Add(new remove_money_button(sidebar.get_start() + 10, 180, ref City));
            buttons.Add(new cancel_button(sidebar.get_start() + 10, 220));

            player_city = City;



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

                buttons[i].Draw(spriteBatch);

            }
            spriteBatch.DrawString(menu_font, "Total goods\nvalue: " + player_city.get_goods_value() + 
                "\n"+player_city.get_money().get_name()+" strength: "+player_city.get_money().get_strength(),
                new Vector2(sidebar.get_start() + 10, 260), Color.Black);
            //Debug.WriteLine("Ningi strength: " + player_city.get_money().get_strength());
        }

    }
}
