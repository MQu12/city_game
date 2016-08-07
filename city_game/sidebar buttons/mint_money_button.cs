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
    class mint_money_button: side_menu_button
    {          

        public mint_money_button(int x, int y, city player_city_)
        {
            x_pos = x;
            y_pos = y;
            player_city = player_city_;
        }

        public override void Update(float mouse_x, float mouse_y)
        {
            
            if (mouse_over(mouse_x, mouse_y))
            {               
                if (Mouse.GetState().LeftButton == ButtonState.Pressed && Game1.previous_mouse_state.LeftButton==ButtonState.Released)
                {
                    //check player has enough copper to mint more money
                   if (player_city.get_copper().get_amount() > 0) {     
                                                                   
                        player_city.get_copper().increment(-10);
                        player_city.get_money().increment(10);
                        player_city.incremenet_total_minted_money(10);

                   }
                                    

                }
            }            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sidebar_menu_button, new Vector2(x_pos, y_pos), Color.White);
            spriteBatch.DrawString(font, "Mint money", new Vector2(x_pos + 10, y_pos), Color.Black);
            if (is_mouse_over)
            {

                spriteBatch.Draw(highlighter, new Vector2(x_pos, y_pos), Color.White);

            }
        }

    }
}
