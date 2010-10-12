Another Input Rectifier
=======================

Another Input Rectifier (`Air`) is designed to make working with input in XNA easier.


Two Main Interfaces
-------------------

    public interface IDigitalControl
    {
        public bool Pressed { get; }
    }

    public interface IAnalogControl
    {
        public float Value { get; }
    }

These two interfaces form the basis for the rest of the library.

Air
---

The main class of the library. `Air` is a game component so its update method will be called automatically.
Make sure to add it to your game's components like so:

    public YourGame()
    {
        ...
        Components.Add(new Air(this));
    }

###Keyboard Controls
The only thing that is implemented right now. You can create a keyboard control by calling

    IDigitalControl myControl = Air.CreateKeyboardControl(Keys.Space);

This creates a regular digital control where `myControl.Pressed` will be true on any frame that the key is down on. If you only want `myControl.Pressed` to be true the first time the button is pressed (i.e. it wont repeat) then you want a `DigitalFilterControl`

    IDigitalControl myControl = new DigitalFilterControl(Air.CreateKeyboardControl(Keys.Space));

or the much easier

    IDigitalControl myControl = Air.CreateKeyboardControl(Keys.Space).Filter();
######Extensions
Can create keyboard controls directly from the Xna.Framework.Input.Keys enum

    Keys.Space.ToDigitalControl()

Digital Extension Methods
-------------------------
Any class the implements IDigitalControl will also recieve these extension methods

 *   `Filter()` - returns a filtered (or one-shot) version of the control.
 *   `Analog()` - returns an analog version of the control where `IAnalogControl.Value` will be 1 when the button is pressed and 0 otherwise.

Work in progress
----------------
Still lots to do. Add methods for the mouse and gamepads. For now `Air` also provides access to the raw input state through these properties

 *   `Air.MouseState` and `Air.PreviousMouseState`
 *   `Air.KeyboardState` and `Air.PreviousKeyboardState`
 *   Gamepads can't be a property because you need to know the player
     -   `Air.GamePadState(PlayerIndex player)` and `Air.PreviousGamePadState(PlayerIndex player)`
