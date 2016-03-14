using Windows.Devices.Gpio;

namespace Blinky.BlinkingLights
{
    public class SingleLight : ILights
    {
        private const int LED_PIN = 5;
        private GpioPin _pin;
        private GpioPinValue _pinValue;

   
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
            _pinValue = GpioPinValue.High;
            _pin.Write(_pinValue);
            _pin.SetDriveMode(GpioPinDriveMode.Output);
            return _pin != null;
        }

        public void Blink()
        {
            if (_pinValue == GpioPinValue.High)
            {
                _pinValue = GpioPinValue.Low;
                _pin.Write(_pinValue);
            }
            else
            {
                _pinValue = GpioPinValue.High;
                _pin.Write(_pinValue);
            }
        }
    }
}
