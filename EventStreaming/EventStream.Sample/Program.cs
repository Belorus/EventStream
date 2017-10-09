using System;
using System.IO;
using System.Linq;
using EventStreaming.Configuration;

namespace EventStream.Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new Arguments();
            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                using (var file = File.OpenRead(options.InputConfig))
                {
                    var parser = new ConfigParser(file);
                    var config = parser.ReadFullConfig();

                    var generator = new EventsGenerator(options.ClassName, options.Namespace, config.AllEvents.Values.ToArray());

                    File.WriteAllText(options.OutputClass, generator.TransformText());
                }
            }
            else
            {
                var helpText = CommandLine.Text.HelpText.AutoBuild(options).ToString();
                Console.WriteLine(helpText);
            }
        }
    }
}
