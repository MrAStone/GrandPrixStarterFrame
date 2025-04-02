using System.Device.Gpio;
namespace GrandPrixStarterFrame
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            //pi5
            GpioController c = new();
            //pi4
            // GpioController c = new GpioController(PinNumberingScheme.Board);
            c.OpenPin(21, PinMode.InputPullUp);
          
            int pin = 0;
            int[] leds = { 16, 20, 26, 19, 13 };
            Random rng = new Random();
            while (true)
            {
                PinValue buttonState = c.Read(21);
                if (buttonState == PinValue.Low)
                {

                    for (int i = 0; i < leds.Length; i++)
                    {
                        pin = leds[i];

                        c.OpenPin(pin, PinMode.Output);
                        c.Write(pin, PinValue.High);
                        Thread.Sleep(rng.Next(1000, 3000));

                    }
                    Thread.Sleep(rng.Next(1000, 3000));
                    for (int i = 0; i < leds.Length; i++)
                    {

                        pin = leds[i];
                        c.OpenPin(pin, PinMode.Output);

                        c.Write(pin, PinValue.Low);
                    }

                }
            }
        }

        }
}
