using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace Jazz2Randomizer
{
    public static unsafe class Jazz2
    {
        public static Process Process { get; private set; }
        public static IntPtr Address => Process.MainModule.BaseAddress;

        public static void WaitForProcess()
        {
            Process = null;
            while (Process == null || Process.HasExited)
            {
                Process = Process.GetProcessesByName("jazz2").FirstOrDefault();
                Thread.Sleep(500);
            }
            Process.WaitForInputIdle();
        }

        public static bool IsRunning() => Process == null ? false : !Process.HasExited;

        public static void Write(IntPtr address, params byte[] data) => WinApi.WriteProcessMemory(Process.Handle, address, data, data.Length, out int bytesWritten);

        public static void Write(IntPtr address, int data) => Write(address, BitConverter.GetBytes(data));

        public static void Write(IntPtr address, IntPtr data, bool relative = true) => Write(address, BitConverter.GetBytes(relative ? (int)data - (int)address - 4 : (int)data));

        public static void Write(IntPtr address, short data) => Write(address, BitConverter.GetBytes(data));

        public static void Write(IntPtr address, string data, int count) => Write(address, Encoding.ASCII.GetBytes(data.PadRight(count, '\0')));

        public static void Read(IntPtr address, params byte[] data) => WinApi.ReadProcessMemory(Process.Handle, address, data, data.Length, out int bytesRead);

        public static void Read(IntPtr address, int[] data) => WinApi.ReadProcessMemory(Process.Handle, address, data, data.Length * 4, out int bytesRead);

        public static void Read(IntPtr address, out int data) => WinApi.ReadProcessMemory(Process.Handle, address, out data, 4, out int bytesRead);

        public static void Read(IntPtr address, out IntPtr data) => WinApi.ReadProcessMemory(Process.Handle, address, out data, 4, out int bytesRead);

        public static void Read(IntPtr address, out short data) => WinApi.ReadProcessMemory(Process.Handle, address, out data, 4, out int bytesRead);

        public static void Read(IntPtr address, out string data, int count)
        {
            var bytes = new byte[count];
            Read(address, bytes);
            bytes = bytes.TakeWhile(x => x > 0).ToArray();
            data = Encoding.ASCII.GetString(bytes);
        }

        public static IntPtr Allocate(int size) => WinApi.VirtualAllocEx(Process.Handle, IntPtr.Zero, size, 0x1000, 0x40);

        public static IntPtr Allocate(params byte[] data)
        {
            var pointer = Allocate(data.Length);
            Write(pointer, data);
            return pointer;
        }
    }
}
