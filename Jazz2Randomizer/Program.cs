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

        static int[] ammoEvents = new int[] { 33, 34, 35, 36, 37, 38, 39, 40 };
        static int[] enemyEvents = new int[] { 100, 102, 103, 104, 105, 106, 107, 108, 109, 110, 113, 115, 116, 117, 118, 120, 123, 124, 125, 126, 127, 152, 183, 184, 190, 191, 196, 197, 198, 225, 236, 237, 248, 249, 250, 251, 252 };
        static int[] bossEvents = new int[] { 101, 114, 151, 195, 199, 200, 201, 202, 235, 241, 247 };
        static short[] characters = new short[] { 55, 89, 61 };
        static string[] songs;
        static string[] levels;
        static int nextLevelIndex;
        static string[][] episodes = new string[][]
            {
                new string[] {
                    "easter1.j2l",
                    "easter2.j2l",
                    "easter3.j2l",
                    "haunted1.j2l",
                    "haunted2.j2l",
                    "haunted3.j2l",
                    "town1.j2l",
                    "town2.j2l",
                    "town3.j2l",
                },
                new string[] {
                    "castle1.j2l",
                    "castle1n.j2l",
                    "carrot1.j2l",
                    "carrot1n.j2l",
                    "labrat1.j2l",
                    "labrat2.j2l",
                    "colon1.j2l",
                    "colon2.j2l",
                    "psych1.j2l",
                    "psych2.j2l",
                    "beach.j2l",
                    "beach2.j2l",
                    "diam1.j2l",
                    "diam3.j2l",
                    "tube1.j2l",
                    "tube2.j2l",
                    "medivo1.j2l",
                    "medivo2.j2l",
                    "jung1.j2l",
                    "jung2.j2l",
                    "hell.j2l",
                    "hell2.j2l",
                    "damn.j2l",
                    "damn2.j2l",
                },
                new string[] {
                    "share1.j2l",
                    "share2.j2l",
                    "share3.j2l",
                },
                new string[] {
                    "xmas1.j2l",
                    "xmas2.j2l",
                    "xmas3.j2l",
                },
            };

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

            while (process == null || process.HasExited)
            {
                Console.WriteLine("Looking for Jazz2 process...");
                process = Process.GetProcessesByName("jazz2").FirstOrDefault();
                Thread.Sleep(1000);
            }
            Console.WriteLine("Jazz2 process found");
            process.WaitForInputIdle();

            nextLevelIndex = 0;
            basePointer = process.MainModule.BaseAddress;
            songs = Directory.GetFiles(Path.GetDirectoryName(process.MainModule.FileName), "*.j2b")
                .Select(x => Path.GetFileNameWithoutExtension(x))
                .ToArray();

            for (int i = 0; i < episodes.Length; i++)
                episodes[i] = episodes[i].OrderBy(x => rng.Next()).ToArray();

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
                if (nextLevelIndex == 0)
                {
                    Read(basePointer + 0x1F3884, out string level, 32);
                    level = level.ToLower();
                    levels = episodes.FirstOrDefault(x => x.Contains(level));

                    if (levels != null && levels.Length > 0 && level != levels[0])
                        Write(basePointer + 0x1F3884, levels[0].ToUpper(), 32);
                }

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

            var lookup = new Dictionary<int, int>();
            var events = new int[width * height];
            Read(eventsPointer, events);

            foreach (var ammoEvent in ammoEvents)
                lookup[ammoEvent] = ammoEvents[rng.Next(ammoEvents.Length)];

            foreach (var enemyEvent in enemyEvents)
                lookup[enemyEvent] = enemyEvents[rng.Next(enemyEvents.Length)];

            foreach (var bossEvent in bossEvents)
                lookup[bossEvent] = bossEvents[rng.Next(bossEvents.Length)];

            for (int i = 0; i < events.Length; i++)
            {
                if (lookup.TryGetValue(events[i] & 0xFF, out int newEvent))
                    Write(eventsPointer + (i * 4), newEvent);
            }

            Write(basePointer + 0x1C89E0, characters[rng.Next(characters.Length)]);
            Write(basePointer + 0x14D613, songs[rng.Next(songs.Length)], 32);

            nextLevelIndex++;
            if (levels != null)
                Write(basePointer + 0x14D5D3, nextLevelIndex < levels.Length ? levels[nextLevelIndex] : "ending", 32);
        }

        static void Read(IntPtr address, int[] data) => WinApi.ReadProcessMemory(process.Handle, address, data, data.Length * 4, out int bytesRead);

        static void Read(IntPtr address, out IntPtr data) => WinApi.ReadProcessMemory(process.Handle, address, out data, 4, out int bytesRead);

        static void Read(IntPtr address, out int data) => WinApi.ReadProcessMemory(process.Handle, address, out data, 4, out int bytesRead);

        static void Read(IntPtr address, byte[] data) => WinApi.ReadProcessMemory(process.Handle, address, data, data.Length, out int bytesRead);

        static void Read(IntPtr address, out string data, int count)
        {
            var bytes = new byte[count];
            Read(address, bytes);
            data = Encoding.ASCII.GetString(bytes).TrimEnd('\0');
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
