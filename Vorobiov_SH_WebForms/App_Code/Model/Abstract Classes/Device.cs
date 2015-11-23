namespace SmartHome
{    
    public abstract class Device 
    {
        //private string deviceName;
        private bool state;
        private string name;        
        public Device(string name, bool state)
        {
            this.state = state;
            this.name = name;            
        }
        public string GetName()
        {
            return this.name;
        }
        public bool GetState()
        {
            return this.state;
        }  
        public void On()
        {
            state = true;
        }
        public void Off()
        {
            state = false;
        }
        protected string Mode(bool b)
        {
            if (b == true)
                return "Вкл.";
            else return "Выкл.";
        }
        public virtual string Info()
        {
            return name + "; состояние: " + Mode(state);
        }
                
    }
}
