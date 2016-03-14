using System.Diagnostics;
using Windows.Devices.Gpio;

namespace Blinky.BlinkingLights
{
    public class TwoLights : ILights
    {
        private const int GREEN_PIN = 5;
        private const int RED_PIN = 19;

        private GpioPin _greenPin, _redPin;

        public bool InitGpio()
        {
            var gpio = GpioController.GetDefault();

            // Show an error if there is no GPIO controller
            if (gpio == null)
            {
                return false;
            }
            _greenPin = gpio.OpenPin(GREEN_PIN);
            _redPin = gpio.OpenPin(RED_PIN);

            _greenPin.Write(GpioPinValue.High);
            _redPin.Write(GpioPinValue.Low);

            _redPin.SetDriveMode(GpioPinDriveMode.Output);
            _greenPin.SetDriveMode(GpioPinDriveMode.Output);
            return _redPin != null && _greenPin != null;
        }

        public void Blink()
        {
            var greenPinValue = _greenPin.Read();
            var redPinValue = _redPin.Read();

            _greenPin.Write(redPinValue);
            _redPin.Write(greenPinValue);

            Debug.WriteLine("Green:{0}", greenPinValue);
            Debug.WriteLine("Red: {0}", redPinValue);
        }
    }
}