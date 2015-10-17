using System.Threading;
using System.Threading.Tasks;
namespace DZ_2
{
    public class HeatingSystem : ClimatDevice, ITimer
    {        
        private bool timerState;
        public HeatingSystem(string name, bool state, Adjustment temperatureMode)
            : base(name, state, temperatureMode) 
        {
           
        }
        public void TimerOn(int time)
        {                
            Task t = new Task(() => Timer(time,true));
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
            Thread.Sleep(1000*t);  
            if  (s)  this.On();
            else this.Off();
            this.timerState = false;
        }
        public override string Info()
        {

            return base.Info() + "; таймер: " + Mode(timerState);
        }
    }
}
