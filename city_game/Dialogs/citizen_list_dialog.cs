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
        private List<citizen> display_list=new List<citizen>();
        private int display_num = 6;
        

        public citizen_list_dialog(List<citizen> citizens)
        {
            citizen_list = citizens;
            width = 400;
            Debug.WriteLine("Dialog constructor");

            for(int i=0; i<display_num; i++)
            {
                if (i >= citizen_list.Count) break;
                display_list.Add(citizen_list[i]);
            }

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

            //draw text
            for (int i = 0; i < display_list.Count; i++)
            {
                spriteBatch.DrawString(font, "Name: " + display_list[i].get_name(), new Vector2(x_start, y_start + 30 + 30*i), Color.Black);
            }
            //Debug.WriteLine("Drawing dialog");

        }

    }
}
