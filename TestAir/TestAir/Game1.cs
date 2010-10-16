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
        IDigitalControl escapeControl;
        IAnalogDirectionControl mousePosition;

        Color backgroundColor = Color.Black;
        Texture2D mouse;

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

            // You can use the Keys.ToDigitalControl() extension method
            // to create controls
            ButtonDirectionControl movementControl = new ButtonDirectionControl(
                Keys.A.ToDigitalControl(),
                Keys.D.ToDigitalControl(),
                Keys.W.ToDigitalControl(),
                Keys.S.ToDigitalControl());

            // Or you can use Air.CreateKeyboardControl(Keys key)
            playerControls = new PlayerControls(
                new DigitalDirectionControl(movementControl),
                Air.CreateKeyboardControl(Keys.W).Filter(),
                Air.CreateKeyboardControl(Keys.Space).Filter(),
                Air.CreateKeyboardControl(Keys.P).Filter());
            
            // Old way to get mouse position
            // mousePosition = Air.CreateMouseControl();

            // New way to get mouse position
            mousePosition = Air.Mouse.Position;

            // Set up the "mouse cursor"
            // a 10x10 pixel brown square
            // I was too lazy to create an image in MS Paint
            #region Mouse Cursor
            Color[] mouseColor = new Color[100];
            for (int i = 0; i < mouseColor.Length; i++)
            {
                mouseColor[i] = Color.Brown;
            }

            mouse = new Texture2D(GraphicsDevice, 10, 10, false, SurfaceFormat.Color);
            mouse.SetData<Color>(mouseColor);
            #endregion

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
            mouse.Dispose();
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
            else
            {
                backgroundColor = Color.Black;
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
            spriteBatch.Begin();

            spriteBatch.Draw(mouse, mousePosition.Value, Color.Brown);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
