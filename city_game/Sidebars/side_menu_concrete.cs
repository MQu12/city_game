using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace city_game
{
    class side_menu_concrete :side_menu_base
    {

        public side_menu_concrete()
        {
            buttons = new List<side_menu_button>();
            buttons.Add(new demolish_button(sidebar.get_start() + 10, 100));
            buttons.Add(new cancel_button(sidebar.get_start() + 10, 140));

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
        }

    }
}
