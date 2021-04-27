using McMaster.Extensions.CommandLineUtils;
using System;

namespace Toorun.Common
{
    public static class AppExtensions
    {
        public static void AddAppVersion(this CommandLineApplication app)
        {
            app.Command("version", v =>
            {
                v.OnExecute(() =>
                {
                    Console.WriteLine("\n Current version: 0.1");
                    Console.WriteLine(" Developed by: Mazdak Shojaie");
                    Console.WriteLine(" Issues and pull requests: " + "https://github.com/hrsh/Toorun" + "\n");
                });
            });
        }
    }
}
