using System;

using CommandLine;
using CommandLine.Text;

using GZipText.Library;

namespace GZipText.CommandLine
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var options = new Options();
      if (Parser.Default.ParseArguments(args, options))
      {
        switch (options.Action)
        {
          case Options.Actions.Compress:
            FileCompression.CompressFile(options.InputFile, options.OutputFile);
            Console.WriteLine("Complete.");
            break;
          case Options.Actions.Decompress:
            FileCompression.ExtractFile(options.InputFile, options.OutputFile);
            Console.WriteLine("Complete.");
            break;
          default:
            Console.WriteLine("Error, you shouldn't see this. Contact the developer.");
            break;
        }
      }
    }
  }
}
