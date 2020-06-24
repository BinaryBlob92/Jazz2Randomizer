using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;

namespace Jazz2Randomizer
{
    [DataContract]
    public class RandomizerSettings
    {
        private Random rng;

        [DataMember(Order = 0)]
        public List<LevelSettings> LevelSettings { get; set; }
        [DataMember(Order = 1)]
        public List<string> Songs { get; set; }
        [IgnoreDataMember]
        public string[] LevelOrder { get; private set; }

        public RandomizerSettings()
        {
            LevelSettings = new List<LevelSettings>();
            Songs = new List<string>();
        }

        public static RandomizerSettings Load(string filename)
        {
            if (Path.GetExtension(filename).Equals(".j2r", StringComparison.InvariantCultureIgnoreCase))
                return LoadJ2R(filename);
            else
                return LoadXML(filename);
        }

        public static RandomizerSettings LoadXML(string filename)
        {
            using (var reader = XmlReader.Create(filename))
            {
                var serializer = new DataContractSerializer(typeof(RandomizerSettings));
                return (RandomizerSettings)serializer.ReadObject(reader);
            }
        }

        public static RandomizerSettings LoadJ2R(string filename)
        {
            using (var fileStream = new FileStream(filename, FileMode.Open))
            using (var stream = new DeflateStream(fileStream, CompressionMode.Decompress))
            {
                var serializer = new DataContractSerializer(typeof(RandomizerSettings));
                return (RandomizerSettings)serializer.ReadObject(stream);
            }
        }

        public void LoadFrom(string filename)
        {
            var settings = Load(filename);
            LevelSettings = settings.LevelSettings;
            Songs = settings.Songs;
        }

        public void Save(string filename)
        {
            if (Path.GetExtension(filename).Equals(".j2r", StringComparison.InvariantCultureIgnoreCase))
                SaveJ2R(filename);
            else
                SaveXML(filename);
        }

        public void SaveXML(string filename)
        {
            using (var writer = XmlWriter.Create(filename, new XmlWriterSettings() { Indent = true }))
            {
                var serializer = new DataContractSerializer(typeof(RandomizerSettings));
                serializer.WriteObject(writer, this);
            }
        }

        public void SaveJ2R(string filename)
        {
            using (var fileStream = new FileStream(filename, FileMode.Create))
            using (var stream = new DeflateStream(fileStream, CompressionMode.Compress))
            {
                var serializer = new DataContractSerializer(typeof(RandomizerSettings));
                serializer.WriteObject(stream, this);
            }
        }

        public void SetSeed(int seed)
        {
            foreach (var levelSettings in LevelSettings)
                levelSettings.Reset();

            rng = new Random(seed);
            LevelOrder = LevelSettings
                .Select(x => x.LevelFilename.ToLower())
                .OrderBy(x => rng.Next())
                .ToArray();
        }

        public void OnLoadLevel(Jazz2 jazz2)
        {
            jazz2.Read(jazz2.Address + 0x1F3884, out string levelName, 32);
            var levelIndex = Array.IndexOf(LevelOrder, levelName.ToLower());
            if (levelIndex >= 0 && levelIndex < LevelSettings.Count)
            {
                var nextLevel = levelIndex + 1 < LevelOrder.Length ? LevelOrder[levelIndex + 1] : "ending";
                jazz2.Write(jazz2.Address + 0x14D5D3, nextLevel, 32);
                LevelSettings[levelIndex].OnLoadLevel(jazz2, rng);
            }
        }

        public void OnLoadTileset(Jazz2 jazz2)
        {
            int[] colors = new int[256];
            jazz2.Read(jazz2.Address + 0x1607A0, colors);
            for (int i = 0; i < colors.Length; i++)
            {
                ColorToHSV(Color.FromArgb(colors[i]), out double hue, out double saturation, out double value);
                colors[i] = ColorFromHSV(hue + 180, saturation, value).ToArgb();
            }
            jazz2.Write(jazz2.Address + 0x1607A0, colors);
        }

        public static void ColorToHSV(Color color, out double hue, out double saturation, out double value)
        {
            int max = Math.Max(color.R, Math.Max(color.G, color.B));
            int min = Math.Min(color.R, Math.Min(color.G, color.B));

            hue = color.GetHue();
            saturation = (max == 0) ? 0 : 1d - (1d * min / max);
            value = max / 255d;
        }

        public static Color ColorFromHSV(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return Color.FromArgb(255, v, t, p);
            else if (hi == 1)
                return Color.FromArgb(255, q, v, p);
            else if (hi == 2)
                return Color.FromArgb(255, p, v, t);
            else if (hi == 3)
                return Color.FromArgb(255, p, q, v);
            else if (hi == 4)
                return Color.FromArgb(255, t, p, v);
            else
                return Color.FromArgb(255, v, p, q);
        }
    }
}
