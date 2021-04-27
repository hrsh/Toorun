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
                apply.AddDefaultHelpOption(@"
 example:
    toorun joint-shear apply -f input.yml -o display -n output.txt

 Description of definiton file:
 --facts: holds all design forces
    p: axial force
    n: tensial force
    vx: shear force in X direction
    vy: shear force in Y direction
    mx: moment around X direction
    my: monent around Y direction

 --props: holds material properties and units
    fc: concrete 
    fy: rebar yield stress
    fyx: shear rebar yield stress
    --units:
        force: force unit (kgf,tonf,lb ...)
        length: length unit (m, cm, mm, in ...)
        temp: temprature unit (c,f) [currently is not applicable]

 --specs: defines members
    for each joint, you could define 4 beams, 2 in each main direction, incliding:
        beam-left: the left side beam
        right-beam: the right side beam
        top-beam: the top beam (recognized as right beam, if joint rotated 90 deg)
        bot-beam: the bottom beam (recognized as left beam, if joint rotated 90 deg)

    All sections must define all expected params, described bellow:
        b: beam width
        h: beam height (along global Z direction)
        main-steel-top: top longitude steel rebars, including:
            s: the size of rebar (which means the diameter of rebar)
            n: number of rebar(s)
        main-steel-bot: bottom longitude steel rebars, including:
            s: the size of rebar (which means the diameter of rebar)
            n: number of rebar(s)
    
");

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
                    //var result = JointShearCalculation
                    //.CalculateJointShear(jointShearModel, output, name);
                    //Console.WriteLine(result.P);
                    foreach (var s in jointShearModel.Joints)
                    {
                        var p = s.Split(' ');
                        foreach (var x in p)
                            Console.WriteLine(x);
                    }
                });
            });

            return apply;
        }
    }
}
