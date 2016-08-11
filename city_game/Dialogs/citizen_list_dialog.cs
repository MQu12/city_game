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
        private bool close = false;

        public citizen_list_dialog(List<citizen> citizens)
        {
            citizen_list = citizens;
            Debug.WriteLine("Dialog constructor");
        }

        public override void Update()
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(tex_bkg, new Rectangle(x_start, y_start, width+200, height+100), Color.White);
            //Debug.WriteLine("Drawing dialog");

        }
        public bool close_dialog()
        {
            return close;
        }

    }
}
