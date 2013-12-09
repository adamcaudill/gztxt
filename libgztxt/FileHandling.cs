using System.Diagnostics;
using System.IO;
using System.Threading;

namespace GZipText.Library
{
  public static class FileHandling
  {
    public static string DecompressToTempFile(string source)
    {
      //bug: this will fail if the file already exists
      var tempFile = Path.GetTempFileName() + ".txt";
      FileCompression.ExtractFile(source, tempFile);

      return tempFile;
    }

    public static string CreateCompressedCopy(string source)
    {
      var sourceInfo = new FileInfo(source);
      var dest = source.Remove(source.Length - sourceInfo.Extension.Length) + ".gztxt";

      if (File.Exists(dest))
      {
        File.Delete(dest);
      }

      FileCompression.CompressFile(source, dest);
      return dest;
    }

    public static void DecompressLaunchWait(string source)
    {
      var txt = DecompressToTempFile(source);
      var proc = Process.Start(txt);

      while (proc != null && !proc.HasExited)
      {
        Thread.Sleep(1000);
      }

      File.Delete(txt);
    }
  }
}
