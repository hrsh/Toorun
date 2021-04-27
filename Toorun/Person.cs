using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toorun
{
    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public Facts Facts { get; set; }

        public Props Props { get; set; }

        public Outputs Outputs { get; set; }
    }

    public class Facts
    {

        public double P { get; set; }

        public double N { get; set; }

        public double Vx { get; set; }

        public double Vy { get; set; }

        public double Mx { get; set; }

        public double My { get; set; }
    }

    public class Props
    {
        public double Fc { get; set; }

        public double Fy { get; set; }

        public double Fys { get; set; }

        public Units Units { get; set; }
    }

    public class Units
    {
        public string Force { get; set; }

        public string Lenght { get; set; }

        public string Temp { get; set; }
    }

    public class Outputs
    {
        public OutputType Output { get; set; }

        public OutputFormatType Format { get; set; }
    }

    public enum OutputType
    {
        File,
        Display,
        None
    }

    public enum OutputFormatType
    {
        Json,
        Xml,
        Text
    }
}
