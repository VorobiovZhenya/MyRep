namespace SmartHome
{
    public class Conditioner : ClimatDevice
    {
        private bool humidifier;
        public Conditioner(string name, bool state, Adjustment temperatureMode, bool humidifier)
            : base(name, state, temperatureMode)
        {
            this.humidifier = humidifier;   
        }        
        public void OnHumidifire()
        {
            humidifier = true;
        }
        public void OffHumidifire()
        {
            humidifier = false;
        }
        public override string Info()
        {

            return base.Info() + "; увлажнитель: " + Mode(humidifier);
        }
    }
}
