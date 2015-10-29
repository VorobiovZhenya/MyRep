namespace SmartHome
{
    public abstract class ClimatDevice : Device
    {   
        private Adjustment temperatureMode;
        public ClimatDevice(string name, bool state, Adjustment temperatureMode) : base(name, state)
        {
            this.temperatureMode = temperatureMode;
        }
        public void SetHighTemperatureMode()
        {
            temperatureMode = Adjustment.high;
        }
        public void SetMediumTemperatureMode()
        {
            temperatureMode = Adjustment.medium;
        }
        public void SetLowTemperatureMode()
        {
            temperatureMode = Adjustment.low;
        }
        public override string Info()
        {
            string mode = "";
            switch (temperatureMode)
            {
                case Adjustment.high:
                    mode = "Высокий";
                    break;
                case Adjustment.medium:
                    mode = "Средний";
                    break;
                case Adjustment.low:
                    mode = "Низкий";
                    break;
            }                       
            return base.Info() + "; температурный режим " + mode; 
        }
    }
}
