using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DZ_2
{
    public class Menu
    {
        private List<Device> devices;
        public void MainMenu()
        {
            devices = new List<Device>();
            devices.Add(new SecurityAlarm("SA", false,false,false));
            devices.Add(new Lighting("lamp", false, Adjustment.medium));
            devices.Add(new Conditioner("Cond", false, Adjustment.medium, false));
            devices.Add(new HeatingSystem("Batareya", false, Adjustment.medium));
            devices.Add(new Jalousie("Jalousie", false));
            devices.Add(new Sauna("Sauna", false, Adjustment.low, Adjustment.medium));
            Console.SetWindowSize(120,30);
            while (true)
            {
                Console.Clear();
                var types = (devices.GroupBy(t => t.GetType().Name)).OrderBy(t => t.Key);  // Группировка и упорядочивание по типу устройства
                foreach (var tDev in types)
                {
                    Console.WriteLine();
                    Console.WriteLine(tDev.Key + ":");
                    foreach (var dev in tDev)
                    {
                        Console.WriteLine("\t-" + dev.Info());
                    }
                }

                Console.WriteLine();
                Console.Write("Введите команду: ");
                string[] commands = Console.ReadLine().Split(' ');
                //----------------------Conditions for command add-------------------------
                var addNameChecker = from name in devices where (name.GetName().ToLower() == commands[2].ToLower()) select name;
                if (commands[0].ToLower() == "add" && commands.Length != 3)
                {
                    Help();
                    continue;
                }
                if (commands[0].ToLower() == "add" && (addNameChecker.Count() == 0))
                {
                    switch (commands[1].ToLower())
                    {
                        case "securityalarm":
                            devices.Add(new SecurityAlarm(commands[2], false, false,false));
                            break;
                        case "lighting":
                            devices.Add(new Lighting(commands[2], false, Adjustment.medium));
                            break;
                        case "conditioner":
                            devices.Add(new Conditioner(commands[2], false, Adjustment.medium,false));
                            break;
                        case "heatingsystem":
                            devices.Add(new HeatingSystem(commands[2], false, Adjustment.medium));
                            break;
                        case "jalousie":
                            devices.Add(new Jalousie(commands[2], false));
                            break;
                        case "sauna":
                            devices.Add(new Sauna(commands[2], false, Adjustment.low, Adjustment.medium));
                            break;
                        default:
                            Console.WriteLine("Не верный тип устройства!!!");
                            Console.ReadLine();
                            break;
                    }
                    continue;

                }
                if (commands[0].ToLower() == "add" && (addNameChecker.Count() != 0))
                {
                    Console.WriteLine("Устройство с таким именем уже существует");
                    Console.WriteLine("Нажмите любую клавишу для продолжения");
                    Console.ReadLine();
                    continue;
                }
                //----------------------------------------------------------------------------------
                var nameChecker = from name in devices where (name.GetName().ToLower() == commands[1].ToLower()) select name;   // проверка существования имени устройства
                var typeChecker = from type in types where (type.Key.ToLower() == commands[1].ToLower()) select type;       // проверка существования типа устройства
                if (commands[0].ToLower() == "exit")
                {
                    return;
                }
                if (commands.Length != 2)
                {
                    Help();
                    continue;
                }                
                switch (commands[0].ToLower())
                {
                    case "del":
                        {
                            if (nameChecker.Count() == 0)   // Проверка существования устройства с указанным именем
                            {
                                Help();
                                continue;
                            }
                            devices.Remove((Device)nameChecker.First());
                            break;
                        }
                    case "on":
                        {
                            if (nameChecker.Count() == 0)   
                            {
                                Help();
                                continue;
                            }
                            nameChecker.First().On();
                            break;
                        }
                    case "off":
                        {
                            if (nameChecker.Count() == 0)   
                            {
                                Help();
                                continue;
                            }
                            nameChecker.First().Off();
                            break;
                        }
                    case "set":        
                        {
                            if (typeChecker.Count() != 0)
                               settingsMenu(commands[1].ToLower());                               
                            else
                            {
                                Console.WriteLine("Устройства указанного типа не найдены!");
                                Console.ReadLine();
                            }
                            break;
                        }
                        
                    default:
                        Help();
                        break;
                }
            }
        }
        private void settingsMenu( string devType )
        {           
            while (true)
            {
                Console.Clear();
                Console.WriteLine(devType + ":");
                var selectedDev = devices.Where(t => t.GetType().Name.ToLower() == devType);
            
                foreach (var dev in selectedDev)
                {
                    Console.WriteLine("\t-" + dev.Info());
                }
                Console.WriteLine();
                Console.WriteLine("Команды для управления : ");
                Console.WriteLine();
                if (selectedDev.First() is Iluminous)
                {
                    Console.WriteLine("deviceName lowBr -установить слабую яркость освещения");
                    Console.WriteLine("deviceName mediumBr - установить среднюю яркость освещения");
                    Console.WriteLine("deviceName highBr - установить высокую яркость освещения");                    
                }
                if (selectedDev.First() is SecurityAlarm)
                {
                    Console.WriteLine("deviceName OnMS - включить датчик движения");
                    Console.WriteLine("deviceName OffMS - выключить датчик движения");
                    Console.WriteLine("deviceName OnCCTV - включить видеонаблюдение");                    
                    Console.WriteLine("deviceName OffCCTV - выключить видеонаблюдение");   
                }
                if (selectedDev.First() is ClimatDevice)
                {                    
                    Console.WriteLine("deviceName lowTM -установить низкий температурный режим");
                    Console.WriteLine("deviceName mediumTM - установить средний температурный режим");
                    Console.WriteLine("deviceName highTM - установить высокий температурный режим");
                }
                if (selectedDev.First() is Conditioner)
                {
                    Console.WriteLine("deviceName onHum -включить увлажнитель");
                    Console.WriteLine("deviceName offHum -выключить увлажнитель");                    
                }
                if (selectedDev.First() is ITimer)
                {
                    Console.WriteLine("deviceName timeron sec. -запустить таймер включения");
                    Console.WriteLine("deviceName timeroff sec. -запустить таймер отключения");
                }
                Console.WriteLine("back - вернуться в предыдущее меню");
                Console.WriteLine();
                Console.Write("Введите команду: ");
                string[] commands = Console.ReadLine().Split(' ');
                var setDev = (selectedDev.Where(d => d.GetName().ToLower() == commands[0].ToLower()));
                if (commands[0].ToLower() == "back") 
                    return;
                if ((commands.Length != 2) && (commands.Length != 3))
                {
                    continue;
                }
                if (setDev.Count() == 0)
                {
                    Console.WriteLine("Устройство с таким именем не найдено!");                    
                    Console.ReadLine();
                    continue;
                }
                if (setDev.First() is Iluminous)
                {
                    Iluminous lightTemp = setDev.First() as Iluminous;
                    switch (commands[1].ToLower())
                    {
                        case "highbr":
                            {
                                lightTemp.SetHighBrightness();
                                break;
                            }
                        case "mediumbr":
                            {
                                lightTemp.SetMediumBrightness();
                                break;
                            }
                        case "lowbr":
                            {
                                lightTemp.SetLowBrightness();
                                break;
                            }
                        default : break;
                            
                    }
                }
                if (setDev.First() is ITimer)
                {
                    ITimer timerTemp = setDev.First() as ITimer;
                    if (commands[1].ToLower() == "timeron" && commands.Length == 3)
                    {
                        timerTemp.TimerOn(Int32.Parse(commands[2]));
                    }
                    if (commands[1].ToLower() == "timeroff" && commands.Length == 3)
                    {
                        timerTemp.TimerOff(Int32.Parse(commands[2]));
                    }
                }
                if (setDev.First() is ClimatDevice)
                {
                    ClimatDevice climatTemp = setDev.First() as ClimatDevice;
                    switch (commands[1].ToLower())
                    {                        
                        case "hightm":
                            {
                                climatTemp.SetHighTemperatureMode();
                                break;
                            }
                        case "mediumtm":
                            {
                                climatTemp.SetMediumTemperatureMode();
                                break;
                            }
                        case "lowtm":
                            {
                                climatTemp.SetLowTemperatureMode();
                                break;
                            }
                        default: break;
                            
                    }
                }
                if (setDev.First() is Conditioner)
                {
                    Conditioner condTemp = setDev.First() as Conditioner;
                    switch (commands[1].ToLower())
                    {
                        case "onhum":
                            {
                                condTemp.OnHumidifire();
                                break;
                            }
                        case "offhum":
                            {
                                condTemp.OffHumidifire();
                                break;
                            }
                       
                        default: break;
                            
                    }
                }
                if (setDev.First() is SecurityAlarm)
                {
                    SecurityAlarm saTemp = setDev.First() as SecurityAlarm;
                    switch (commands[1].ToLower())
                    {
                        case "onms":
                            {
                                saTemp.OnMotionSensor();
                                break;
                            }
                        case "offms":
                            {
                                saTemp.OffMotionSensor();
                                break;
                            }
                        case "oncctv":
                            {
                                saTemp.OnCCTV();
                                break;
                            }
                        case "offcctv":
                            {
                                saTemp.OffCCTV();
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Неверная команда");
                                Console.ReadLine();
                                break;
                            }
                    }
                }                
            }            
        }
        private static void Help()
        {
            Console.WriteLine();
            Console.WriteLine("Доступные команды:");
            Console.WriteLine("\tadd deviceType deviceName");
            Console.WriteLine("\tdel deviceName");
            Console.WriteLine("\ton deviceName");
            Console.WriteLine("\toff deviceName");
            Console.WriteLine("\tset deviceType");
            Console.WriteLine("\texit");
            Console.WriteLine("Нажмите любую клавишу для продолжения");
            Console.ReadLine();
        }
    }
}
