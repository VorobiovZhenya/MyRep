using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vorobiov_SH_WebForms
{
    using SmartHome;
    public partial class Main : System.Web.UI.Page
    {
        private List<Device> devices;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                ClimatDevicesButton.Click += On_Click;
                LightingButton.Click += On_Click;
                WindowsButton.Click += On_Click;
                SaunaButton.Click += On_Click;
                SecurityButton.Click += On_Click;
            }
            else
            {
                devices = new List<Device>();
                devices.Add(new SecurityAlarm("SA", false, false, false));
                devices.Add(new Lighting("lamp", false, Adjustment.medium));
                devices.Add(new Conditioner("Cond", false, Adjustment.medium, false));
                devices.Add(new HeatingSystem("Batareya", false, Adjustment.medium));
                devices.Add(new Jalousie("Jalousie", false));
                devices.Add(new Sauna("Sauna", false, Adjustment.low, Adjustment.medium));
            }
        }

        protected void On_Click(object sender, EventArgs e)
        {

        }                
    }
}