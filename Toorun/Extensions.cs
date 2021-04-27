using McMaster.Extensions.CommandLineUtils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toorun
{
    public static class Extensions
    {
        public static void Command1(this CommandLineApplication app)
        {
            var m = app.Command("go", go =>
            {
                go.HelpOption("-h");
                var optionA = go.Option("-a", "Option a", CommandOptionType.SingleValue);
                var optionB = go.Option("-b", "Option b", CommandOptionType.SingleValue);
                var c = go.Argument<string>("c", "Argument c", c =>
                {
                    c.Accepts(acc => acc.ExistingFile());
                });
                //go.OnExecute(() =>
                //{
                //    var t = File.ReadAllText(c.Value);
                //    Console.WriteLine(t);
                //    Console.WriteLine(optionA.Value());
                //});

                go.OnExecuteAsync(async ct =>
                {
                    var t = await File.ReadAllTextAsync(c.Value, ct);
                    Console.WriteLine(t);
                });
            });
        }
        public static CommandLineApplication Command2(this CommandLineApplication app)
        {
            var m = app.Command("run", go =>
            {
                go.HelpOption("-h");
                var optionA = go.Option("-a1", "Option a1", CommandOptionType.SingleValue);
                var optionB = go.Option("-b1", "Option b1", CommandOptionType.SingleValue);
                var optionC = go.Option<double>("-c1", "Option c1", CommandOptionType.SingleValue);
                var c = go.Argument<string>("c1", "Argument c1", c =>
                {
                    c.Accepts(acc => acc.ExistingFile());
                });
                go.OnExecute(() =>
                {
                    var t = File.ReadAllText(c.Value);
                    Console.WriteLine(t);
                    Console.WriteLine(optionA.Value());
                });
            });

            return m;
        }
    }
}
