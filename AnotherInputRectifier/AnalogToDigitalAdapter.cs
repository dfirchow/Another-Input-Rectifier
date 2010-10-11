using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnotherInputRectifier
{
    public class AnalogToDigitalAdapter : IDigitalControl
    {
        private IAnalogControl control;

        public AnalogToDigitalAdapter(IAnalogControl control)
        {
            this.control = control;
        }

        public bool Pressed
        {
            get { return control.Value == 1; }
        }
    }
}
