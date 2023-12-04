using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameWindowSettings gSettings = new GameWindowSettings();
            NativeWindowSettings nSettings = new NativeWindowSettings()
            {
                Title = "Snake",
                Size = (800, 600),
                Flags = ContextFlags.Default,
                Profile = ContextProfile.Compatability,
            };

            Game game = new Game(gSettings, nSettings);
         
                game.Run();
           
        }
    }
}