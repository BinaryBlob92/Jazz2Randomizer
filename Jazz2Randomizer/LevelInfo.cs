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
        public static int[][] eventGroups = new int[][]
        {
            // Ammo
            new int[] { 33, 34, 35, 36, 37, 38, 39, 40 },
            // Énemies
            new int[] { 100, 102, 103, 104, 105, 106, 107, 108, 109, 110, 113, 115, 116, 117, 118, 120, 123, 124, 125, 126, 127, 152, 183, 184, 190, 191, 196, 197, 237, 248, 249, 250, 252 },
            // Bosses
            new int[] { 101, 114, 151, 195, 199, 200, 202, 235, 247 },
        };
        static string[] songs;
        static short[] characters = new short[] { 55, 89, 61 };

        public string Level { get; set; }
        public string NextLevel { get; set; }
        public string Song { get; set; }
        public short Character { get; set; }
        public Dictionary<int, int> EventLookup { get; set; }

        static int index = 0;

        public LevelInfo(string level, string nextLevel, Random rng)
        {
            Level = level;
            NextLevel = nextLevel;
            Song = songs[rng.Next(songs.Length)];
            Character = characters[rng.Next(characters.Length)];
            EventLookup = new Dictionary<int, int>();

            foreach (var eventGroup in eventGroups)
            {
                foreach (var eventId in eventGroup)
                    EventLookup[eventId] = eventGroup[rng.Next(eventGroup.Length)];
            }
        }

        public static LevelInfo[][] GetLevelInfos(Random rng, string path)
        {
            songs = Directory.GetFiles(path)
                .Where(x => x.EndsWith(".j2b", true, null) || x.EndsWith(".it", true, null))
                .Select(x => Path.GetFileName(x))
                .ToArray();

            var output = new LevelInfo[episodes.Length][];
            for (int i = 0; i < output.Length; i++)
            {
                var levelOrder = episodes[i].OrderBy(x => rng.Next()).ToArray();
                output[i] = new LevelInfo[levelOrder.Length];
                for (int n = 0; n< levelOrder.Length; n++)
                {
                    var nextLevel = n + 1 < levelOrder.Length ? levelOrder[n + 1] : "ending";
                    output[i][n] = new LevelInfo(levelOrder[n], nextLevel, rng);
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
