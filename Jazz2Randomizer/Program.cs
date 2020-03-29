using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Jazz2Randomizer
{
    class Program
    {
        static Process process;
        static IntPtr basePointer;
        static Random rng;

        static LevelInfo[][] episodes;
        static LevelInfo[] levels;
        static string startLevel;

        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Enter seed or press enter for a random seed...");
            while (rng == null)
            {
                var seed = 0;
                var input = Console.ReadLine();

                if (input == "")
                {
                    seed = new Random().Next();
                    rng = new Random(seed);
                    Console.WriteLine("Your random seed: {0:X8}", seed);
                }
                else if (int.TryParse(input, NumberStyles.HexNumber, null, out seed))
                {
                    rng = new Random(seed);
                }
                else
                {
                    Console.WriteLine("'{0}' couldn't be interpreted as a number.", input);
                }
            }

            Console.WriteLine("Looking for Jazz2 process...");
            while (process == null || process.HasExited)
            {
                process = Process.GetProcessesByName("jazz2").FirstOrDefault();
                Thread.Sleep(500);
            }
            Console.WriteLine("Jazz2 process found");
            process.WaitForInputIdle();

            basePointer = process.MainModule.BaseAddress;
            episodes = LevelInfo.GetLevelInfos(rng, Path.GetDirectoryName(process.MainModule.FileName));

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
                Read(basePointer + 0x1F3884, out string newLevel, 32);
                if (newLevel.ToUpper() == newLevel && startLevel != newLevel)
                {
                    startLevel = newLevel;
                    if (LevelInfo.GetLevelIndex(newLevel, out int episodeIndex, out int levelindex))
                    {
                        levels = episodes[episodeIndex];
                        startLevel = levels[levelindex].Level.ToUpper();
                    }
                    Write(basePointer + 0x1F3884, startLevel, 32);
                }

                Read(loadPointer, out int loadValue);
                if (loadValue == 1)
                {
                    OnLoadLevel();
                    Write(loadPointer, 0);
                }
                Thread.Sleep(5);
            }
        }

        static void OnLoadLevel()
        {
            Read(basePointer + 0x1F3884, out string levelName, 32);
            levelName = levelName.ToLower();

            var level = episodes
                .SelectMany(x => x)
                .FirstOrDefault(x => x.Level == levelName);

            if (level != null)
            {
                Read(basePointer + 0x1191D4, out IntPtr eventsPointer);
                Read(eventsPointer, out eventsPointer);
                Read(basePointer + 0x10F14C, out int width);
                Read(basePointer + 0x1191AC, out int height);

                var events = new int[width * height];
                Read(eventsPointer, events);

                for (int i = 0; i < events.Length; i++)
                {
                    if (level.EventLookup.TryGetValue(events[i] & 0xFF, out int newEvent))
                        Write(eventsPointer + (i * 4), newEvent);
                }

                Write(basePointer + 0x1C89E0, level.Character);
                Write(basePointer + 0x14D613, level.Song, 32);
                Write(basePointer + 0x14D5D3, level.NextLevel, 32);
            }
        }

        static void Read(IntPtr address, int[] data) => WinApi.ReadProcessMemory(process.Handle, address, data, data.Length * 4, out int bytesRead);

        static void Read(IntPtr address, out IntPtr data) => WinApi.ReadProcessMemory(process.Handle, address, out data, 4, out int bytesRead);

        static void Read(IntPtr address, out int data) => WinApi.ReadProcessMemory(process.Handle, address, out data, 4, out int bytesRead);

        static void Read(IntPtr address, byte[] data) => WinApi.ReadProcessMemory(process.Handle, address, data, data.Length, out int bytesRead);

        static void Read(IntPtr address, out string data, int count)
        {
            var bytes = new byte[count];
            Read(address, bytes);
            bytes = bytes.TakeWhile(x => x > 0).ToArray();
            data = Encoding.ASCII.GetString(bytes);
        }

        static void Write(IntPtr address, params byte[] data) => WinApi.WriteProcessMemory(process.Handle, address, data, data.Length, out int bytesWritten);

        static void Write(IntPtr address, int data) => Write(address, BitConverter.GetBytes(data));

        static void Write(IntPtr address, short data) => Write(address, BitConverter.GetBytes(data));

        static void Write(IntPtr address, IntPtr data) => Write(address, (int)data);

        static void Write(IntPtr address, string data, int count) => Write(address, Encoding.ASCII.GetBytes(data.PadRight(count, '\0')));

        static IntPtr Allocate(params byte[] data)
        {
            var address = WinApi.VirtualAllocEx(process.Handle, IntPtr.Zero, data.Length, 0x1000, 0x40);
            Write(address, data);
            return address;
        }
    }
}
