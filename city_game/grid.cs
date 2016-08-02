using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace city_game
{
    class grid
    {
        private static List<List<tile>> tile_list = new List<List<tile>>();
        private MouseState previous_mouse_state;
        private Dictionary<string,Texture2D> textures;
        private int num_farms;
        private int num_copper_mines = 0;
        private bool mint_built = false;

        public grid(Dictionary<string,Texture2D> textures_,MouseState previous_mouse_state_)
        {

            textures = textures_;

            previous_mouse_state = previous_mouse_state_;

            //initialise the grid, all grass tiles
            int x_pos, y_pos = 0;

            for(int i = 0; i < 8; i++)
            {
                y_pos = 40 + i * 85;
                tile_list.Add(new List<tile>());
                for(int j = 0; j < 12; j++)
                {
                    x_pos = j * 85;
                    if (i == 4 && j == 6) tile_list[i].Add(new tile(textures, previous_mouse_state, x_pos, y_pos, tile.states.town_hall));
                    else if (i == 3 && j == 3) tile_list[i].Add(new tile(textures, previous_mouse_state, x_pos, y_pos, tile.states.copper_ore));
                    else if (i == 3 && (j == 6 || j == 5)) tile_list[i].Add(new tile(textures, previous_mouse_state, x_pos, y_pos, tile.states.farm));
                    else
                        tile_list[i].Add(new tile(textures, previous_mouse_state, x_pos, y_pos, tile.states.grass));

                }

            }

        }        

        public void Update(double mouse_x, double mouse_y)
        {

            num_farms = 0;
            num_copper_mines = 0;
            mint_built = false;

            for (int i = 0; i < tile_list.Count; i++)
            {
                for (int j = 0; j < tile_list[i].Count; j++)
                {                    
                    if (tile_list[i][j].Update(mouse_x, mouse_y) && Mouse.GetState().LeftButton == ButtonState.Pressed && previous_mouse_state.LeftButton == ButtonState.Released)
                    {

                        tile.selected_sq[0] = i;
                        tile.selected_sq[1] = j;
                        tile.selection = true;                       

                    }
                    if (get_tile(i, j).get_state() == tile.states.farm) num_farms++;
                    else if (get_tile(i, j).get_state() == tile.states.copper_mine) num_copper_mines++;
                    else if (get_tile(i, j).get_state() == tile.states.mint) mint_built = true;
                    

                }
            }
               

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            for (int i = 0; i < tile_list.Count; i++)
            {
                for (int j = 0; j < tile_list[i].Count; j++)
                {

                    tile_list[i][j].Draw(spriteBatch);
                    if(i == tile.selected_sq[0] && j == tile.selected_sq[1] && tile.selection)
                    {
                        spriteBatch.Draw(textures["blue_highlighter"], new Vector2(j * 85, 85 * i+40), Color.White);                        
                    }
                }
            }            

            spriteBatch.End();
        }

        public tile get_tile(int x, int y)
        {

            return tile_list[x][y];

        }
        public static tile get_selected_tile()
        {

            return tile_list[tile.selected_sq[0]][tile.selected_sq[1]];

        }
        public int get_num_farms()
        {
            return num_farms;
        }
        public int get_num_copper_mines()
        {
            return num_copper_mines;
        }
        public bool Mint_built()
        {
            return mint_built;
        }

    }
}
