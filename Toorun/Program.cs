using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using McMaster.Extensions.CommandLineUtils;
using Newtonsoft.Json;
using Toorun;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

var app = new CommandLineApplication();


app.Command("joint-shear", jointshear =>
{
    jointshear.HelpOption();
    var apply = jointshear.Command("apply", apply =>
    {
        apply.HelpOption();
        var filePath = apply.Option("-f|--file", "The source file path", CommandOptionType.SingleValue);
        filePath.IsRequired();
        apply.OnExecute(() =>
        {
            var yml = @"
name: George Washington
age: 89
facts:
    p: 100
    n: -15
    vx: 12
    vy: -9
    mx: 13
    my: 4.9

props:
    fc: 2100
    fy: 40000
    fys: 34000
    units:
        force: ton
        lenght: m

outputs:
    output: file
    format: xml
";

            Console.WriteLine($"Reading file {filePath.Value()} @ {Environment.CurrentDirectory}");
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(new CamelCaseNamingConvention())
                .Build();
            var p = deserializer.Deserialize<Person>(yml);
            Console.WriteLine(JsonConvert.SerializeObject(
                p, 
                Formatting.Indented, 
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }));
        });
    });
});


app.HelpOption();
var subject = app.Option("-s|--subject <SUBJECT>", "The subject", CommandOptionType.SingleValue);
subject.ShowInHelpText = true;

var repeat = app.Option<int?>("-n|--count <N>", "Repeat", CommandOptionType.SingleValue);
repeat.DefaultValue = 1;

app.Command1();
app.Command2();

app.OnExecute(() =>
{
    for (var i = 0; i < repeat.ParsedValue; i++)
    {
        Console.WriteLine($"Hello {subject.Value()}!");
    }
});

try
{
    return app.Execute(args);
}
catch (Exception e)
{
    Console.WriteLine("\n-------------------------------------------");
    Console.WriteLine(e.ToString());
    Console.WriteLine("\n-------------------------------------------");
    return -1;
}