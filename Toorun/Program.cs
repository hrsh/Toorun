using McMaster.Extensions.CommandLineUtils;
using System;
using System.Runtime.Serialization;
using Toorun.Commands.JointShear;
using Toorun.Common;
using YamlDotNet.Core;

var app = new CommandLineApplication();
app.HelpOption("-h|--help");
app.AddAppVersion();

app.AddJointShearCommand();

try
{
    return app.Execute(args);
}
//catch (YamlException y)
//{
//    Console.WriteLine(y.Message);
//    return -1;
//}
//catch (SerializationException s)
//{
//    Console.WriteLine(s.Message);
//    return -1;
//}
catch (Exception e)
{
    Console.WriteLine("\n----------------------------------------------");
    Console.WriteLine(e.ToString());
    Console.WriteLine("\n----------------------------------------------");
    return -1;
}