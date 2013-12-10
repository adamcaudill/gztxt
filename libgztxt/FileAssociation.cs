using System;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace GZipText.Library
{
  public static class FileAssociation
  {
    //This code basd on the code posted here, with significant modifications:
    // http://stackoverflow.com/questions/2681878/associate-file-extension-with-application
    public static void SetAssociation(string extension, string keyName, string openWith, string fileDescription)
    {
      var baseKey = Registry.CurrentUser.OpenSubKey(@"Software\Classes", true).CreateSubKey(extension);
      baseKey.SetValue(string.Empty, keyName);

      var openMethod = Registry.CurrentUser.OpenSubKey(@"Software\Classes", true).CreateSubKey(keyName);
      openMethod.SetValue(string.Empty, fileDescription);
      openMethod.CreateSubKey("DefaultIcon").SetValue(string.Empty, "\"" + openWith + "\",0");
      var shell = openMethod.CreateSubKey("Shell");
      shell.CreateSubKey("open").CreateSubKey("command").SetValue(string.Empty, "\"" + openWith + "\"" + " \"%1\"");
      baseKey.Close();
      openMethod.Close();
      shell.Close();

      var currentUser = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\" + extension, true);
      currentUser.DeleteSubKey("UserChoice", false);
      currentUser.Close();

      // Tell explorer the file association has been changed
      SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);
    }

    public static void RemoveAssociation(string extension, string keyName)
    {
      Registry.ClassesRoot.DeleteSubKeyTree(extension, false);
      Registry.ClassesRoot.DeleteSubKeyTree(keyName, false);
      Registry.CurrentUser.DeleteSubKeyTree("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\" + extension, false);
    }

    [DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);
  }
}
