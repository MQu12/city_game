using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace city_game
{
    class show_citizen_list : side_menu_button
    {

        public show_citizen_list(int x, int y)
        {

            x_pos = x;
            y_pos = y;            

        }

        public override void Update(float mouse_x, float mouse_y)
        {

            if (mouse_over(mouse_x, mouse_y))
            {

                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {

                    //show dialog

                }
            }

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sidebar_menu_button, new Vector2(x_pos, y_pos), Color.White);
            spriteBatch.DrawString(font, "Show citizen list", new Vector2(x_pos + 10, y_pos), Color.Black);
            if (is_mouse_over)
            {

                spriteBatch.Draw(highlighter, new Vector2(x_pos, y_pos), Color.White);

            }
        }

    }
}
