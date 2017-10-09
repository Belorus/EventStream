using CommandLine;

namespace EventStream.Generator
{
    public class Arguments
    {
        [Option("i", Required = true)]
        public string InputConfig { get; set; }

        [Option("o", Required = true)]
        public string OutputClass { get; set; }

        [Option("c", Required = true)]
        public string ClassName { get; set; }

        [Option("n", Required = true)]
        public string Namespace { get; set; }
    }
}