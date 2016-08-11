using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace city_game
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private float mouse_x, mouse_y;

        private int timesteps = 0;

        //textures
        private Texture2D interface_tex;
        private Texture2D grass_tile;
        private Texture2D concrete_tile;
        private Texture2D brownfield_tile;
        private Texture2D tile_highlighter;
        private Texture2D blue_highlighter;
        private Texture2D sidebar_menu_button;
        private Texture2D sidebar_highlighter;
        private Texture2D farm_tile;
        private Texture2D town_hall_tile;
        private Texture2D copper_ore_tile;
        private Texture2D mint_tile;
        private Texture2D copper_mine_tile;
        private Texture2D dialog_bkg;
        private Texture2D dialog_topbar;
        private Texture2D dialog_exit_button;

        private SpriteFont sidebar_font;
        private SpriteFont sidebar_menu_font;
        private SpriteFont topbar_font;

        private Dictionary<string, Texture2D> tile_textures = new Dictionary<string, Texture2D>();

        //create a grid top bar and sidebar
        private grid Grid;
        private sidebar side_bar;
        private top_bar TopBar = new top_bar();


        //and a city for the player
        private city player_city = new city();        

        public static MouseState previous_mouse_state;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1280;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 720;   // set this value to the desired height of your window
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //previous_mouse_state = Mouse.GetState();

            top_bar.player_city = player_city;
            side_menu_townhall.set_city(player_city);

            this.IsMouseVisible = true;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            interface_tex = Content.Load<Texture2D>("interface");
            grass_tile = Content.Load<Texture2D>("grass_tile");
            concrete_tile = Content.Load<Texture2D>("concrete_tile");
            brownfield_tile = Content.Load<Texture2D>("brownfield");
            farm_tile = Content.Load<Texture2D>("farm");
            tile_highlighter = Content.Load<Texture2D>("highlighter");
            blue_highlighter = Content.Load<Texture2D>("blue_highlighter");
            sidebar_menu_button = Content.Load<Texture2D>("menu_button");
            sidebar_highlighter = Content.Load<Texture2D>("button_highlighter");
            town_hall_tile = Content.Load<Texture2D>("town_hall");
            copper_ore_tile = Content.Load<Texture2D>("copper_ore");
            mint_tile = Content.Load<Texture2D>("mint");
            copper_mine_tile = Content.Load<Texture2D>("copper_mine");
            dialog_bkg = Content.Load<Texture2D>("dialog_bkg");
            dialog_topbar = Content.Load<Texture2D>("dialog_topbar");
            dialog_exit_button = Content.Load<Texture2D>("dialog_exit");

            sidebar_font = Content.Load<SpriteFont>("sidebar_font");
            sidebar_menu_font = Content.Load<SpriteFont>("sidebar_menu_font");
            topbar_font = Content.Load<SpriteFont>("topbar_font");
            
            //pass textures and spritefonts to relevant classes
            side_menu_button.sidebar_menu_button = sidebar_menu_button;
            side_menu_button.highlighter = sidebar_highlighter;
            side_menu_button.font = sidebar_menu_font;
            top_bar.font = topbar_font;
            side_menu_base.menu_font = sidebar_menu_font;

            base_dialog.font = sidebar_menu_font;
            base_dialog.tex_bkg = dialog_bkg;
            base_dialog.tex_topbar = dialog_topbar;
            base_dialog.tex_exit_button = dialog_exit_button;

            tile_textures["farm"] = farm_tile;
            tile_textures["grass"] = grass_tile;
            tile_textures["concrete"] = concrete_tile;
            tile_textures["highlighter"] = tile_highlighter;
            tile_textures["blue_highlighter"] = blue_highlighter;
            tile_textures["brownfield"] = brownfield_tile;
            tile_textures["town_hall"] = town_hall_tile;
            tile_textures["mint"] = mint_tile;
            tile_textures["copper_ore"] = copper_ore_tile;
            tile_textures["copper_mine"] = copper_mine_tile;

            Grid = new grid(tile_textures,previous_mouse_state);
            side_bar = new sidebar(sidebar_font,sidebar_menu_font,sidebar_menu_button,sidebar_highlighter, ref Grid, player_city);

            player_city.set_grid(Grid);
            player_city.get_population().set_grid(Grid);

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //get position of the mouse
            MouseState mouse_state = Mouse.GetState();
            mouse_x = mouse_state.X;
            mouse_y = mouse_state.Y;

            //update the grid when dialoogs are not open
            Debug.WriteLine(side_bar.is_dialog_open());
            if (!side_bar.is_dialog_open())
                Grid.Update(mouse_x, mouse_y);

            //and the sidebar
            side_bar.Update(mouse_x, mouse_y);

            //and the player city
            player_city.Update(Grid.get_num_farms(),Grid.get_num_copper_mines());

            TopBar.Update(mouse_x, mouse_y);

            timesteps++;

            base.Update(gameTime);

            previous_mouse_state = Mouse.GetState();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Grid.Draw(spriteBatch);

            spriteBatch.Begin();

            spriteBatch.Draw(interface_tex, new Rectangle(0,0,1280, 720), Color.White);
                     
            side_bar.Draw(spriteBatch, Grid);

            TopBar.Draw(spriteBatch);

            spriteBatch.End();

              

            base.Draw(gameTime);
        }    
    }
}
