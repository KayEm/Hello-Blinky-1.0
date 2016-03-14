namespace Blinky.BlinkingLights
{
    public interface ILights
    {
        bool InitGpio();
        void Blink();
    }
}