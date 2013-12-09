using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommandLine;
using CommandLine.Text;

namespace GZipText.CommandLine
{
  internal class Options
  {
    public enum Actions
    {
      Compress,
      Decompress
    }
    
    [Option('o', "output", HelpText = "File to write output to", Required = true)]
    public string OutputFile { get; set; }

    [Option('i', "input", HelpText = "Input file", Required = true)]
    public string InputFile { get; set; }

    [Option('a', "action", HelpText = "Action to perform (compress, decompress)", Required = true)]
    public Actions Action { get; set; }

    [HelpOption]
    public string GetUsage()
    {
      var help = new HelpText
        {
          Heading = new HeadingInfo("gxtxt-cli - Tool for working with gztxt files"),
          Copyright = new CopyrightInfo("Adam Caudill", 2013),
          AddDashesToOption = true
        };
      help.AddPreOptionsLine("Example: gztxt-cli.exe -o test.gztxt -i test.txt -a compress");
      help.AddOptions(this);

      return help;
    }
  }
}
