using YamlDotNet.Serialization;

namespace Toorun.Models.JointShearModels
{
    public class JointShearInputModel
    {
        public Facts Facts { get; set; }

        public Props Props { get; set; }

        public Specs Specs { get; set; }

        public Builds Builds { get; set; }
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

        public double Story { get; set; }

        public Units Units { get; set; }
    }

    public class Units
    {
        public string Force { get; set; }

        public string Length { get; set; }

        public string Temp { get; set; }
    }

    public class Specs
    {
        [YamlMember(Alias = "beam-left", ApplyNamingConventions = false)]
        public Section BeamLeft { get; set; }

        [YamlMember(Alias = "beam-right", ApplyNamingConventions = false)]
        public Section BeamRight { get; set; }

        [YamlMember(Alias = "col", ApplyNamingConventions = false)]
        public Section Column { get; set; }
    }

    public class Section
    {
        [YamlMember(Alias = "b", ApplyNamingConventions = false)]
        public double Width { get; set; }

        [YamlMember(Alias = "h", ApplyNamingConventions = false)]
        public double Height { get; set; }

        [YamlMember(Alias = "main-steel-top", ApplyNamingConventions = false)]
        public Rc MainSteelTop { get; set; }

        [YamlMember(Alias = "main-steel-bot", ApplyNamingConventions = false)]
        public Rc MainSteelBot { get; set; }

        [YamlMember(Alias = "add-steel-top", ApplyNamingConventions = false)]
        public Rc AddSteelTop { get; set; }

        [YamlMember(Alias = "add-steel-bot", ApplyNamingConventions = false)]
        public Rc AddSteelBot { get; set; }
    }

    public class Rc
    {
        [YamlMember(Alias = "s", ApplyNamingConventions = false)]
        public int Size { get; set; }

        [YamlMember(Alias = "n", ApplyNamingConventions = false)]
        public int Count { get; set; }
    }

    public class Builds
    {
        public int Step { get; set; }

        public double Laps { get; set; }
    }
}
