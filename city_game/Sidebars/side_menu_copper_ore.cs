using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace city_game
{
    class side_menu_copper_ore:side_menu_base
    {
        public side_menu_copper_ore()
        {
            buttons = new List<side_menu_button>();
            buttons.Add(new build_mine_button(sidebar.get_start() + 10, 190));
            buttons.Add(new cancel_button(sidebar.get_start() + 10, 230));

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
