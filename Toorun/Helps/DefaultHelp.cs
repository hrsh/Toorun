using McMaster.Extensions.CommandLineUtils;

namespace Toorun.Helps
{
    public static class DefaultHelp
    {
        public static void AddDefaultHelpOption(
            this CommandLineApplication app,
            string additionalHelpText = null)
        {
            app.HelpOption("-h|--help");
            if (!string.IsNullOrEmpty(additionalHelpText))
                app.ExtendedHelpText = "\n" + additionalHelpText;
            //app.ShowHelp();
        }
    }
}
