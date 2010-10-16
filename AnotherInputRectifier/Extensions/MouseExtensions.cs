using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnotherInputRectifier.Details;

namespace AnotherInputRectifier
{
    public static class MouseExtensions
    {
        public static IDigitalControl ToControl(this Air.Mouse.Buttons button)
        {
            return new MouseButtonControl(button);
        }
    }
}
