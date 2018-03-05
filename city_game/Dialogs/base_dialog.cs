using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

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
        private bool close = false;
        private int original_x, original_y; //position of mouse before click
        private int x_start_original, y_start_original; //original position of dialog before click
        private bool moving_dialog = false;

        public abstract void Update();
        public abstract void Draw(SpriteBatch spriteBatch);

        public void mouse_click()
        {
            //Debug.WriteLine("Checking for click");
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                //Debug.WriteLine("We have a click");
                //for closing the dialog
                if (Game1.previous_mouse_state.LeftButton == ButtonState.Released
                    && Mouse.GetState().X < x_start + width && Mouse.GetState().X > x_start + width - 30
                    && Mouse.GetState().Y > y_start && Mouse.GetState().Y < y_start + 30)
                {
                    close = true;
                    Debug.WriteLine("Close called");
                }
                //move the dialog
                else if (Mouse.GetState().X > x_start && Mouse.GetState().X < x_start + width - 30
                    && Mouse.GetState().Y > y_start && Mouse.GetState().Y < y_start + 30
                    && Game1.previous_mouse_state.LeftButton == ButtonState.Released)
                {

                    //check the position of the mouse before click

                    original_x = Mouse.GetState().X;
                    original_y = Mouse.GetState().Y;
                    x_start_original = x_start;
                    y_start_original = y_start;

                    moving_dialog = true;

                }

                else if (moving_dialog)
                {

                    x_start = x_start_original + Mouse.GetState().X - original_x;
                    y_start = y_start_original + Mouse.GetState().Y - original_y;

                }
            }
            else moving_dialog = false;
        }
        public bool close_dialog()
        {
            return close;
        }

    }
}
