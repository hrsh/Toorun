using McMaster.Extensions.CommandLineUtils;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Toorun.Funcs.JointShearFuncs;
using Toorun.Helps;
using Toorun.Models.JointShearModels;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Toorun.Commands.JointShear
{
    public static class JointShearCommand
    {
        public static void AddJointShearCommand(this CommandLineApplication app)
        {
            app.Command("joint-shear", jointshear =>
            {
                jointshear.AddDefaultHelpOption("Joint shear module");
                jointshear.AddApplyCommand();
            });
        }

        private static CommandLineApplication AddApplyCommand(this CommandLineApplication app)
        {
            var apply = app.Command("apply", apply =>
            {
                apply.AddDefaultHelpOption();

                var filePath = apply.Option(
                    "-f|--file", "Path to source file",
                    CommandOptionType.SingleValue, cfg =>
                    {
                        cfg.IsRequired(false);
                        cfg.Accepts(x => x.ExistingFile());
                    });

                var output = apply.Option(
                    "-o|--output", "Define output type",
                    CommandOptionType.SingleValue, cfg =>
                    {
                        cfg.Accepts(x => x.Values("display", "file"));
                    });

                var name = apply.Option(
                    "-n|--name", "Define output file name. This value required only if output is set to [File].",
                    CommandOptionType.SingleValue, cfg =>
                    {
                        if (output.HasValue())
                            if (output.Value() == "file")
                                cfg.IsRequired(false);
                    });

                apply.OnExecuteAsync(async ct =>
                {
                    var source = await File.ReadAllTextAsync(filePath.Value(), ct);
                    var deserializer = new DeserializerBuilder()
                        .WithNamingConvention(CamelCaseNamingConvention.Instance)
                        .Build();
                    var jointShearModel = deserializer.Deserialize<JointShearInputModel>(source);
                    var result = Calculate.CalculateJointShear(jointShearModel);
                    Console.WriteLine(result.ToString());
                    Console.WriteLine(output.Value() + "." + name.Value());
                });
            });

            return apply;
        }
    }
}
