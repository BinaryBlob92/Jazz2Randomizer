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

        static int curLevelPointer = 0x1F3884;
        static int nextLevelPointer = 0x14D5D3;
        static int worldPointer = 0x17B3E0;
        static int framePointer = 0x1ADC20;
        static int bamPointer = 0x1F38A4;
        static int finishedPointer = 0x1F3844;
        static int finishedCounterPointer = 0x1F3848;
        static int ogCharactrPointer = 0x1C89E0;
        static int curCharacterPointer = 0x1C89DC;

        // Random levels
        static Random rng = new Random();
        static string[] levels;
        static int levelIndex;

        // Lists to randomize
        static string[] bustAmove = new string[] {
            "BUST A MOVE",
            "BuSt A mOvE",
            "BUSTER WOLF",
            "BUS A MOUSE",
            "MOVE A BUST",
            "AAAAAAAAAAA",
            "GO GO GO!",
            "3, 2, 1, GO",
            "MOVE IT OUT",
            "STOP",
            "GO LEFT",
            "WRONG WAY",
            "BUST A BUST",
            "EVOM A TSUB"
        };
        static string[] ep1to4Levels = new string[] {
            "trainer", "castle1", "castle1n", "carrot1", "carrot1n", "labrat1", "labrat2",
            "colon1", "colon2", "psych1", "psych2", "beach", "beach2",
            "diam1", "diam3", "tube1", "tube2", "medivo1", "medivo2",
            "jung1", "jung2", "hell", "hell2", "damn", "damn2"
        };
        static string[] tsfLevels = new string[] {
            "easter1", "easter2", "easter3",
            "haunted1", "haunted2","haunted3",
            "town1", "town2", "town3"
        };
        static string[] demoLevels = new string[] {
            "share1", "share2", "share3"
        };
        static string[] ccLevels = new string[] {
            "xmas1", "xmas2", "xmas3"
        };
        static short[] chars = new short[] {
            55,
            89,
            61
        };

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



            ushort previousFrame = 0;
            ushort previousFinishedCounter = 0;
            int previousCharacter = 0;
            // Best var names
            string previousCurrentLevel = "";
            string previousNextLevel = "";

            while (!process.HasExited)
            {
                //--------------//
                //  Load Check  //
                //--------------//
                Read(loadPointer, out int loadValue);
                if (loadValue == 1)
                {
                    Console.WriteLine("Calling OnLoadLevel");
                    OnLoadLevel();
                    Console.WriteLine("OnLoadLevel finished");
                    Write(loadPointer, 0);
                    Console.WriteLine("Continue game");
                }

                //---------------------//
                //  Set up next level  //
                //---------------------//
                byte[] world = new byte[12];
                Read(basePointer + worldPointer, world);
                string worldStr = stripJunk(Encoding.ASCII.GetString(world));

                // Check current level
                byte[] lev = new byte[16];
                Read(basePointer + curLevelPointer, lev);
                string levStr = stripJunk(Encoding.ASCII.GetString(lev));
                if (previousCurrentLevel != levStr && (previousCurrentLevel + ".j2l") != levStr)
                {
                    // Current level has changed, either we went to a
                    // new level or we chose an episode from the menu
                    // Check if we're currently on the menu
                    if (worldStr == "MENU")
                    {
                        // We're on the menu, initialize randomness
                        randomizeLevels();
                        Write(basePointer + curLevelPointer, levels[levelIndex], 16);
                        // Clear the next level, so we always know it'll change upon starting the first level
                        // okay so setting empty string here somehow makes it get 'x' for the nextLevStr value later so...I dunno
                        Write(basePointer + nextLevelPointer, "start", 16);
                        // Also clear the character, so that we can use a change in that to fire off randomizing the char
                        // I can't find a better way to do this right now so PLEASE FIND A BETTER WAY THIS SUCKS
                        Write(basePointer + ogCharactrPointer, 0);
                        previousCharacter = 0;

                        // If we don't set this then we'll end up randomizing again because we changed the value
                        levStr = levels[levelIndex];

                        Debug.WriteLine("Setting next level: " + levels[levelIndex] + " index=" + levelIndex);
                        levelIndex++;
                    }
                }

                // Check next level
                byte[] nextLev = new byte[16];
                Read(basePointer + nextLevelPointer, nextLev);
                string nextLevStr = stripJunk(Encoding.ASCII.GetString(nextLev));
                if(nextLevStr != "start" && previousNextLevel != nextLevStr)
                {
                    // The next level has changed, We've loaded a different level. Set the next level
                    nextLevStr = nextLevel();
                }

                //-------------------//
                //  Set BUST A MOVE  //
                //-------------------//
                ushort frame;
                Read(basePointer + framePointer, out frame);
                // Trying during earlier frames didn't seem to work so...I dunno
                if (frame == 4 && frame > previousFrame)
                {
                    int index = rng.Next(bustAmove.Length);
                    Write(basePointer + bamPointer, bustAmove[index], 11);
                }

                //-----------------//
                //  Set character  //
                //-----------------//

                // This handles the menu
                int currentCharacter;
                Read(basePointer + ogCharactrPointer, out currentCharacter);
                if(currentCharacter != 0 && currentCharacter != previousCharacter && worldStr == "MENU")
                {
                    // Character changed on the menu, override it with a random character
                    currentCharacter = nextCharacter();
                }

                // This handles the change every level
                ushort finished, finishedCounter;
                Read(basePointer + finishedPointer, out finished);
                Read(basePointer + finishedCounterPointer, out finishedCounter);
                if ((finished == 1 && finishedCounter >= 32828 && previousFinishedCounter < 32828) ||
                    (finished == 2 && finishedCounter >= 32780 && previousFinishedCounter < 32780))
                {
                    nextCharacter();
                }

                //---------------------//
                //  Set previous vals  //
                //---------------------//
                previousCurrentLevel = levStr;
                previousNextLevel = nextLevStr;
                previousFrame = frame;
                previousCharacter = currentCharacter;
                previousFinishedCounter = finishedCounter;


                //----------//
                //  ZZZ...  //
                //----------//
                Thread.Sleep(10);
            }
            Console.WriteLine("Game exited");
        }

        static void randomizeLevels()
        {
            Console.WriteLine("Randomizing level order...");
            // Randomize the levels
            List<string> levelList = new List<string>();
            levelList.AddRange(ep1to4Levels);
            //levelList.AddRange(tsfLevels);
            //levelList.AddRange(demoLevels);
            //levelList.AddRange(ccLevels);
            string[] levelNames = levelList.ToArray();

            // I'm not this smart, I stole this from https://stackoverflow.com/a/108836
            levels = levelNames.OrderBy(x => rng.Next()).ToArray();
            Debug.WriteLine("Randomized levels:");
            for (int i = 0; i < levels.Length; i++)
            {
                Debug.WriteLine(levels[i]);
            }
            // Reset the level index
            levelIndex = 0;
        }

        static string nextLevel()
        {
            string next = "ending";
            if (levelIndex < levels.Length)
            {
                // Still levels to play, set the next one
                next = levels[levelIndex];
                levelIndex++;
            }
            // We're already in game, just set the next level
            Write(basePointer + nextLevelPointer, next, 16);
            Debug.WriteLine("Setting next level: " + next + " index=" + (levelIndex-1));
            return next;
        }

        static short nextCharacter()
        {
            int index = rng.Next(chars.Length);
            Debug.WriteLine("Setting character: " + chars[index]);
            Write(basePointer + ogCharactrPointer, chars[index]);
            Write(basePointer + curCharacterPointer, chars[index]);

            return chars[index];
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

        static string stripJunk(string str)
        {
            // Strip out any junk characters
            // taken from https://stackoverflow.com/a/15150427
            return new string(str.Where(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c) || c == '-' || c == '.').ToArray());
        }

        //--------//
        //  Read  //
        //--------//
        static void Read(IntPtr address, int[] data) => WinApi.ReadProcessMemory(process.Handle, address, data, data.Length * 4, out int bytesRead);

        static void Read(IntPtr address, out IntPtr data) => WinApi.ReadProcessMemory(process.Handle, address, out data, 4, out int bytesRead);

        static void Read(IntPtr address, out int data) => WinApi.ReadProcessMemory(process.Handle, address, out data, 4, out int bytesRead);

        static void Read(IntPtr address, byte[] data) => WinApi.ReadProcessMemory(process.Handle, address, data, data.Length, out int bytesRead);

        static void Read(IntPtr address, out ushort data) => WinApi.ReadProcessMemory(process.Handle, address, out data, 2, out int bytesRead);

        //---------//
        //  Write  //
        //---------//
        static void Write(IntPtr address, params byte[] data) => WinApi.WriteProcessMemory(process.Handle, address, data, data.Length, out int bytesWritten);

        static void Write(IntPtr address, int data) => Write(address, BitConverter.GetBytes(data));

        static void Write(IntPtr address, IntPtr data) => Write(address, (int)data);

        static void Write(IntPtr address, string data, int len) => WinApi.WriteProcessMemory(process.Handle, address, Encoding.ASCII.GetBytes(data), len, out int bytesWritten);

        //---------//
        //  Alloc  //
        //---------//
        static IntPtr Allocate(params byte[] data)
        {
            var address = WinApi.VirtualAllocEx(process.Handle, IntPtr.Zero, data.Length, 0x1000, 0x40);
            Write(address, data);
            return address;
        }
    }
}
