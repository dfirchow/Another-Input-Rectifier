/*****************************************************************************
 * Air.cs
 * Copyright (c) 2010 Dustin Firchow
 * 
 * Inspired by a 2007 post on http://forums.xna.com/forums/p/2189/11345.aspx
 * by SwampThingTom.
 *****************************************************************************/

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

// These are used because I'm defining Air.Gamepad and Air.Mouse
using XnaKeyboard = Microsoft.Xna.Framework.Input.Keyboard;
using XnaGamePad = Microsoft.Xna.Framework.Input.GamePad;
using XnaMouse = Microsoft.Xna.Framework.Input.Mouse;


namespace AnotherInputRectifier
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Air : Microsoft.Xna.Framework.GameComponent
    {
        #region Private Constants
        private static short PlayerOne   = 0;
        private static short PlayerTwo   = 1;
        private static short PlayerThree = 2;
        private static short PlayerFour  = 3;
        #endregion

        #region GamePad and Mouse static classes

        public static class GamePad
        {
            public enum Thumbsticks
            {
                Left, Right
            }

            public enum Triggers
            {
                Left, Right
            }

            public enum Buttons
            {
                Back, BigButton, Start, 
                A, B, X, Y,
                LeftShoulder, RightShoulder,
                LeftStick, RightStick
            }

            public enum DPad
            {
                Left, Right, Up, Down
            }

            /// <summary>
            /// Returns a digital direction control for a player's dpad.
            /// </summary>
            /// <param name="player">player index for a gamepad</param>
            /// <returns>control for a dpad</returns>
            public static IDigitalDirectionControl DPadControl(PlayerIndex player)
            {
                return new Details.GamePadDPadControl(player);
            }

            /// <summary>
            /// Returns a digital direction control for player one's dpad.
            /// </summary>
            /// <returns>control for a dpad</returns>
            public static IDigitalDirectionControl DPadControl()
            {
                return new Details.GamePadDPadControl(PlayerIndex.One);
            }
        }
        
#if !XBOX360
        public static class Mouse
        {
            public enum Buttons
            {
                Left, Right, Middle, X1, X2
            }

            /// <summary>
            /// Gets mouse position as an
            /// analog direction control.
            /// </summary>
            public static IAnalogDirectionControl Position
            {
                get { return new Details.MousePositionControl(); }
            }
        }
#endif

        #endregion

        #region Constructor and base overrides

        public Air(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
#if !XBOX360
            mouseState = XnaMouse.GetState();
#endif
            keyboardState = Keyboard.GetState();

            UpdateGamePadStates();
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            UpdateStates();

            base.Update(gameTime);
        }

        private void UpdateStates()
        {
#if !XBOX360
            previousMouseState = mouseState;
            mouseState = XnaMouse.GetState();
#endif

            previousKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();

            previousGamePadState[PlayerOne] = gamePadState[PlayerOne];
            previousGamePadState[PlayerTwo] = gamePadState[PlayerTwo];
            previousGamePadState[PlayerThree] = gamePadState[PlayerThree];
            previousGamePadState[PlayerFour] = gamePadState[PlayerFour];

            UpdateGamePadStates();
        }

        private void UpdateGamePadStates()
        {
            gamePadState[PlayerOne] = XnaGamePad.GetState(PlayerIndex.One);
            gamePadState[PlayerTwo] = XnaGamePad.GetState(PlayerIndex.Two);
            gamePadState[PlayerThree] = XnaGamePad.GetState(PlayerIndex.Three);
            gamePadState[PlayerFour] = XnaGamePad.GetState(PlayerIndex.Four);
        }

        #endregion

        /// <summary>
        /// Anything related to the mouse.
        /// Not built if platform is XBOX360
        /// </summary>
        #region Mouse
#if !XBOX360
        static MouseState mouseState;
        static MouseState previousMouseState;

        public static MouseState MouseState
        {
            get { return mouseState; }
        }

        public static MouseState PreviousMouseState
        {
            get { return previousMouseState; }
        }

        public static IAnalogDirectionControl CreateMouseControl()
        {
            return new Details.MousePositionControl();
        }
            
#endif
        #endregion

        /// <summary>
        /// Anything related to the keyboard.
        /// </summary>
        #region Keyboard

        static KeyboardState keyboardState;
        static KeyboardState previousKeyboardState;

        public static KeyboardState KeyboardState
        {
            get { return keyboardState; }
        }

        public static KeyboardState PreviousKeyboardState
        {
            get { return previousKeyboardState; }
        }

        public static IDigitalControl CreateKeyboardControl(Keys key)
        {
            return new Details.KeyControl(key);
        }

        #endregion


        /// <summary>
        /// Anything related to a game pad
        /// </summary>
        #region Gamepad

        static GamePadState[] gamePadState = new GamePadState[4];
        static GamePadState[] previousGamePadState = new GamePadState[4];

        /// <summary>
        /// Gets the gamepad state for the specified player.
        /// </summary>
        /// <param name="player">The player index.</param>
        /// <returns>GamePadState for specified player.</returns>
        public static GamePadState GamePadState(PlayerIndex player)
        {
            return gamePadState[IndexOf(player)];
        }

        /// <summary>
        /// Gets the gamepad state for player one.
        /// </summary>
        /// <returns>GamePadState for PlayerIndex.One</returns>
        public static GamePadState GamePadState()
        {
            return gamePadState[PlayerOne];
        }

        /// <summary>
        /// Gets the gamepad state from the previous frame for the 
        /// specified player.
        /// </summary>
        /// <param name="player">The player index.</param>
        /// <returns>
        /// Specified player's previous gamepad state.
        /// </returns>
        public static GamePadState PreviousGamePadState(PlayerIndex player)
        {
            return previousGamePadState[IndexOf(player)];
        }

        /// <summary>
        /// Gets the gamepad state from the previous frame for
        /// player one.
        /// </summary>
        /// <returns>Player one's previous gamepad state.</returns>
        public static GamePadState PreviousGamePadState()
        {
            return previousGamePadState[PlayerOne];
        }

        /// <summary>
        /// Checks to see if the specified player's gamepad is
        /// currently connected.
        /// </summary>
        /// <returns>
        /// True if gamepad is connected, otherwise returns false.
        /// </returns>
        public static bool IsConnected(PlayerIndex player)
        {
            return gamePadState[IndexOf(player)].IsConnected;
        }

        /// <summary>
        /// Checks to see if player one's gamepad is currently connected.
        /// </summary>
        /// <returns>
        /// True if gamepad is connected, otherwise returns false.
        /// </returns>
        public static bool IsConnected()
        {
            return gamePadState[PlayerOne].IsConnected;
        }

        /// <summary>
        /// Get index for gamePadState[] from a PlayerIndex
        /// </summary>
        /// <param name="player">The PlayerIndex for the game pad you want.</param>
        /// <returns>The correct index for the gamePadState[].
        /// Or -1 if something goes horribly wrong.</returns>
        private static int IndexOf(PlayerIndex player)
        {
            switch (player)
            {
                case PlayerIndex.One:   return PlayerOne;
                case PlayerIndex.Two:   return PlayerTwo;
                case PlayerIndex.Three: return PlayerThree;
                case PlayerIndex.Four:  return PlayerFour;
            }

            return -1; // Return bad value
        }

        #endregion
    }
}
