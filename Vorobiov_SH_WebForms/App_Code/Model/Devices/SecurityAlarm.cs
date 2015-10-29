using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHome
{
    public class SecurityAlarm : Device
    {
        private bool cctv;
        private bool motionSensor;
        public SecurityAlarm(string name, bool state, bool cctv, bool motionSensor) : base(name, state)
        {
            this.cctv = cctv;
            this.motionSensor = motionSensor;
        }

        public void OnCCTV()
        {
            cctv = true;
        }
        public void OffCCTV()
        {
            cctv = false;
        }
        public void OnMotionSensor()
        {
            motionSensor = true;
        }
        public void OffMotionSensor()
        {
            motionSensor = false;
        }        
        public override string Info()
        {
                  
            return base.Info() + "; видеонаблюдение: " + Mode(cctv) + "; датчики движения: " + Mode(motionSensor);
        }
    }
}
