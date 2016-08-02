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
    class remove_money_button : side_menu_button
    {

        private city player_city;

        public remove_money_button(int x, int y, ref city City)
        {
            x_pos = x;
            y_pos = y;
            player_city = City;
        }

        public override void Update(float mouse_x, float mouse_y)
        {

            if (mouse_over(mouse_x, mouse_y))
            {
                if (Mouse.GetState().LeftButton == ButtonState.Pressed && Game1.previous_mouse_state.LeftButton == ButtonState.Released)
                {

                    player_city.get_money().increment(-10);                    

                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sidebar_menu_button, new Vector2(x_pos, y_pos), Color.White);
            spriteBatch.DrawString(font, "Remove money", new Vector2(x_pos + 10, y_pos), Color.Black);
            if (is_mouse_over)
            {

                spriteBatch.Draw(highlighter, new Vector2(x_pos, y_pos), Color.White);

            }
        }

    }
}
