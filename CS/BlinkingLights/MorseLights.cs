using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.Devices.Gpio;
using Blinky.Helpers;

namespace Blinky.BlinkingLights
{
    public class MorseLights : ILights
    {
        private const int LED_PIN = 5;
        private GpioPin _pin;

        public bool InitGpio()
        {
            var gpio = GpioController.GetDefault();

            // Show an error if there is no GPIO controller
            if (gpio == null)
            {
                _pin = null;
                return false;
            }
            _pin = gpio.OpenPin(LED_PIN);
            _pin.Write(GpioPinValue.Low);
            _pin.SetDriveMode(GpioPinDriveMode.Output);
            return _pin != null;
        }

        public void Blink()
        {
            var morseTest = "SOS".ConvertToMorse();
            foreach (var c in morseTest.ToCharArray())
            {
                if (c.Equals('.'))
                {
                    BlinkDot();
                }
                else if (c.Equals('-'))
                {
                    BlinkDash();
                }
                else if (c.Equals(' '))
                {
                    BlinkBlank();
                }
            }

            Debug.WriteLine(string.Empty);
            Task.Delay(TimeSpan.FromSeconds(4)).Wait();
        }

        private void BlinkBlank()
        {
            Debug.Write(' ');
            Task.Delay(TimeSpan.FromSeconds(0.2)).Wait();
        }

        private void BlinkDot()
        {
            _pin.Write(GpioPinValue.Low);
            Task.Delay(TimeSpan.FromSeconds(0.2)).Wait();
            _pin.Write(GpioPinValue.High);
            Task.Delay(TimeSpan.FromSeconds(0.2)).Wait();
            Debug.Write(".");

        }

        private void BlinkDash()
        {
            _pin.Write(GpioPinValue.Low);
            Task.Delay(TimeSpan.FromSeconds(0.7)).Wait();
            _pin.Write(GpioPinValue.High);
            Task.Delay(TimeSpan.FromSeconds(0.2)).Wait();
            Debug.Write("-");

        }
    }
}
