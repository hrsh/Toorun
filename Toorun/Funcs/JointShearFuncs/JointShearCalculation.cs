using ConsoleTables;
using McMaster.Extensions.CommandLineUtils;
using System;
using Toorun.Models.JointShearModels;

namespace Toorun.Funcs.JointShearFuncs
{
    public class JointShearCalculation
    {
        public static JointShearOutputModel CalculateJointShear(
            JointShearInputModel model,
            CommandOption output,
            CommandOption name = null)
        {
            Console.WriteLine();
            var table = new ConsoleTable(
                $"P ({model.Props.Units.Force})", 
                $"N ({model.Props.Units.Force})", 
                $"Vx ({model.Props.Units.Force})", 
                $"Vy ({model.Props.Units.Force})",
                $"Mx ({model.Props.Units.Force}.{model.Props.Units.Length})",
                $"My ({model.Props.Units.Force}.{model.Props.Units.Length})");
            table.AddRow(
                model.Facts.P,
                model.Facts.N,
                model.Facts.Vx,
                model.Facts.Vy,
                model.Facts.Mx,
                model.Facts.My);
            table.Write(Format.Alternative);
            return new()
            {
                P = $"{model.Facts.P + Math.Abs(model.Facts.N)} {model.Props.Units.Force}.{model.Props.Units.Length}"
            };
        }
    }
}
