using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

//v0.5
//Path data will only download once at first startup. 
//--Update option required to redownload data. Last data update is now displayed.
//Internalized data. No extra files will be created on your hard disk.
//Search now works on song title OR artist.
//Added support for Harmonies. All Rock Band 4 instruments are now supported

//Requires Windows 7 or higher.

namespace RockBand4PathVault
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
            public String DrumsPath { get; set; }
            public String DrumsNotes { get; set; }
            public String GuitarPath { get; set; }
            public String GuitarNotes { get; set; }
            public String BassPath { get; set; }
            public String BassNotes { get; set; }
            public String HarmPath { get; set; }
            public String HarmNotes { get; set; }

            public static Int32 VocalCount { get; set; }
            public static Int32 DrumCount { get; set; }
            public static Int32 GuitarCount { get; set; }
            public static Int32 BassCount { get; set; }
            public static Int32 HarmCount { get; set; }
            public static Int32 TotalCount { get; set; }

            public static String Updated { get; set; }

            public Song()
            {
                Title = "";
                Artist = "";
                VocalPath = "";
                VocalNotes = "";
                DrumsPath = "";
                DrumsNotes = "";
                GuitarPath = "";
                GuitarNotes = "";
                BassPath = "";
                BassNotes = "";
                HarmPath = "";
                HarmNotes = "";
            }
        }

        private List<Song> Songs = new List<Song>();


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
            Songs.Clear();

            List<String> links = new List<string>
            {
                //0 - Vocals
                @"https://docs.google.com/spreadsheets/d/e/2PACX-1vQn0oFUMAvzL3WOk83sn6YiG_OO-iEx3z_hcux6uJaDNLvte8R_McTgSDoulmyIwq6AF2kQApgTDJ76/pub?gid=358267987&single=true&output=tsv",
                //1 - Vocals2
                @"https://docs.google.com/spreadsheets/d/e/2PACX-1vQn0oFUMAvzL3WOk83sn6YiG_OO-iEx3z_hcux6uJaDNLvte8R_McTgSDoulmyIwq6AF2kQApgTDJ76/pub?gid=1849782495&single=true&output=tsv",
                //2 - Drums
                @"https://docs.google.com/spreadsheets/d/e/2PACX-1vQn0oFUMAvzL3WOk83sn6YiG_OO-iEx3z_hcux6uJaDNLvte8R_McTgSDoulmyIwq6AF2kQApgTDJ76/pub?gid=898076730&single=true&output=tsv",
                //3 - Guitar
                @"https://docs.google.com/spreadsheets/d/e/2PACX-1vQn0oFUMAvzL3WOk83sn6YiG_OO-iEx3z_hcux6uJaDNLvte8R_McTgSDoulmyIwq6AF2kQApgTDJ76/pub?gid=2031879843&single=true&output=tsv",
                //4 - Bass
                @"https://docs.google.com/spreadsheets/d/e/2PACX-1vQn0oFUMAvzL3WOk83sn6YiG_OO-iEx3z_hcux6uJaDNLvte8R_McTgSDoulmyIwq6AF2kQApgTDJ76/pub?gid=1635523912&single=true&output=tsv",
                //5 - About
                @"https://docs.google.com/spreadsheets/d/e/2PACX-1vQn0oFUMAvzL3WOk83sn6YiG_OO-iEx3z_hcux6uJaDNLvte8R_McTgSDoulmyIwq6AF2kQApgTDJ76/pub?gid=157720447&single=true&output=tsv",
                //6 - Vocals3
                @"https://docs.google.com/spreadsheets/d/e/2PACX-1vQn0oFUMAvzL3WOk83sn6YiG_OO-iEx3z_hcux6uJaDNLvte8R_McTgSDoulmyIwq6AF2kQApgTDJ76/pub?gid=0&single=true&output=tsv",
                //7 - Harm
                @"https://docs.google.com/spreadsheets/d/e/2PACX-1vQn0oFUMAvzL3WOk83sn6YiG_OO-iEx3z_hcux6uJaDNLvte8R_McTgSDoulmyIwq6AF2kQApgTDJ76/pub?gid=686163764&single=true&output=tsv",
            };

            List<String[]> files = Properties.Settings.Default.FilesSaved;

            if (files == null || arg == "forced")
            {
                files = new List<String[]>();

                using (var client = new WebClient())
                {
                    try
                    {
                        links.ForEach(link =>
                            files.Add(client.DownloadString(link).Split('\n'))
                        );
                    }
                    catch (WebException ex)
                    {
                        MessageBox.Show("Something went wrong!\nMost likely there is no internet connection.\n\nDETAILS: " + ex.ToString(), "Ruh-roh Raggy!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                Properties.Settings.Default.FilesSaved = files;
                Properties.Settings.Default.FilesSavedTime = DateTime.Now;
                Properties.Settings.Default.Save();
            }

            Song.Updated = files[5][1].Split('\t')[2];

            //Read and store path info.
            for (var x = 2; x < files[0].Length; x++)
            {
                Songs.Add(new Song
                {
                    Title = files[0][x].Split('\t')[0],
                    Artist = files[0][x].Split('\t')[1],
                    VocalPath = files[0][x].Split('\t')[2],
                    VocalNotes = files[0][x].Split('\t')[3],
                    DrumsPath = files[2][x].Split('\t')[2],
                    DrumsNotes = files[2][x].Split('\t')[3],
                    GuitarPath = files[3][x].Split('\t')[2],
                    GuitarNotes = files[3][x].Split('\t')[3],
                    BassPath = files[4][x].Split('\t')[2],
                    BassNotes = files[4][x].Split('\t')[3],
                    HarmPath = files[7][x].Split('\t')[2],
                    HarmNotes = files[7][x].Split('\t')[3],
                });
            }

            var songsOld = new List<Song>();
            var songsOld2 = new List<Song>();

            String[] lines2 = files[1].Skip(2).ToArray();
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

            String[] lines3 = files[6].Skip(2).ToArray();
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

            //Add in old vocal paths.
            foreach (var song in Songs)
            {
                if (song.VocalPath == "")
                {
                    var songTemp = songsOld2.Find(songOld => songOld.Title.ToLower() == song.Title.ToLower());

                    if (songTemp == null)
                        songTemp = songsOld.Find(songOld => songOld.Title.ToLower() == song.Title.ToLower());

                    if (songTemp != null)
                    {
                        song.VocalPath = songTemp.VocalPath;
                        song.VocalNotes = songTemp.VocalNotes;
                    }
                }
            }

            Song.TotalCount = Songs.Count;

            //Remove songs with no paths.
            Songs = Songs.Where(song =>
                song.VocalPath != "" ||
                song.DrumsPath != "" ||
                song.GuitarPath != "" || 
                song.BassPath != "" ||
                song.HarmPath != ""
                ).ToList();

            //Save path counts.
            Song.VocalCount = Songs.Where(song => song.VocalPath != "").Count();
            Song.DrumCount = Songs.Where(song => song.DrumsPath != "").Count();
            Song.GuitarCount = Songs.Where(song => song.GuitarPath != "").Count();
            Song.BassCount = Songs.Where(song => song.BassPath != "").Count();
            Song.HarmCount = Songs.Where(song => song.HarmPath != "").Count();
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
            ToolStripMenuItem_Reload.Enabled = false;

            Thread1.RunWorkerAsync();
        }


        //OBJECT LISTENERS
        private void TextBox_Input_TextChanged(object sender, EventArgs e)
        {
            ClearDisplay();

            ListBox_SongSelect_SelectedIndexChanged(null, EventArgs.Empty);
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
            var songsFiltered = Songs.Where(song =>
                song.Title.ToLower().Contains(TextBox_Input.Text.ToLower()) ||
                song.Artist.ToLower().Contains(TextBox_Input.Text.ToLower())
            ).ToList();

            if (sender == null)
            {

                songsFiltered.ForEach(song =>
                    ListBox_SongSelect.Items.Add(song.Title + " - " + song.Artist)
                );
            }

            if (ListBox_SongSelect.SelectedIndex != -1)
            {
                if (ToolStripMenuItem_Harmonies.Checked)
                {
                    Label_Vocals1.Text = songsFiltered[ListBox_SongSelect.SelectedIndex].HarmPath;
                    Label_Vocals2.Text = songsFiltered[ListBox_SongSelect.SelectedIndex].HarmNotes;
                }
                else
                {
                    Label_Vocals1.Text = songsFiltered[ListBox_SongSelect.SelectedIndex].VocalPath;
                    Label_Vocals2.Text = songsFiltered[ListBox_SongSelect.SelectedIndex].VocalNotes;
                }

                Label_Drums1.Text = songsFiltered[ListBox_SongSelect.SelectedIndex].DrumsPath;
                Label_Drums2.Text = songsFiltered[ListBox_SongSelect.SelectedIndex].DrumsNotes;
                Label_Guitar1.Text = songsFiltered[ListBox_SongSelect.SelectedIndex].GuitarPath;
                Label_Guitar2.Text = songsFiltered[ListBox_SongSelect.SelectedIndex].GuitarNotes;
                Label_Bass1.Text = songsFiltered[ListBox_SongSelect.SelectedIndex].BassPath;
                Label_Bass2.Text = songsFiltered[ListBox_SongSelect.SelectedIndex].BassNotes;
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
            ToolStripMenuItem_Reload.Enabled = true;

            ToolStripMenuItem_LastReload.Text = "Updated: " + Properties.Settings.Default.FilesSavedTime.Date.ToString("MM/dd/yy") + " - " + Properties.Settings.Default.FilesSavedTime.ToString("t");
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

        private void ToolStripMenuItem_Info_Click(Object sender, EventArgs e)
        {
            MessageBox.Show(
                "Developed by DosParkers" + 
                "\n...with help from..." + 
                "\nAlec Mori / It'sUncleCarl / Stanno7 / iGasPo / killercain7" +
                "\n\nRB4 Songs: " + Song.TotalCount + 
                "\nVocal Paths: " + Song.VocalCount + 
                "\nHarmony Paths: " + Song.HarmCount +
                "\nDrum Paths: " + Song.DrumCount + 
                "\nGuitar Paths: " + Song.GuitarCount + 
                "\nBass Paths: " + Song.BassCount + 
                "\n\nUpdated: " + Song.Updated +
                "\n\nNote: Database is updated every 5 minutes.",
                "Version 0.5",
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
                ToolStripMenuItem_Reload.Enabled = false;

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

        private void ToolStripMenuItem_Harmonies_Click(Object sender, EventArgs e)
        {
            ListBox_SongSelect_SelectedIndexChanged(new Object(), EventArgs.Empty);

            if(ToolStripMenuItem_Harmonies.Checked)
            {
                Label_Vocals1.BackColor = Color.Orange;
                Label_Vocals2.BackColor = Color.Orange;
                Label_Title_Vocals.Text = "HARMONIES";
                Label_Title_Vocals.Font = new Font(Label_Title_Vocals.Font.FontFamily, (Single)12.0);
            }
            else
            {
                Label_Vocals1.BackColor = Color.Gold;
                Label_Vocals2.BackColor = Color.Gold;
                Label_Title_Vocals.Text = "VOCALS";
                Label_Title_Vocals.Font = new Font(Label_Title_Vocals.Font.FontFamily, (Single)16.2);
            }
        }
    }
}
