using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace city_game
{
    abstract class side_menu_button
    {
        protected int x_pos = 1030;
        protected int y_pos = 40;        
        protected int height = 40;
        protected int width = 240;
        protected bool is_mouse_over = false;     
        public static Texture2D sidebar_menu_button;
        public static Texture2D highlighter;
        public static SpriteFont font;

        public abstract void Update(float mouse_x, float mouse_y);
        public abstract void Draw(SpriteBatch spriteBatch);

        public virtual bool mouse_over(float mouse_x, float mouse_y)
        {

            if (mouse_x > x_pos && mouse_x < x_pos + width && mouse_y > y_pos && mouse_y < y_pos + height)
            {
                is_mouse_over = true;
                return true;
            }
            else {
                is_mouse_over = false;
                return false;
            }
        }

    }
}
