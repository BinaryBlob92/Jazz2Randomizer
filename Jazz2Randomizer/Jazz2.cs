using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace Jazz2Randomizer
{
    public class Jazz2 : IDisposable
    {
        public event EventHandler ProcessFound;
        public event EventHandler ProcessClosed;

        private bool isDisposed;
        private bool exitLoop;
        private Thread loopThread;

        public Process Process { get; private set; }
        public bool IsRunning => Process != null && !Process.HasExited;
        public IntPtr Address => Process.MainModule.BaseAddress;

        public Jazz2()
        {
            loopThread = new Thread(LoopThreadProc);
            loopThread.Start();
        }

        private void LoopThreadProc()
        {
            while (!exitLoop)
            {
                if (Process == null || Process.HasExited)
                {
                    Process = Process.GetProcessesByName("jazz2").FirstOrDefault();
                    if (Process == null || Process.HasExited)
                        Thread.Sleep(500);
                    else if(Process.WaitForInputIdle(500))
                        OnProcessFound(EventArgs.Empty);
                }
                else if (Process.WaitForExit(500))
                {
                    OnProcessClosed(EventArgs.Empty);
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (isDisposed)
                return;

            if (disposing)
            {
                exitLoop = true;
                loopThread.Join();
            }

            isDisposed = true;
        }

        public void Write(IntPtr address, params byte[] data) => WinApi.WriteProcessMemory(Process.Handle, address, data, data.Length, out int bytesWritten);

        public void Write(IntPtr address, params int[] data) => WinApi.WriteProcessMemory(Process.Handle, address, data, data.Length * 4, out int bytesWritten);

        public void Write(IntPtr address, IntPtr data, bool relative = true) => Write(address, BitConverter.GetBytes(relative ? (int)data - (int)address - 4 : (int)data));

        public void Write(IntPtr address, short data) => Write(address, BitConverter.GetBytes(data));

        public void Write(IntPtr address, string data, int count) => Write(address, Encoding.ASCII.GetBytes(data.PadRight(count, '\0')));

        public void Read(IntPtr address, params byte[] data) => WinApi.ReadProcessMemory(Process.Handle, address, data, data.Length, out int bytesRead);

        public void Read(IntPtr address, int[] data) => WinApi.ReadProcessMemory(Process.Handle, address, data, data.Length * 4, out int bytesRead);

        public void Read(IntPtr address, out int data) => WinApi.ReadProcessMemory(Process.Handle, address, out data, 4, out int bytesRead);

        public void Read(IntPtr address, out IntPtr data) => WinApi.ReadProcessMemory(Process.Handle, address, out data, 4, out int bytesRead);

        public void Read(IntPtr address, out short data) => WinApi.ReadProcessMemory(Process.Handle, address, out data, 4, out int bytesRead);

        public void Read(IntPtr address, out string data, int count)
        {
            var bytes = new byte[count];
            Read(address, bytes);
            bytes = bytes.TakeWhile(x => x > 0).ToArray();
            data = Encoding.ASCII.GetString(bytes);
        }

        public IntPtr Allocate(int size) => WinApi.VirtualAllocEx(Process.Handle, IntPtr.Zero, size, 0x1000, 0x40);

        public IntPtr Allocate(params byte[] data)
        {
            var pointer = Allocate(data.Length);
            Write(pointer, data);
            return pointer;
        }

        protected virtual void OnProcessFound(EventArgs e) => ProcessFound?.Invoke(this, e);

        protected virtual void OnProcessClosed(EventArgs e) => ProcessClosed?.Invoke(this, e);
    }
}
