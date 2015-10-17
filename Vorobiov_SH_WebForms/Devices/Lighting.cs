using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DZ_2
{
    public class Lighting : Device, Iluminous
    {
        private Adjustment brightness;
        public Lighting(string name, bool state, Adjustment brightness) : base(name, state)
        {
            this.brightness = brightness;
        }
        public void SetHighBrightness()
        {
            brightness = Adjustment.high;
        }
        public void SetMediumBrightness()
        {
            brightness = Adjustment.medium;
        }
        public void SetLowBrightness()
        {
            brightness = Adjustment.low;
        }
        public override string Info()
        {
            string mode = "";
            switch (brightness)
            {
                case Adjustment.high:
                    mode = "Высокая";
                    break;
                case Adjustment.medium:
                    mode = "Средняя";
                    break;
                case Adjustment.low:
                    mode = "Низкая";
                    break;
            }                       
            return base.Info() + "; яркость: " + mode; 
        }
    }
}
