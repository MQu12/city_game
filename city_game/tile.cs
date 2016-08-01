using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace city_game
{
    class tile
    {
        public enum states { grass, concrete, town_hall, brownfield,farm, mint, copper_ore, copper_mine };
        private states state = states.grass; //default state is grass
        private float x_pos=0; // x coordinate of top left corner
        private float y_pos=0; // y coordinate of top left corner
        private int dimension = 85; //dimension of square tile in px
        private bool mouse_over = false; //true if mouse is hovering over the square

        //textures
        private Texture2D grass_tex;
        private Texture2D concrete_tex;
        private Texture2D highlight_tex;
        private Texture2D brownfield_tex;
        private Texture2D town_hall_tex;
        private Texture2D farm_tex;
        private Texture2D mint_tex;
        private Texture2D copper_ore_tex;
        private Texture2D copper_mine_tex;

        private static MouseState previous_mouse_state;

        public static int[] selected_sq = new int[2]; //coordinates of the selected square
        public static bool selection = false; // true if a square is being selected
        
        public tile(Dictionary<string, Texture2D> textures, MouseState previous_mouse_state_, int x_pos_, int y_pos_)
        {

            x_pos = x_pos_;
            y_pos = y_pos_;

            grass_tex = textures["grass"];
            concrete_tex = textures["concrete"];
            highlight_tex = textures["highlighter"];
            brownfield_tex = textures["brownfield"];
            farm_tex = textures["farm"];
            town_hall_tex = textures["town_hall"];
            copper_ore_tex = textures["copper_ore"];
            mint_tex = textures["mint"];
            copper_mine_tex = textures["copper_mine"];

            previous_mouse_state = previous_mouse_state_;

        }

        public tile(Dictionary<string, Texture2D> textures, MouseState previous_mouse_state_, int x_pos_, int y_pos_, states state_)
        {

            x_pos = x_pos_;
            y_pos = y_pos_;
            state = state_;

            grass_tex = textures["grass"];
            concrete_tex = textures["concrete"];
            highlight_tex = textures["highlighter"];
            brownfield_tex = textures["brownfield"];
            farm_tex = textures["farm"];
            town_hall_tex = textures["town_hall"];
            copper_ore_tex = textures["copper_ore"];
            mint_tex = textures["mint"];
            copper_mine_tex = textures["copper_mine"];

            previous_mouse_state = previous_mouse_state_;

        }

        public bool Update(double mouse_x, double mouse_y)
        {

            //check if mouse is overhead

            if (mouse_x >= x_pos && mouse_x < x_pos + dimension && mouse_y >= y_pos && mouse_y < y_pos + dimension)
                mouse_over = true;
            else mouse_over = false;

            return mouse_over;

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            //draw the relevant tile
            if (state == states.grass) spriteBatch.Draw(grass_tex, new Vector2(x_pos, y_pos), Color.White);
            else if (state == states.concrete) spriteBatch.Draw(concrete_tex, new Vector2(x_pos, y_pos), Color.White);
            else if (state == states.brownfield) spriteBatch.Draw(brownfield_tex, new Vector2(x_pos, y_pos), Color.White);
            else if (state == states.farm) spriteBatch.Draw(farm_tex, new Vector2(x_pos, y_pos), Color.White);
            else if (state == states.town_hall) spriteBatch.Draw(town_hall_tex, new Vector2(x_pos, y_pos), Color.White);
            else if (state == states.mint) spriteBatch.Draw(mint_tex, new Vector2(x_pos, y_pos), Color.White);
            else if (state == states.copper_ore) spriteBatch.Draw(copper_ore_tex, new Vector2(x_pos, y_pos), Color.White);
            else if (state == states.copper_mine) spriteBatch.Draw(copper_mine_tex, new Vector2(x_pos, y_pos), Color.White);

            if (mouse_over) spriteBatch.Draw(highlight_tex, new Vector2(x_pos, y_pos), Color.White);
            
        }
        public string get_state_str()
        {

            if (state == states.grass) return "Grassland";
            else if (state == states.concrete) return "Concrete";
            else if (state == states.town_hall) return "Town Hall";
            else if (state == states.brownfield) return "Brownfield";
            else if (state == states.farm) return "Farm";
            else if (state == states.copper_ore) return "Copper\nore\ndeposit";
            else if (state == states.mint) return "Mint";
            else if (state == states.copper_mine) return "Copper\nmine";

            else return "idk";

        }
        public states get_state()
        {

            return state;

        }
        
        public void set_state(states new_state)
        {

            state = new_state;

        }    

    }
}
