using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using AnotherInputRectifier;

namespace TestAir
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        PlayerControls playerControls;
        DigitalFilterControl escapeControl;
        Color backgroundColor = Color.Black;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Create instance of Input Rectifier and add it to components
            // so it automatically updates.
            Components.Add(new Air(this));
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

            escapeControl = new DigitalFilterControl(Air.CreateKeyboardControl(Keys.Escape));
            ButtonDirectionControl movementControl = new ButtonDirectionControl(
                Air.CreateKeyboardControl(Keys.A),
                Air.CreateKeyboardControl(Keys.D),
                Air.CreateKeyboardControl(Keys.W),
                Air.CreateKeyboardControl(Keys.S));
            playerControls = new PlayerControls(
                new DigitalDirectionControl(movementControl),
                Air.CreateKeyboardControl(Keys.W).Filter(),
                Air.CreateKeyboardControl(Keys.Space).Filter(),
                Air.CreateKeyboardControl(Keys.P).Filter());
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
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            if (playerControls.Jump)
            {
                backgroundColor = Color.Blue;
            }
            else if (playerControls.Fire)
            {
                backgroundColor = Color.Red;
            }
            else if (playerControls.Pause)
            {
                backgroundColor = Color.WhiteSmoke;
            }
            else if (playerControls.Movement.X < 0)
            {
                backgroundColor = Color.Magenta;
            }
            else if (playerControls.Movement.X > 0)
            {
                backgroundColor = Color.Maroon;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(backgroundColor);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
