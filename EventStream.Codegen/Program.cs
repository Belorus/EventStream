using System;
using System.IO;
using System.Linq;
using CommandLine;
using CommandLine.Text;
using EventStream.Configuration;

namespace EventStream.Codegen
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var options = new Arguments();
            if (Parser.Default.ParseArguments(args, options))
            {
                using (var file = File.OpenRead(options.InputConfig))
                {
                    var parser = new ConfigParser(file);
                    var config = parser.ReadFullConfig();

                    var generator = new EventsGenerator(
                        options.ClassName,
                        options.Namespace,
                        config.AllEvents.Values.ToArray(),
                        config.AmbientFieldDefinitions);

                    File.WriteAllText(options.OutputClass, generator.TransformText().Trim());

                    Console.WriteLine($"Saved config with {config.AllEvents.Count} events and {config.AmbientFieldDefinitions.Count} ambient fields to {Path.GetFullPath(options.OutputClass)}");
                }
            }
            else
            {
                var helpText = HelpText.AutoBuild(options).ToString();
                Console.WriteLine(helpText);
            }
        }
    }
}