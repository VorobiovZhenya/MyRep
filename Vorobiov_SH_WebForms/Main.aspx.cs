using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SmartHome;

namespace Vorobiov_SH_WebForms
{
    //using SmartHome;
    public partial class Main : System.Web.UI.Page
    {
        private List<Device> devices;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                devices = new List<Device>();
                devices.Add(new SecurityAlarm("SA", false, false, false));
                devices.Add(new Lighting("lamp", false, Adjustment.medium));
                devices.Add(new Conditioner("Cond", false, Adjustment.medium, false));
                devices.Add(new HeatingSystem("Batareya", false, Adjustment.medium));
                devices.Add(new Jalousie("Jalousie", false));
                devices.Add(new Sauna("Sauna", false, Adjustment.low, Adjustment.medium));
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
            var groupDev = (devices.GroupBy(t => t.GetType().Name)).OrderBy(t => t.Key);  // Группировка и упорядочивание по типу устройства
            switch (((Button)sender).ID)
            {
                case "ClimatDevicesButton":
                    var typeSelector = from type in groupDev where ((type.Key == "Conditioner") || (type.Key == "HeatingSystem")) select type;
                    int i = 0;
                    Label [] labels = new Label[typeSelector.Count()];
                    foreach (var selectedDev in typeSelector)
                    {                    
                    labels[i] = new Label();
                    body_content.Controls.Add(labels[i]);
                    labels[i].Text = (selectedDev.Key + " : " + selectedDev.ToString()) + "\n";
                    body_content.Controls.Add(new LiteralControl("<br />"));
                    i++;                    
                    }
                    break;
                case "LightingButoon":

                    break;
                case "WindowsButton": 

                    break;
                case "SaunaButton":

                    break;
                case "SecurityButton":

                    break;
                
            }
        }

    }
}