using System;
using System.IO.Ports;
using ThermalDotNet;

namespace WPCordovaClassLib.Cordova.Commands
{
    public class ThermalCordova : BaseCommand
    {
        public void ToUpper(string options)
        {
            string printerPortName = "COM4";// "/dev/tty.usbserial-A600dP3F";
            //test2();
            //return;
            //Serial port init
            SerialPort printerPort = new SerialPort(printerPortName, 9600);
            if (printerPort != null)
            {
                Console.WriteLine("Port ok");
                if (printerPort.IsOpen)
                {
                    printerPort.Close();
                }
            }

            Console.WriteLine("Opening port");

            try
            {
                printerPort.Open();
            }
            catch
            {
                Console.WriteLine("I/O error");
                Environment.Exit(0);
            }

            //Printer init
            ThermalPrinter printer = new ThermalPrinter(printerPort,31,180,2);

            printer.WakeUp();
            Console.WriteLine(printer.ToString());

            printer.WriteLineSleepTimeMs = 200;
            printer.LineFeed(3);
            //TestImage(printer);
            //printer.PrintImage(@"../../../pal1.bmp");
            //TestQRCode(printer);
            printer.WriteLine("Testing time: " + DateTime.Now.ToLongTimeString());
            printer.LineFeed(3);

            printer.Sleep();
            Console.WriteLine("Printer is now offline.");
            printerPort.Close();



            string upperCase = JSON.JsonHelper.Deserialize<string[]>(options)[0].ToUpper();
            PluginResult result;
            if (upperCase != "")
            {
                result = new PluginResult(PluginResult.Status.OK, upperCase);
            } else
            {
                result = new PluginResult(PluginResult.Status.ERROR, upperCase);
            }

            DispatchCommandResult(result);
        }
    }
}