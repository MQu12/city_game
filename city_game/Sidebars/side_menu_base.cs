using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace city_game
{
    abstract class side_menu_base
    {
        protected int num_options;
        protected List<side_menu_button> buttons;
        public static SpriteFont menu_font;

        public abstract void Update(float mouse_x, float mouse_y);
        public abstract void Draw(SpriteBatch spriteBatch);

    }
}
