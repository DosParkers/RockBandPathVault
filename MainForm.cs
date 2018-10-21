using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Drawing;
using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace Rock_Band_4_Path_Vault
{
    public partial class Form_Main : Form
    {
        //CLASSES
        private class NativeMethods
        {
            public static UInt32 WM_NCLBUTTONDOWN = 0xA1;
            public static IntPtr HT_CAPTION = (IntPtr)0x2;

            [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
            public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
            [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
            public static extern Boolean ReleaseCapture();
        }

        private class Song
        {
            public String Title { get; set; }
            public String Artist { get; set; }
            public String VocalPath { get; set; }
            public String VocalNotes { get; set; }
            public String DrumPath { get; set; }
            public String DrumNotes { get; set; }
            public String GuitarPath { get; set; }
            public String GuitarNotes { get; set; }
            public String BassPath { get; set; }
            public String BassNotes { get; set; }

            public static Int32 VocalCount { get; set; }
            public static Int32 DrumCount { get; set; }
            public static Int32 GuitarCount { get; set; }
            public static Int32 BassCount { get; set; }
            public static Int32 TotalCount { get; set; }

            public static String Updated { get; set; }

            public Song()
                {
                Title = "";
                Artist = "";
                VocalPath = "";
                VocalNotes = "";
                DrumPath = "";
                DrumNotes = "";
                GuitarPath = "";
                GuitarNotes = "";
                BassPath = "";
                BassNotes = "";
            }
        }
        
        private List<Song> songsSearch = new List<Song>();
        private List<Song> songsSelect = new List<Song>();

        
        //CUSTOM FUNCTIONS/METHODS
        private void ClearDisplay()
        {
            ListBox_SongSelect.Items.Clear();
            Label_Bass1.Text = "";
            Label_Bass2.Text = "";
            Label_Guitar1.Text = "";
            Label_Guitar2.Text = "";
            Label_Drums1.Text = "";
            Label_Drums2.Text = "";
            Label_Vocals1.Text = "";
            Label_Vocals2.Text = "";
        }

        private void LoadData(String arg)
        {
            songsSearch.Clear();
            songsSelect.Clear();

            List<String> fileNames = new List<string>
            {
                @"vocalData",
                @"vocalData2",
                @"drumData",
                @"guitarData",
                @"bassData",
                @"about",
                @"vocalData3"
            };

            List<String> links = new List<string>
            {
                @"https://docs.google.com/spreadsheets/d/e/2PACX-1vQn0oFUMAvzL3WOk83sn6YiG_OO-iEx3z_hcux6uJaDNLvte8R_McTgSDoulmyIwq6AF2kQApgTDJ76/pub?gid=358267987&single=true&output=tsv",
                @"https://docs.google.com/spreadsheets/d/e/2PACX-1vQn0oFUMAvzL3WOk83sn6YiG_OO-iEx3z_hcux6uJaDNLvte8R_McTgSDoulmyIwq6AF2kQApgTDJ76/pub?gid=1849782495&single=true&output=tsv",
                @"https://docs.google.com/spreadsheets/d/e/2PACX-1vQn0oFUMAvzL3WOk83sn6YiG_OO-iEx3z_hcux6uJaDNLvte8R_McTgSDoulmyIwq6AF2kQApgTDJ76/pub?gid=898076730&single=true&output=tsv",
                @"https://docs.google.com/spreadsheets/d/e/2PACX-1vQn0oFUMAvzL3WOk83sn6YiG_OO-iEx3z_hcux6uJaDNLvte8R_McTgSDoulmyIwq6AF2kQApgTDJ76/pub?gid=2031879843&single=true&output=tsv",
                @"https://docs.google.com/spreadsheets/d/e/2PACX-1vQn0oFUMAvzL3WOk83sn6YiG_OO-iEx3z_hcux6uJaDNLvte8R_McTgSDoulmyIwq6AF2kQApgTDJ76/pub?gid=1635523912&single=true&output=tsv",
                @"https://docs.google.com/spreadsheets/d/e/2PACX-1vQn0oFUMAvzL3WOk83sn6YiG_OO-iEx3z_hcux6uJaDNLvte8R_McTgSDoulmyIwq6AF2kQApgTDJ76/pub?gid=157720447&single=true&output=tsv",
                @"https://docs.google.com/spreadsheets/d/e/2PACX-1vQn0oFUMAvzL3WOk83sn6YiG_OO-iEx3z_hcux6uJaDNLvte8R_McTgSDoulmyIwq6AF2kQApgTDJ76/pub?gid=0&single=true&output=tsv",
            };

            //Download files.
            try
            {
                for (int i = 0; i < fileNames.Count; i++)
                {
                    if (arg == "forced" || !System.IO.File.Exists(fileNames[i]) || System.IO.File.GetLastWriteTime(fileNames[i]) < DateTime.Now.AddMinutes(-5))
                    {
                        using (var client = new WebClient())
                        {
                            client.DownloadFile(links[i], fileNames[i]);
                        }
                    }
                }

                String[] linesAbout = System.IO.File.ReadAllLines(fileNames[5]).Skip(1).ToArray();
                Song.Updated = linesAbout[0].Split('\t')[2];

                //Read and store path info.
                String[] linesVocal = System.IO.File.ReadAllLines(fileNames[0]).Skip(2).ToArray();
                String[] linesDrum = System.IO.File.ReadAllLines(fileNames[2]).Skip(2).ToArray();
                String[] linesGuitar = System.IO.File.ReadAllLines(fileNames[3]).Skip(2).ToArray();
                String[] linesBass = System.IO.File.ReadAllLines(fileNames[4]).Skip(2).ToArray();

                for (int x = 0; x < linesVocal.Length; x++)
                {
                    string[] lineVocal = linesVocal[x].Split('\t');
                    string[] lineDrum = linesDrum[x].Split('\t');
                    string[] lineGuitar = linesGuitar[x].Split('\t');
                    string[] lineBass = linesBass[x].Split('\t');

                    songsSearch.Add(new Song
                    {
                        Title = lineVocal[0],
                        Artist = lineVocal[1],
                        VocalPath = lineVocal[2],
                        VocalNotes = lineVocal[3],
                        DrumPath = lineDrum[2],
                        DrumNotes = lineDrum[3],
                        GuitarPath = lineGuitar[2],
                        GuitarNotes = lineGuitar[3],
                        BassPath = lineBass[2],
                        BassNotes = lineBass[3],
                    });
                }

                var songsOld = new List<Song>();
                var songsOld2 = new List<Song>();

                string[] lines2 = System.IO.File.ReadAllLines(fileNames[1]).Skip(2).ToArray();
                foreach (string line in lines2)
                {
                    string[] lineFormat = line.Split('\t');
                    songsOld.Add(new Song
                    {
                        Title = lineFormat[0],
                        Artist = lineFormat[1],
                        VocalPath = lineFormat[2],
                        VocalNotes = ""
                    });
                }

                String[] lines3 = System.IO.File.ReadAllLines(fileNames[6]).Skip(2).ToArray();
                foreach (var line in lines3)
                {
                    var lineFormat = line.Split('\t');
                    songsOld2.Add(new Song
                    {
                        Title = lineFormat[0],
                        Artist = lineFormat[1],
                        VocalPath = lineFormat[2],
                        VocalNotes = lineFormat[3],
                    });
                }

                foreach (var song in songsSearch)
                {
                    if (song.VocalPath == "")
                    {
                        var songTemp = songsOld2.Where(songOld => songOld.Title.ToLower() == song.Title.ToLower()).ToList();
                        if (songTemp.Count == 0)
                        {
                            songTemp = songsOld.Where(songOld => songOld.Title.ToLower() == song.Title.ToLower()).ToList();
                        }

                        if (songTemp.Count > 0)
                        {
                            song.VocalPath = songTemp[0].VocalPath;
                            song.VocalNotes = songTemp[0].VocalNotes;
                        }
                    }
                }

                Song.TotalCount = songsSearch.Count;

                //Remove songs with no paths.
                songsSearch = songsSearch.Where(song =>
                    song.VocalPath != "" || song.DrumPath != "" ||
                    song.GuitarPath != "" || song.BassPath != ""
                    ).ToList();

                //Save path counts.
                Song.VocalCount = songsSearch.Where(song => song.VocalPath != "").Count();
                Song.DrumCount = songsSearch.Where(song => song.DrumPath != "").Count();
                Song.GuitarCount = songsSearch.Where(song => song.GuitarPath != "").Count();
                Song.BassCount = songsSearch.Where(song => song.BassPath != "").Count();
            }
            catch (WebException ex)
            {
                MessageBox.Show("Something went wrong!\nMost likely there is no internet connection.\n\nDETAILS: " + ex.ToString(), "Ruh-roh Raggy!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //STARTUP
        public Form_Main()
        {
            InitializeComponent();
        }

        private void Form_Main_Shown(object sender, EventArgs e)
        {
            ClearDisplay();
            Label_Message.BringToFront();
            Label_Message.Dock = DockStyle.Fill;
            Label_Message.Text = "Loading data...";
            Label_Message.Visible = true;
            TextBox_Input.ReadOnly = true;
            MenuStrip1.Enabled = false;

            Thread1.RunWorkerAsync();
        }


        //OBJECT LISTENERS
        private void TextBox_Input_TextChanged(object sender, EventArgs e)
        {
            ClearDisplay();

            songsSelect = songsSearch.Where(song => song.Title.ToLower().Contains(TextBox_Input.Text.ToLower())).ToList();

            songsSelect.ForEach(song =>
                ListBox_SongSelect.Items.Add(song.Title + " - " + song.Artist)
            );

            if(ListBox_SongSelect.Items.Count > 0)
                ListBox_SongSelect.SelectedIndex = 0;
        }

        private void TextBox_Input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down && ListBox_SongSelect.SelectedIndex < ListBox_SongSelect.Items.Count - 1)
            {
                ListBox_SongSelect.SelectedIndex++;
                e.Handled = true;
            }

            if (e.KeyData == Keys.Up && ListBox_SongSelect.SelectedIndex > 0)
            {
                ListBox_SongSelect.SelectedIndex--;
                e.Handled = true;
            }
        }

        private void ListBox_SongSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (songsSelect.Count > 0)
            {
                Label_Vocals1.Text = songsSelect[ListBox_SongSelect.SelectedIndex].VocalPath;
                Label_Vocals2.Text = songsSelect[ListBox_SongSelect.SelectedIndex].VocalNotes;
                Label_Drums1.Text = songsSelect[ListBox_SongSelect.SelectedIndex].DrumPath;
                Label_Drums2.Text = songsSelect[ListBox_SongSelect.SelectedIndex].DrumNotes;
                Label_Guitar1.Text = songsSelect[ListBox_SongSelect.SelectedIndex].GuitarPath;
                Label_Guitar2.Text = songsSelect[ListBox_SongSelect.SelectedIndex].GuitarNotes;
                Label_Bass1.Text = songsSelect[ListBox_SongSelect.SelectedIndex].BassPath;
                Label_Bass2.Text = songsSelect[ListBox_SongSelect.SelectedIndex].BassNotes;
            }
        }


        //LOAD DATA
        private void Thread1_DoWork(Object sender, DoWorkEventArgs e)
        {
            if (e.Argument == null)
            {
                LoadData("");
            }
            else
            {
                LoadData(e.Argument.ToString());
            }
        }

        private void Thread1_RunWorkerCompleted(Object sender, RunWorkerCompletedEventArgs e)
        {
            ClearDisplay();
            Label_Message.Visible = false;
            TextBox_Input.ReadOnly = false;
            MenuStrip1.Enabled = true;
        }


        //TOOLSTRIP
        private void MenuStrip1_MouseDown(Object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(Handle, NativeMethods.WM_NCLBUTTONDOWN, NativeMethods.HT_CAPTION, IntPtr.Zero);
            }
        }

        private void ToolStripMenuItem_About_Click(Object sender, EventArgs e)
        {
            MessageBox.Show("Developed by DosParkers\n...with help from...\nAlec Mori / It'sUncleCarl / Stanno7 / iGasPo / killercain7\n\nRB4 Songs: " + Song.TotalCount + "\nVocal Paths: " + Song.VocalCount + "\nDrum Paths: " + Song.DrumCount + "\nGuitar Paths: " + Song.GuitarCount + "\nBass Paths: " + Song.BassCount + "\n\nUpdated: " + Song.Updated,
                "Version 0.4 BETA",
                MessageBoxButtons.OK,
                MessageBoxIcon.Question
                );
        }

        private void ToolStripMenuItem_Exit_Click(Object sender, EventArgs e)
        {
            Close();
        }

        private void ToolStripMenuItem_Help_Click(Object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://bit.ly/2yLDiDj");
        }

        private void ToolStripMenuItem_Reload_Click(Object sender, EventArgs e)
        {
            if (!Thread1.IsBusy)
            {
                Label_Message.Visible = true;
                TextBox_Input.ReadOnly = true;
                MenuStrip1.Enabled = false;

                Thread1.RunWorkerAsync("forced");
            }
        }

        private void ToolStripItem_OnlinePlay_Click(Object sender, EventArgs e)
        {
            if(ToolStripItem_OnlinePlay.Checked)
            {
                Label_Vocals2.Visible = false;
                Label_Drums2.Visible = false;
                Label_Guitar2.Visible = false;
                Label_Bass2.Visible = false;

                Label_Vocals1.Size = new System.Drawing.Size(Label_Vocals1.Width, Label_Vocals2.Bottom - Label_Vocals1.Top);
                Label_Drums1.Size = new System.Drawing.Size(Label_Drums1.Width, Label_Drums2.Bottom - Label_Drums1.Top);
                Label_Guitar1.Size = new System.Drawing.Size(Label_Guitar1.Width, Label_Guitar2.Bottom - Label_Guitar1.Top);
                Label_Bass1.Size = new System.Drawing.Size(Label_Bass1.Width, Label_Bass2.Bottom - Label_Bass1.Top);
            }
            else
            {
                Label_Vocals2.Visible = true;
                Label_Drums2.Visible = true;
                Label_Guitar2.Visible = true;
                Label_Bass2.Visible = true;
                
                Label_Vocals1.Height = 35;
                Label_Drums1.Height = 35;
                Label_Guitar1.Height = 35;
                Label_Bass1.Height = 35;
            }
        }
    }
}
