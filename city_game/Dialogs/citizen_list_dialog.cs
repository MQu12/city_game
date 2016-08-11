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
    class citizen_list_dialog : base_dialog
    {

        private List<citizen> citizen_list;
        

        public citizen_list_dialog(List<citizen> citizens)
        {
            citizen_list = citizens;
            Debug.WriteLine("Dialog constructor");
        }

        public override void Update()
        {
            mouse_click();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(tex_bkg, new Rectangle(x_start, y_start, width, height), Color.White);
            spriteBatch.Draw(tex_topbar, new Rectangle(x_start, y_start, width, 30), Color.White);
            spriteBatch.Draw(tex_exit_button, new Vector2(x_start+width-30,y_start), Color.White);
            //Debug.WriteLine("Drawing dialog");

        }

    }
}
