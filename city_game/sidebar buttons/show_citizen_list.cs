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
    class show_citizen_list : side_menu_button
    {

        private bool dialog_open = false;
        private citizen_list_dialog dialog;
        private List<citizen> citizens;

        public show_citizen_list(int x, int y, List<citizen> citizen_list)
        {

            x_pos = x;
            y_pos = y;
            citizens = citizen_list;

        }

        public override void Update(float mouse_x, float mouse_y)
        {

            if (mouse_over(mouse_x, mouse_y))
            {

                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {

                    //show dialog
                    if (!dialog_open)
                    {

                        Debug.WriteLine("About to call dialog constructor");
                        dialog = new citizen_list_dialog(citizens);
                        dialog_open = true;


                    }
                    else
                    {
                        dialog.Update();
                    }


                }
            }

            if (dialog_open)
                if (dialog.close_dialog())
                {
                    dialog = null;
                    dialog_open = false;
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
            if (dialog_open)
            {
                dialog.Draw(spriteBatch);
            }
        }
        public override bool is_dialog_open()
        {
            return dialog_open;
        }

    }
}
