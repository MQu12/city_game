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
    abstract class base_dialog
    {

        public static SpriteFont font;

        public static Texture2D tex_bkg;
        public static Texture2D tex_topbar;
        public static Texture2D tex_exit_button;

        protected int x_start = 400;
        protected int y_start = 200;
        protected int width = 200;
        protected int height = 400;

        public abstract void Update();
        public abstract void Draw(SpriteBatch spriteBatch);

    }
}
