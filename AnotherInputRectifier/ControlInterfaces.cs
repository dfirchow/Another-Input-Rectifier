using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnotherInputRectifier
{
    public interface IAnalogControl
    {
        float Value { get; }
    }

    public interface IDigitalControl
    {
        bool Pressed { get; }
    }
}
