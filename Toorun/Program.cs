using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using McMaster.Extensions.CommandLineUtils;
using Newtonsoft.Json;
using Toorun;
using Toorun.Commands.JointShear;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;








//var subject = app.Option("-s|--subject <SUBJECT>", "The subject", CommandOptionType.SingleValue);
//subject.ShowInHelpText = true;

//var repeat = app.Option<int?>("-n|--count <N>", "Repeat", CommandOptionType.SingleValue);
//repeat.DefaultValue = 1;

//app.Command1();
//app.Command2();

//app.OnExecute(() =>
//{
//    for (var i = 0; i < repeat.ParsedValue; i++)
//    {
//        Console.WriteLine($"Hello {subject.Value()}!");
//    }
//});


var app = new CommandLineApplication();
app.HelpOption();

app.AddJointShearCommand();
app.Command1();
//Prompt.GetYesNo("Login?", false);
//Prompt.GetPasswordAsSecureString("Enter your password: ");
try
{
    return app.Execute(args);
}
//catch (YamlDotNet.Core.YamlException y)
//{
//    Console.WriteLine(y.Message);
//    return -1;
//}
//catch (System.Runtime.Serialization.SerializationException s)
//{
//    Console.WriteLine(s.Message);
//    return -1;
//}
catch (Exception e)
{
    Console.WriteLine("\n-------------------------------------------");
    Console.WriteLine(e.ToString());
    Console.WriteLine("\n-------------------------------------------");
    return -1;
}