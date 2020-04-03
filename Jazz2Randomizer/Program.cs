using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;

namespace Jazz2Randomizer
{
    class Program
    {
        static LevelInfo[][] episodes;
        static string startLevel;
        static Random rng;

        static Dictionary<int, string> eventNames = new Dictionary<int, string>()
        {
            // Modifier
            { 1, "One Way" },
            { 2, "Hurt" },
            { 3, "Vine" },
            { 5, "Slide" },
            { 8, "Area Fly Off" },
            { 9, "Ricochet" },
            { 10, "Belt Right" },
            { 11, "Belt Left" },
            { 12, "Acc Belt R" },
            { 13, "Acc Belt L" },
            { 14, "Stop Enemy" },
            { 15, "Wind Left" },
            { 16, "Wind Right" },
            { 24, "Limit X Scroll" },

            // Object
            { 4, "Hook" },
            { 6, "H-Pole" },
            { 7, "V-Pole" },
            { 41, "Still Turtleshell" },
            { 42, "Swinging Vine" },
            { 43, "Bomb" },
            { 59, "Airboard" },
            { 68, "Birdy" },
            { 111, "Cheshire1" },
            { 112, "Cheshire2" },
            { 119, "Leaf" },
            { 130, "Rotating Rock" },
            { 153, "Bridge" },
            { 193, "Small Tree" },
            { 203, "Carrotus pole" },
            { 204, "Psych pole" },
            { 205, "Diamondus pole" },
            { 206, "Sucker Tube" },
            { 215, "Spike Boll" },
            { 217, "Eva" },
            { 223, "3D Spike Boll" },
            { 226, "Copter" },
            { 228, "Stopwatch" },
            { 229, "Jungle Pole" },
            { 231, "Big Rock" },
            { 232, "Big Box" },
            { 244, "CTF Base + Flag" },

            // Area
            { 17, "Area End Of Level" },
            { 18, "Area Warp EOL" },
            { 19, "Area Revert Morph" },
            { 20, "Area Float Up" },
            { 26, "Area Warp Secret" },
            { 230, "Warp" },
            { 240, "Warp Target" },
            { 242, "Area Id" },
            { 245, "No Fire Zone" },
            { 246, "Trigger Zone" },

            // Trigger
            { 21, "Trigger Rock" },
            { 95, "Scenery Trigger Crate" },
            { 185, "Destruct Scenery" },
            { 186, "Destruct Scenery BOMB" },
            { 187, "Collapsing Scenery" },
            { 188, "ButtStomp Scenery" },
            { 207, "Text" },
            { 234, "Trigger Scenery" },

            // Light
            { 22, "Dim Light" },
            { 23, "Set Light" },
            { 25, "Reset Light" },
            { 148, "Steady Light" },
            { 149, "Pulze Light" },
            { 150, "Flicker Light" },

            // Sound
            { 27, "Echo" },
            { 194, "Ambient Sound" },

            // Boss
            { 28, "Activate Boss" },
            { 101, "Tuf Boss" },
            { 114, "Bilsy Boss" },
            { 151, "Queen Boss" },
            { 195, "Uterus" },
            { 199, "Bubba" },
            { 200, "Devil devan boss" },
            { 201, "Devan (robot boss)" },
            { 202, "Robot (robot boss)" },
            { 235, "Bolly Boss" },
            { 241, "Tweedle Boss" },
            { 247, "Xmas Bilsy Boss" },

            // StartPos
            { 29, "Jazz Level Start" },
            { 30, "Spaz Level Start" },
            { 31, "Multiplayer Level Start" },

            //
            { 32, "EMPTY" },
            { 82, "EMPTY" },
            { 216, "Generator" },
            { 239, "EMPTY" },
            { 243, "EMPTY" },
            { 253, "EMPTY" },
            { 254, "EMPTY" },
            { 255, "EMPTY" },

            // Ammo
            { 33, "Freezer Ammo+3" },
            { 34, "Bouncer Ammo+3" },
            { 35, "Seeker Ammo+3" },
            { 36, "3Way Ammo+3" },
            { 37, "Toaster Ammo+3" },
            { 38, "TNT Ammo+3" },
            { 39, "Gun8 Ammo+3" },
            { 40, "Gun9 Ammo+3" },
            { 46, "Gun crate" },
            { 53, "Freezer Ammo+15" },
            { 54, "Bouncer Ammo+15" },
            { 55, "Seeker Ammo+15" },
            { 56, "3Way Ammo+15" },
            { 57, "Toaster Ammo+15" },
            { 69, "Gun Barrel" },

            // Goodies
            { 44, "Silver Coin" },
            { 45, "Gold Coin" },
            { 47, "Carrot crate" },
            { 48, "1Up crate" },
            { 50, "Carrot barrel" },
            { 51, "1up barrel" },
            { 52, "Bomb Crate" },
            { 72, "Carrot Energy +1" },
            { 73, "Full Energy" },
            { 79, "Fast Feet" },
            { 80, "Extra Live" },
            { 88, "Invincibility" },
            { 89, "Extra Time" },
            { 90, "Freeze Enemies" },
            { 96, "Fly carrot" },

            // Gem
            { 49, "Gem barrel" },
            { 63, "Red Gem +1" },
            { 64, "Green Gem +1" },
            { 65, "Blue Gem +1" },
            { 66, "Purple Gem +1" },
            { 67, "Super Red Gem" },
            { 70, "Gem Crate" },
            { 97, "RectGem Red" },
            { 98, "RectGem Green" },
            { 99, "RectGem Blue" },
            { 189, "Invisible GemStomp" },
            { 192, "Gem Ring" },

            // Spring
            { 60, "Frozen Green Spring" },
            { 62, "Spring Crate" },
            { 85, "Red Spring" },
            { 86, "Green Spring" },
            { 87, "Blue Spring" },
            { 91, "Hor Red Spring" },
            { 92, "Hor Green Spring" },
            { 93, "Hor Blue Spring" },
            { 224, "Springcord" },

            // PowerUp
            { 61, "Gun Fast Fire" },
            { 77, "Max weapon" },
            { 78, "Auto fire" },
            { 131, "Blaster PowerUp" },
            { 132, "Bouncy PowerUp" },
            { 133, "Ice gun PowerUp" },
            { 134, "Seek PowerUp" },
            { 135, "RF PowerUp" },
            { 136, "Toaster PowerUP" },
            { 219, "TNT Powerup" },
            { 220, "Gun8 Powerup" },
            { 221, "Gun9 Powerup" },

            // Morph
            { 71, "Jazz<->Spaz" },
            { 94, "Morph Into Bird" },
            { 222, "Morph Frog" },

            // Shield
            { 74, "Fire Shield" },
            { 75, "Water Shield" },
            { 76, "Lightning Shield" },
            { 227, "Laser Shield" },

            // SignPost
            { 81, "End of Level signpost" },
            { 83, "Save point signpost" },
            { 84, "Bonus Level signpost" },

            // Enemy
            { 100, "Tuf Turt" },
            { 102, "Lab Rat" },
            { 103, "Dragon" },
            { 104, "Lizard" },
            { 105, "Bee" },
            { 106, "Rapier" },
            { 107, "Sparks" },
            { 108, "Bat" },
            { 109, "Sucker" },
            { 110, "Caterpillar" },
            { 113, "Hatter" },
            { 115, "Skeleton" },
            { 116, "Doggy Dogg" },
            { 117, "Norm Turtle" },
            { 118, "Helmut" },
            { 120, "Demon" },
            { 123, "Dragon Fly" },
            { 124, "Monkey" },
            { 125, "Fat Chick" },
            { 126, "Fencer" },
            { 127, "Fish" },
            { 152, "Floating Sucker" },
            { 183, "Float Lizard" },
            { 184, "Stand Monkey" },
            { 190, "Raven" },
            { 191, "Tube Turtle" },
            { 196, "Crab" },
            { 197, "Witch" },
            { 198, "Rocket Turtle" },
            { 225, "Bees" },
            { 236, "Butterfly" },
            { 237, "BeeBoy" },
            { 248, "Xmas Norm Turtle" },
            { 249, "Xmas Lizard" },
            { 250, "Xmas Float Lizard" },
            { 251, "Addon DOG" },
            { 252, "Addon Sparks" },

            // Scenery
            { 121, "Fire" },
            { 122, "Lava" },
            { 128, "Moth" },
            { 129, "Steam" },
            { 208, "Water Level" },
            { 218, "Bubbler" },
            { 233, "Water Block" },
            { 238, "Snow" },

            // Pinball
            { 137, "PIN: Left Paddle" },
            { 138, "PIN: Right Paddle" },
            { 139, "PIN: 500 Bump" },
            { 140, "PIN: Carrot Bump" },

            // Food
            { 141, "Apple" },
            { 142, "Banana" },
            { 143, "Cherry" },
            { 144, "Orange" },
            { 145, "Pear" },
            { 146, "Pretzel" },
            { 147, "Strawberry" },
            { 154, "Lemon" },
            { 155, "Lime" },
            { 156, "Thing" },
            { 157, "Watermelon" },
            { 158, "Peach" },
            { 159, "Grapes" },
            { 160, "Lettuce" },
            { 161, "Eggplant" },
            { 162, "Cucumb" },
            { 163, "Soft Drink" },
            { 164, "Soda Pop" },
            { 165, "Milk" },
            { 166, "Pie" },
            { 167, "Cake" },
            { 168, "Donut" },
            { 169, "Cupcake" },
            { 170, "Chips" },
            { 171, "Candy" },
            { 172, "Chocbar" },
            { 173, "Icecream" },
            { 174, "Burger" },
            { 175, "Pizza" },
            { 176, "Fries" },
            { 177, "Chicken Leg" },
            { 178, "Sandwich" },
            { 179, "Taco" },
            { 180, "Weenie" },
            { 181, "Ham" },
            { 182, "Cheese" },

            // Platform
            { 209, "Fruit Platform" },
            { 210, "Boll Platform" },
            { 211, "Grass Platform" },
            { 212, "Pink Platform" },
            { 213, "Sonic Platform" },
            { 214, "Spike Platform" },
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
            episodes = LevelInfo.GetLevelInfos(rng);

            Console.WriteLine("Looking for Jazz2 process...");
            Jazz2.WaitForProcess();
            Console.WriteLine("Jazz2 process found");

            var loadPointer = Jazz2.Allocate(0x00, 0x00, 0x00, 0x00);
            var functionPointer = Jazz2.Allocate(
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
            Jazz2.Write(functionPointer + 3, (int)loadPointer);
            Jazz2.Write(functionPointer + 25, (int)Jazz2.Address + 0x8F0C0 - (int)(functionPointer + 25) - 4);
            Jazz2.Write(Jazz2.Address + 0x3FD49, (int)functionPointer - (int)(Jazz2.Address + 0x3FD49) - 4);
            Console.WriteLine("Code injected successfully");

            while (Jazz2.IsRunning())
            {
                Jazz2.Read(Jazz2.Address + 0x1F3884, out string newLevel, 32);
                if (newLevel.ToUpper() == newLevel && startLevel != newLevel)
                {
                    startLevel = newLevel;
                    if (LevelInfo.GetLevelIndex(newLevel, out int episodeIndex, out int levelindex))
                    {
                        var levels = episodes[episodeIndex];
                        startLevel = levels[levelindex].Level.ToUpper();
                    }
                    Jazz2.Write(Jazz2.Address + 0x1F3884, startLevel, 32);
                }

                Jazz2.Read(loadPointer, out int loadValue);
                if (loadValue == 1)
                {
                    OnLoadLevel();
                    Jazz2.Write(loadPointer, 0);
                }
                Thread.Sleep(5);
            }
        }

        static void OnLoadLevel()
        {
            Jazz2.Read(Jazz2.Address + 0x1F3884, out string levelName, 32);
            levelName = levelName.ToLower();

            var level = episodes
                .SelectMany(x => x)
                .FirstOrDefault(x => x.Level == levelName);

            if (level != null)
            {
                Jazz2.Read(Jazz2.Address + 0x1191D4, out IntPtr eventsPointer);
                Jazz2.Read(eventsPointer, out eventsPointer);
                Jazz2.Read(Jazz2.Address + 0x10F14C, out int width);
                Jazz2.Read(Jazz2.Address + 0x1191AC, out int height);

                var events = new int[width * height];
                Jazz2.Read(eventsPointer, events);

                for (int i = 0; i < events.Length; i++)
                {
                    if (level.EventLookup.TryGetValue(events[i] & 0xFF, out int newEvent))
                        Jazz2.Write(eventsPointer + (i * 4), newEvent);
                }

                Jazz2.Write(Jazz2.Address + 0x1C89E0, level.Character);
                Jazz2.Write(Jazz2.Address + 0x14D613, level.Song, 32);
                Jazz2.Write(Jazz2.Address + 0x14D5D3, level.NextLevel, 32);
#if DEBUG
                var usedEvents = events
                    .Select(x => x & 0xFF)
                    .Distinct();

                Console.WriteLine("");
                Console.WriteLine("--== {0} ==--", level.Level);
                Console.WriteLine("Next level: " + level.NextLevel);
                Console.WriteLine("Song: " + level.Song);
                Console.WriteLine("Character: " + level.Character);
                Console.WriteLine("Events:");

                foreach (var eventId in usedEvents)
                {
                    if (level.EventLookup.TryGetValue(eventId, out int newEventId))
                    {
                        var eventFrom = string.Format("{0} ({1})", eventNames[eventId], eventId);
                        var evenTo = string.Format("{0} ({1})", eventNames[newEventId], newEventId);
                        Console.WriteLine("  {0} => {1}", eventFrom.PadRight(24), evenTo);
                    }
                }
#endif
            }
        }
    }
}
