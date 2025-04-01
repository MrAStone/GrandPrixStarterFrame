using System.Device.Gpio;
namespace GrandPrixStarterFrame
{
    internal class Program
    {
        static bool done;
        static void Main(string[] args)
        {
            //pi5
            GpioController c = new();
            //pi4
            // GpioController c = new GpioController(PinNumberingScheme.Board);
            c.OpenPin(21, PinMode.InputPullUp);
            done = false;
            while (!done)
            {
                c.RegisterCallbackForPinValueChangedEvent(21, PinEventTypes.Falling, OnPinEvent);
            }
        }
        static void OnPinEvent(object sender, PinValueChangedEventArgs pinArgs)
        {
            startSequence();
        }
        static void startSequence()
        {
            //Write the code to light up 5 LEDs in sequence
            //and then turn them off


            done = true;
        }
    }
}
