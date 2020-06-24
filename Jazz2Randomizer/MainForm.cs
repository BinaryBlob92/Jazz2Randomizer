using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Jazz2Randomizer
{
    public partial class MainForm : Form
    {
        private IntPtr loadPointer;
        private Jazz2 jazz2;
        private Thread loopThread;
        private bool exitLoop;
        private Random rng;
        private RandomizerSettings randomizerSettings;

        public MainForm()
        {
            InitializeComponent();
            Text = ProductName + " " + ProductVersion;

            jazz2 = new Jazz2();
            jazz2.ProcessFound += Jazz2_ProcessFound;
            jazz2.ProcessClosed += Jazz2_ProcessClosed;

            loopThread = new Thread(LoopProc);
            loopThread.Start();

            randomizerSettings = new RandomizerSettings();
            randomizerSettings.LevelSettings.Add(new LevelSettings() { LevelFilename = "carrot1.j2l", Bird = true, Jazz = true });
            randomizerSettings.LevelSettings.Add(new LevelSettings() { LevelFilename = "castle1n.j2l", Bird = true, Spaz = true });

            textBoxSeed.Text = new Random().Next().ToString("X8");
        }

        private void Jazz2_ProcessClosed(object sender, EventArgs e)
        {
            loadPointer = IntPtr.Zero;
        }

        private void Jazz2_ProcessFound(object sender, EventArgs e)
        {
            var functionPointer = jazz2.Allocate(
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
            loadPointer = jazz2.Allocate(0x00, 0x00, 0x00, 0x00);
            jazz2.Write(functionPointer + 3, (int)loadPointer);
            jazz2.Write(functionPointer + 25, jazz2.Address + 0x8F0C0);
            jazz2.Write(jazz2.Address + 0x3FD49, functionPointer);

            var functionPointer2 = jazz2.Allocate(
                0x50,                                       // push eax
                0x55,                                       // push ebp
                0xBD, 0x00, 0x00, 0x00, 0x00,               // mov ebp,00000000
                0xC7, 0x45, 0x00, 0x02, 0x00, 0x00, 0x00,   // mov [ebp],00000002
                0x8B, 0x45, 0x00,                           // mov eax,[ebp]
                0x83, 0xF8, 0x02,                           // cmp eax,02
                0x74, 0xF8,                                 // je ...
                0x58,                                       // pop eax
                0x5D,                                       // pop epb
                0x83, 0xFF, 0xFD,                           // cmp edi,-03
                0x0F, 0x84, 0x00, 0x00, 0x00, 0x00,         // je ....
                0xC3                                        // ret
            );
            jazz2.Write(functionPointer2 + 3, (int)loadPointer);
            jazz2.Write(functionPointer2 + 29, jazz2.Address + 0x66217);
            jazz2.Write(jazz2.Address + 0x66290, (byte)0xE8);
            jazz2.Write(jazz2.Address + 0x66291, functionPointer2);
        }

        private void LoopProc()
        {
            while (!exitLoop)
            {
                if (jazz2.IsRunning && loadPointer != IntPtr.Zero && randomizerSettings.LevelOrder.Length > 0)
                {
                    jazz2.Read(jazz2.Address + 0x1F3884, out string levelName, 32);
                    if (levelName.ToUpper() == levelName && levelName != randomizerSettings.LevelOrder[0].ToUpper())
                        jazz2.Write(jazz2.Address + 0x1F3884, randomizerSettings.LevelOrder[0].ToUpper(), 32);

                    jazz2.Read(loadPointer, out int loadValue);
                    if (loadValue == 1)
                    {
                        randomizerSettings.OnLoadLevel(jazz2);
                        jazz2.Write(loadPointer, 0);
                    }
                    else if (loadValue == 2)
                    {
                        randomizerSettings.OnLoadTileset(jazz2);
                        jazz2.Write(loadPointer, 0);

                    }
                }
                Thread.Sleep(1000 / 60);
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            exitLoop = true;
            loopThread.Join();
            jazz2.Dispose();
            base.OnClosing(e);
        }

        private void TextBoxSeed_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxSeed.Text, NumberStyles.HexNumber, null, out int seed))
            {
                textBoxSeed.BackColor = Color.Lime;
                randomizerSettings.SetSeed(seed);
            }
            else
            {
                textBoxSeed.BackColor = Color.Red;
            }
        }

        private void ButtonRandomizeSeed_Click(object sender, EventArgs e)
        {
            textBoxSeed.Text = new Random().Next().ToString("X8");
        }

        private void ButtonSettings_Click(object sender, EventArgs e)
        {
            using (var dialog = new RandomizerSettingsForm(randomizerSettings))
            {
                dialog.ShowDialog();
            }
        }
    }
}
