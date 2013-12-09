using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GZipText.Windows
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      
      if (args.Count() == 1)
      {
        if (args[0] == "register")
        {
          try
          {
            //register the file type handler
            Library.FileAssociation.SetAssociation(".gztxt", "gztxt",
              Application.ExecutablePath, "GZTXT Compressed Text File");
            MessageBox.Show(".gztxt File Type Registered", "GZTXT");
          }
          catch (Exception ex)
          {
            MessageBox.Show("Error registering file type: " + ex, "GZTXT Error");
          }
        }
        else if (args[0] == "unregister")
        {
          try
          {
            //register the file type handler
            Library.FileAssociation.RemoveAssociation(".gztxt", "gztxt");
            MessageBox.Show(".gztxt File Type Unregistered", "GZTXT");
          }
          catch (Exception ex)
          {
            MessageBox.Show("Error unregistering file type: " + ex, "GZTXT Error");
          }
        }
        else if (File.Exists(args[0]))
        {
          //we've got a file, let's do something with it
          Library.FileHandling.DecompressLaunchWait(args[0]);
        }
        else
        {
          MessageBox.Show("Unknown option: " + args[0], "GZTXT Error");
        }
      }
      else
      {
        MessageBox.Show("Error: Invalid Options: " + Environment.CommandLine, 
          "GZTXT Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }
  }
}
