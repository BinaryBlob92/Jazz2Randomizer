using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Jazz2Randomizer
{
    public class LevelInfo
    {
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
        static int[][] eventGroups = new int[][]
        {
            // Ammo
            new int[] { 33, 34, 35, 36, 37, 38, 39, 40 },
            // Énemies
            new int[] { 100, 102, 103, 104, 105, 106, 107, 108, 109, 110, 113, 115, 116, 117, 118, 120, 123, 124, 125, 126, 127, 152, 183, 184, 190, 191, 196, 197, 237, 248, 249, 250, 252 },
            // Bosses
            new int[] { 101, 114, 151, 195, 199, 200, 202, 235 },
            // Foods
            new int[] { 141, 142, 143, 144, 145, 146, 147, 154, 155, 156, 157, 158, 159, 160, 161, 162, 163, 164, 165, 166, 167, 168, 169, 170, 171, 172, 173, 174, 175, 176, 177, 178, 179, 180, 181, 182 },
            // Crates
            new int[]
            {
                131, 132, 133, 134, 135, 136, 219, 220, 221, // Power ups
                74, 75, 76, // Shields
                71, 94, // Morphs
                46, 53, 54, 55, 56, 57, 69, // Ammo
                47, 48, 50, 51, 52, // Goodies
                49, 70, // Gem
            },
        };

        static string[] songs = new string[]
        {
            "Beach.j2b",
            "Bonus2.j2b",
            "Bonus3.j2b",
            "Boss1.j2b",
            "Boss2.j2b",
            "Carrotus.j2b",
            "Castle.j2b",
            "Colony.j2b",
            "Dang.j2b",
            "Diamond.j2b",
            "Ending.j2b",
            "Fastrack.j2b",
            "Freeze.j2b",
            "Funkyg.j2b",
            "Hell.j2b",
            "Intro.j2b",
            "Jungle.j2b",
            "Labrat.j2b",
            "Medivo2.j2b",
            "Menu.j2b",
            "Order.j2b",
            "Tubelec.j2b",
            "Water.j2b",
            "Whare.j2b",
        };
        static short[] characters = new short[] { 55, 89, 61 };

        public string Level { get; set; }
        public string NextLevel { get; set; }
        public string Song { get; set; }
        public short Character { get; set; }
        public Dictionary<int, int> EventLookup { get; set; }

        public static LevelInfo[][] GetLevelInfos(Random rng)
        {
            var output = new LevelInfo[episodes.Length][];
            for (int i = 0; i < output.Length; i++)
            {
                var levelNames = episodes[i].OrderBy(x => rng.Next()).ToArray();
                var songNames = songs.OrderBy(x => rng.Next()).ToArray();
                output[i] = new LevelInfo[levelNames.Length];
                for (int n = 0; n< levelNames.Length; n++)
                {
                    var levelInfo = new LevelInfo();
                    levelInfo.Level = levelNames[n];
                    levelInfo.NextLevel = n + 1 < levelNames.Length ? levelNames[n + 1] : "ending";
                    levelInfo.Song = songNames[n % songNames.Length];
                    levelInfo.Character = characters[rng.Next(characters.Length)];
                    levelInfo.EventLookup = new Dictionary<int, int>();

                    foreach (var eventGroup in eventGroups)
                    {
                        var shuffledEvents = eventGroup
                            .OrderBy(x => rng.Next())
                            .ToArray();

                        for (int q = 0; q < shuffledEvents.Length; q++)
                            levelInfo.EventLookup[eventGroup[q]] = shuffledEvents[q];
                    }

                    output[i][n] = levelInfo;
                }
            }
            return output;
        }

        public static bool GetLevelIndex(string level, out int episodeIndex, out int levelIndex)
        {
            level = level.ToLower();
            for (int i = 0; i < episodes.Length; i++)
            {
                for (int n = 0; n < episodes[i].Length; n++)
                {
                    if (episodes[i][n] == level)
                    {
                        episodeIndex = i;
                        levelIndex = n;
                        return true;
                    }
                }
            }
            episodeIndex = -1;
            levelIndex = -1;
            return false;
        }
    }
}
