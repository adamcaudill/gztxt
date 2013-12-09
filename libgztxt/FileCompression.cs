using System.IO;
using System.IO.Compression;

namespace GZipText.Library
{
  public static class FileCompression
  {
    public static void CompressFile(string source, string destination)
    {
      var sourceInfo = new FileInfo(source);

      using (var fs = sourceInfo.OpenRead())
      {
        using (var destStream = File.Create(destination))
        {
          using (var gzip = new GZipStream(destStream, CompressionMode.Compress))
          {
            fs.CopyTo(gzip);
          }
        }
      }
    }

    public static void ExtractFile(string source, string destination)
    {
      var sourceInfo = new FileInfo(source);

      using (var fs = sourceInfo.OpenRead())
      {
        using (var destStream = File.Create(destination))
        {
          using (var gzip = new GZipStream(fs, CompressionMode.Decompress))
          {
            gzip.CopyTo(destStream);
          }
        }
      }
    }
  }
}
