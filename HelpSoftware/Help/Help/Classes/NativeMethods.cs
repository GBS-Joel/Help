using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using System.Runtime.Serialization.Formatters;
using System.Security;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using Help;
using Help.Library;

namespace Help
{
  [SuppressUnmanagedCodeSecurity]
  public static class NativeMethods
  {
    public delegate IntPtr MessageHandler(WM uMsg, IntPtr wParam, IntPtr lParam, out bool handled);

    [DllImport("shell32.dll", EntryPoint = "CommandLineToArgvW", CharSet = CharSet.Unicode)]
    private static extern IntPtr _CommandLineToArgvW([MarshalAs(UnmanagedType.LPWStr)] string cmdLine, out int numArgs);

    [DllImport("kernel32.dll", EntryPoint = "LocalFree", SetLastError = true)]
    private static extern IntPtr _LocalFree(IntPtr hMem);

    public static string[ ] CommandLineToArgvW(string cmdLine)
    {
      IntPtr argv = IntPtr.Zero;
      try
      {
        int numArgs = 0;

        argv = _CommandLineToArgvW(cmdLine, out numArgs);
        if (argv == IntPtr.Zero)
        {
          throw new Win32Exception();
        }
        var result = new string[ numArgs ];

        for (int i = 0; i < numArgs; i++)
        {
          IntPtr currArg = Marshal.ReadIntPtr(argv, i * Marshal.SizeOf(typeof(IntPtr)));
          result[ i ] = Marshal.PtrToStringUni(currArg);
        }

        return result;
      }
      finally
      {
        IntPtr p = _LocalFree(argv);
      }
    }
  }
}
