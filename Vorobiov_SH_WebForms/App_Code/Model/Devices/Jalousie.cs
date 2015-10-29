namespace SmartHome
{
    public class Jalousie : Device
    {
        public Jalousie(string name, bool state) : base(name,state){    }
        private string JalMode(bool b)
        {
            if (b == true)
                return "Открыты";
            else return "Закрыты";
        }
        public override string Info()
        {
            return this.GetName() + "; состояние: " + JalMode(this.GetState());            
        }
    }
}
