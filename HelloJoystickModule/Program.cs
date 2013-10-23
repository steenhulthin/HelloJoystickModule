using System;
using System.Collections;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation;
using Microsoft.SPOT.Presentation.Controls;
using Microsoft.SPOT.Presentation.Media;
using Microsoft.SPOT.Presentation.Shapes;
using Microsoft.SPOT.Touch;

using Gadgeteer.Networking;
using GT = Gadgeteer;
using GTM = Gadgeteer.Modules;
using Gadgeteer.Modules.GHIElectronics;

namespace HelloJoystickModule
{
    public partial class Program
    {
        // This method is run when the mainboard is powered up or reset.   
        void ProgramStarted()
        {
            // Use Debug.Print to show messages in Visual Studio's "Output" window during debugging.
            Debug.Print("Program Started");

            var timer = new GT.Timer(100);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        // This will be the main loop.
        void timer_Tick(GT.Timer timer)
        {
            // Get the Joystick position.
            var joystickPosition = joystick.GetPosition();
            // Present the x-position as a LED turned on relative to the position
            led_Strip.TurnAllLedsOff();
            var positionAsLed = ((joystickPosition.X + 1.0)*3).ToString("F0");
            Debug.Print(positionAsLed);
            //((joystickPosition.X + 1)*3.5).ToString("G")
            var led = int.Parse(positionAsLed);
            led_Strip.TurnLEDOn(led);
            // Present the y-position as a frequency on the tunes module
            // Get the Joystick button state
            // Present the joystick button state as the main board LED on/off
        }
    }
}
