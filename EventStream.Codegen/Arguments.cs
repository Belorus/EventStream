using CommandLine;

namespace EventStream.Codegen
{
    internal class Arguments
    {
        [Option('i', "inputConfig", Required = true)]
        public string InputConfig { get; set; }

        [Option('o', "outputClassFile", Required = true)]
        public string OutputClass { get; set; }

        [Option('c', "className", Required = true)]
        public string ClassName { get; set; }

        [Option('n', "namespace", Required = true)]
        public string Namespace { get; set; }
    }
}