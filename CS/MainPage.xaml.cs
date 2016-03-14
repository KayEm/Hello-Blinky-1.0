// Copyright (c) Microsoft. All rights reserved.

using Blinky.BlinkingLights;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Blinky
{
    public sealed partial class MainPage : Page
    {
        private readonly ILights _blinker = new MorseLights();

        public MainPage()
        {
            InitializeComponent();

            var timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(500)
            };
            timer.Tick += Timer_Tick;
            var blinkerInitialized = _blinker.InitGpio();
            if (blinkerInitialized)
            {
                timer.Start();
            }        
        }
        private void Timer_Tick(object sender, object e)
        {
            _blinker.Blink();
        }
    }
}
