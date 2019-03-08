[assembly: Rage.Attributes.Plugin("Scaleform Testing", Author = "Lucas Ritter", PrefersSingleInstance = true)]
namespace Scaleforms.Tests.RPH1
{
    using LucasRitter.Scaleforms.Generic;
    using Rage;

    public sealed class EntryPoint
    {
        private static Dashboard _dashboard;
        private static bool _shouldDraw = false;
        public static void Main()
        {
            _dashboard = new Dashboard();
            
            Game.FrameRender += Process;

            while (true)
            {
                GameFiber.Yield();
            }
        }

        private static void Process(object sender, GraphicsEventArgs e)
        {
            _dashboard.RadioArtist = World.TimeOfDay.ToString();
            
            if (_shouldDraw)
                _dashboard.Draw();
        }

        [Rage.Attributes.ConsoleCommand]
        private static void ToggleScaleformDrawing()
        {
            _shouldDraw = !_shouldDraw;
        }
    }
}