using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace Jazz2Randomizer
{
    class Program
    {
        static Process process;
        static IntPtr basePointer;

        [STAThread]
        static void Main(string[] args)
        {
            while (process == null || process.HasExited)
            {
                Console.WriteLine("Looking for Jazz2 process...");
                process = Process.GetProcessesByName("jazz2").FirstOrDefault();
                Thread.Sleep(1000);
            }
            Console.WriteLine("Jazz2 process found");
            process.WaitForInputIdle();
            basePointer = process.MainModule.BaseAddress;

            var loadPointer = Allocate(0x00, 0x00, 0x00, 0x00);
            var functionPointer = Allocate(
                0x50,                                       // push eax
                0x55,                                       // push ebp
                0xBD, 0x00, 0x00, 0x00, 0x00,               // mov ebp,00000000
                0xC7, 0x45, 0x00, 0x01, 0x00, 0x00, 0x00,   // mov [ebp],00000001
                0x8B, 0x45, 0x00,                           // mov eax,[ebp]
                0x83, 0xF8, 0x01,                           // cmp eax,01
                0x74, 0xF8,                                 // je ...
                0x58,                                       // pop eax
                0x5D,                                       // pop epb
                0xE8, 0x00, 0x00, 0x00, 0x00,               // call 00000000
                0xC3                                        // ret
            );
            Write(functionPointer + 3, loadPointer);
            Write(functionPointer + 25, basePointer + 0x8F0C0 - (int)(functionPointer + 25) - 4);
            Write(basePointer + 0x3FD49, functionPointer - (int)(basePointer + 0x3FD49) - 4);
            Console.WriteLine("Code injected successfully");

            while (!process.HasExited)
            {
                Read(loadPointer, out int loadValue);
                if (loadValue == 1)
                {
                    Console.WriteLine("Calling OnLoadLevel");
                    OnLoadLevel();
                    Console.WriteLine("OnLoadLevel finished");
                    Write(loadPointer, 0);
                    Console.WriteLine("Continue game");
                }
                Thread.Sleep(10);
            }
            Console.WriteLine("Game exited");
        }

        static void OnLoadLevel()
        {
            Read(basePointer + 0x1191D4, out IntPtr eventsPointer);
            Read(eventsPointer, out eventsPointer);
            Read(basePointer + 0x10F14C, out int width);
            Read(basePointer + 0x1191AC, out int height);

            var events = new int[width * height];
            Read(eventsPointer, events);

            var rng = new Random();
            var lookup = new Dictionary<int, int>();

            var ammoEvents = new[] { 33, 34, 35, 36, 37, 38, 39, 40 };
            foreach (var ammoEvent in ammoEvents)
                lookup[ammoEvent] = ammoEvents[rng.Next(ammoEvents.Length)];

            var enemyEvents = new[] { 100, 102, 103, 104, 105, 106, 107, 108, 109, 110, 113, 115, 116, 117, 118, 120, 123, 124, 125, 126, 127, 152, 183, 184, 190, 191, 196, 197, 198, 225, 236, 237, 248, 249, 250, 251, 252 };
            foreach (var enemyEvent in enemyEvents)
                lookup[enemyEvent] = enemyEvents[rng.Next(enemyEvents.Length)];

            var bossEvents = new[] { 101, 114, 151, 195, 199, 200, 201, 202, 235, 241, 247 };
            foreach (var bossEvent in bossEvents)
                lookup[bossEvent] = bossEvents[rng.Next(bossEvents.Length)];

            for (int i = 0; i < events.Length; i++)
            {
                if (lookup.TryGetValue(events[i] & 0xFF, out int newEvent))
                    Write(eventsPointer + (i * 4), newEvent);
            }
        }

        static void Read(IntPtr address, int[] data) => WinApi.ReadProcessMemory(process.Handle, address, data, data.Length * 4, out int bytesRead);

        static void Read(IntPtr address, out IntPtr data) => WinApi.ReadProcessMemory(process.Handle, address, out data, 4, out int bytesRead);

        static void Read(IntPtr address, out int data) => WinApi.ReadProcessMemory(process.Handle, address, out data, 4, out int bytesRead);

        static void Write(IntPtr address, params byte[] data) => WinApi.WriteProcessMemory(process.Handle, address, data, data.Length, out int bytesWritten);

        static void Write(IntPtr address, int data) => Write(address, BitConverter.GetBytes(data));

        static void Write(IntPtr address, IntPtr data) => Write(address, (int)data);

        static IntPtr Allocate(params byte[] data)
        {
            var address = WinApi.VirtualAllocEx(process.Handle, IntPtr.Zero, data.Length, 0x1000, 0x40);
            Write(address, data);
            return address;
        }
    }
}
