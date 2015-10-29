using System.Threading;
using System.Threading.Tasks;
namespace SmartHome
{
    public class Sauna : ClimatDevice, Iluminous, ITimer
    {
        private Adjustment brightness;
        private bool timerState;
        public Sauna(string name, bool state, Adjustment temperatureMode, Adjustment brightness)
            : base(name, state, temperatureMode) 
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
        public void TimerOn(int time)
        {
            Task t = new Task(() => Timer(time, true));
            t.Start();
        }
        public void TimerOff(int time)
        {
            Task t = new Task(() => Timer(time, false));
            t.Start();
        }
        private void Timer(int t, bool s)
        {
            this.timerState = true;
            Thread.Sleep(1000 * t);
            if (s) this.On();
            else this.Off();
            this.timerState = false;
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
            return base.Info() + "; яркость освещения: " + mode + "; таймер: " + Mode(timerState);
        }
    }
}
