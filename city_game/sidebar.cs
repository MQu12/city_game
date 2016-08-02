using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace city_game
{
    class sidebar
    {

        enum states { blank, tile_selected };

        private states state = states.blank;
        private int[] tile_no = new int[2];
        private Texture2D menu_item;
        private Texture2D menu_highlight;
        private static int start_of_bar = 1020;
        private SpriteFont menu_font;
        private SpriteFont title_font;
        private side_menu_base menu;
        private grid Grid;
        private city player_city;

        public sidebar(SpriteFont titlefont, SpriteFont menufont, Texture2D menuitem, Texture2D menuHighlight, ref grid Grid_, ref city City)
        {

            menu_item = menuitem;
            menu_highlight = menuHighlight;
            title_font = titlefont;
            menu_font = menufont;
            Grid = Grid_;
            player_city = City;

        }

        public void Update(float mouse_x, float mouse_y)
        {

            if (tile.selection)
            {

                switch (grid.get_selected_tile().get_state())
                {
                    case tile.states.grass:
                        menu = new side_menu_grass(ref Grid);
                        break;

                    case tile.states.concrete:
                        menu = new side_menu_concrete();
                        break;

                    case tile.states.brownfield:
                        menu = new side_menu_brownfield(ref Grid);
                        break;

                    case tile.states.farm:
                        menu = new side_menu_farm();
                        break;

                    case tile.states.town_hall:
                        menu = new side_menu_townhall();
                        break;

                    case tile.states.copper_ore:
                        menu = new side_menu_copper_ore();
                        break;

                    case tile.states.copper_mine:
                        menu = new side_menu_copper_mine();
                        break;

                    case tile.states.mint:
                        menu = new side_menu_mint(ref player_city);
                        break;
                }
                
                menu.Update(mouse_x, mouse_y);

            }

            else menu = null;

        }
        
        public void Draw(SpriteBatch spriteBatch, grid Grid)
        {

            if (tile.selection)
            {


                //get tile type
                string tile_type = grid.get_selected_tile().get_state_str();
                //draw this at the side
                spriteBatch.DrawString(title_font, tile_type, new Vector2(start_of_bar + 10, 50), Color.Blue);

                //draw menu
                menu.Draw(spriteBatch);


            }

        }

        public static int get_start()
        {

            return start_of_bar;

        }

    }
}
