using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using RB4PV;

/*
v0.7
FEATURES
-Added spotlight text under star.
-Added spotlight shine option.
--Lists only spotlights in the select list.
-Added in another source for vocal paths.
--**Current vocal path count is 2574/2574 COMPLETE.

BUG FIXES
-Touched up the vocal data. Everything looks perfect now.

TECHNICAL
-Migrating main functions into seperate file (RB4PV.cs) to seperate code from GUI.
-Program now saves parsed data instead raw data. This should reduce load times by alot.

TO DO
-Add Gold Star Only option
--For solo vocals it will attempt to simplify the path down to the easiest possible path.
----Going to put this part on hold until all paths are one one sheet.
--It will also display if you need to do the tap sections or not; as well as display if the song is talkies only (therefore easily FC'ed on brutal mode).

REQUIREMENTS
-Windows 7 or better.
*/

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
        
        private SongData Songs { get; set; }

        //GOOD
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
        
        //GOOD
        private void PopulateSongSelect()
        {
            ClearDisplay();
            var songs = new SongData();

            if (ToolStripMenuItem_SpotlightShine.Checked)
            {
                songs.Songs = Songs.SpotlightOnly;
            }
            else
            {
                songs.Songs = Songs.Filter(TextBox_Input.Text);
            }

            songs.Songs.ForEach(song =>
                ListBox_SongSelect.Items.Add(song.Title + " - " + song.Artist)
                );

            if (ListBox_SongSelect.Items.Count > 0)
                ListBox_SongSelect.SelectedIndex = 0;
        }

        //GOOD
        private void DisplayPaths()
        {
            var songs = Songs.Filter(TextBox_Input.Text);
            if (ToolStripMenuItem_SpotlightShine.Checked)
                songs = Songs.SpotlightOnly;

            var i = ListBox_SongSelect.SelectedIndex;

            if (i != -1)
            {
                PictureBox_Spotlight.Visible = songs[i].IsSpotlight;
                Label_Spotlight.Visible = songs[i].IsSpotlight;
                    
                Label_Drums1.Text = songs[i].DrumsPath;
                Label_Drums2.Text = songs[i].DrumsNotes;

                if (ToolStripMenuItem_FullBand.Checked)
                {
                    Label_Vocals1.Text = "Activate with drums.";
                    Label_Vocals2.Text = "";
                    Label_Guitar1.Text = "Activate with drums.";
                    Label_Guitar2.Text = "";
                    Label_Bass1.Text = "Activate with drums.";
                    Label_Bass2.Text = "";
                }
                else
                {
                    if (ToolStripMenuItem_Harmonies.Checked)
                    {
                        Label_Vocals1.Text = songs[i].HarmPath;
                        Label_Vocals2.Text = songs[i].HarmNotes;
                    }
                    else
                    {
                        if (ToolStripMenuItem_GoldStar.Checked)
                        {
                            //???
                            //reduce the path
                            //delete all "S
                            Label_Vocals1.Text = songs[i].VocalPath;
                            Label_Vocals2.Text = songs[i].VocalNotes;
                        }
                        else
                        {
                            Label_Vocals1.Text = songs[i].VocalPath;
                            Label_Vocals2.Text = songs[i].VocalNotes;
                        }
                    }

                    Label_Guitar1.Text = songs[i].GuitarPath;
                    Label_Guitar2.Text = songs[i].GuitarNotes;
                    Label_Bass1.Text = songs[i].BassPath;
                    Label_Bass2.Text = songs[i].BassNotes;
                }
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
            for (Int32 i = 0; i < MenuStrip1.Items.Count; i++)
                MenuStrip1.Items[i].Enabled = false;

            Thread1.RunWorkerAsync();
        }


        //OBJECT LISTENERS
        private void TextBox_Input_TextChanged(object sender, EventArgs e)
        {
            PopulateSongSelect();
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
            DisplayPaths();
        }


        //LOAD DATA
        private void Thread1_DoWork(Object sender, DoWorkEventArgs e)
        {
            Songs = Funct.Deserialize(Properties.Settings.Default.Songs);

            if (Songs == null || (String)e.Argument == "f")
            {
                try
                {
                    Songs = Funct.GetSongData();
                }
                catch(WebException webEx)
                {
                    MessageBox.Show(
                        "The song data could not be retrieved. Most likely there was no internet connection. Please try again.\n\n" + 
                        webEx.Message,
                        "Ruh-roh!", 
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation
                        );
                }
            }

            Properties.Settings.Default.Songs = Funct.Serialize(Songs);
            Properties.Settings.Default.Save();
        }

        private void Thread1_RunWorkerCompleted(Object sender, RunWorkerCompletedEventArgs e)
        {
            ClearDisplay();
            Label_Message.Visible = false;
            TextBox_Input.ReadOnly = false;
        
            for (Int32 i = 0; i < MenuStrip1.Items.Count; i++)
                MenuStrip1.Items[i].Enabled = true;

            ToolStripMenuItem_LastReload.Text = "Updated: " + 
                Songs.TimeOfDownload.ToString("MM/dd/yy") + 
                " - " +
                Songs.TimeOfDownload.ToString("t");
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
                "\nAlec Mori / ScoreHero" +
                "\nIt'sUncleCarl / iGasPo / Stanno7 / killercain7" +
                "\n\nRB4 Songs: " + Songs.Songs.Count.ToString("D") + 
                "\nVocal Paths: " + Songs.VocalCount.ToString("D") + 
                "\nHarmony Paths: " + Songs.HarmCount.ToString("D") +
                "\nDrum Paths: " + Songs.DrumCount.ToString("D") + 
                "\nGuitar Paths: " + Songs.GuitarCount.ToString("D") + 
                "\nBass Paths: " + Songs.BassCount.ToString("D") + 
                "\n\nUnique Spotlights: " + Songs.SpotlightUnique.ToString("D") +
                "\nRepeat Spotlights: " + (Songs.SpotlightTotal - Songs.SpotlightUnique).ToString("D") +
                "\nTotal Spotlights: " + Songs.SpotlightTotal.ToString("D") +
                "\n\nUpdated for new DLC: " + Songs.UpdateWeek +
                "\n\nNote: Database is only updated every 5 minutes and actual paths are updated/added a lot more infrequently.",
                "Version 0.7",
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
                Label_Message.Text = "Loading data...";
                Label_Message.Visible = true;
                TextBox_Input.ReadOnly = true;
                for (Int32 i = 0; i < MenuStrip1.Items.Count; i++)
                    MenuStrip1.Items[i].Enabled = false;

                Thread1.RunWorkerAsync("f");
            }
        }

        private void ToolStripMenuItem_OnlinePlay_Click(Object sender, EventArgs e)
        {
            if(ToolStripMenuItem_OnlinePlay.Checked)
            {
                Label_Vocals2.Visible = false;
                Label_Drums2.Visible = false;
                Label_Guitar2.Visible = false;
                Label_Bass2.Visible = false;

                Label_Vocals1.Size = new Size(Label_Vocals1.Width, Label_Vocals2.Bottom - Label_Vocals1.Top);
                Label_Drums1.Size = new Size(Label_Drums1.Width, Label_Drums2.Bottom - Label_Drums1.Top);
                Label_Guitar1.Size = new Size(Label_Guitar1.Width, Label_Guitar2.Bottom - Label_Guitar1.Top);
                Label_Bass1.Size = new Size(Label_Bass1.Width, Label_Bass2.Bottom - Label_Bass1.Top);
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

            DisplayPaths();
        }

        private void ToolStripMenuItem_Min_Click(Object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void ToolStripMenuItem_FullBand_Click(Object sender, EventArgs e)
        {
            DisplayPaths();
        }

        private void ToolStripMenuItem_GoldStar_Click(Object sender, EventArgs e)
        {
            DisplayPaths();
        }

        private void ToolStripMenuItem_SpotlightShine_Click(Object sender, EventArgs e)
        {
           PopulateSongSelect();
           DisplayPaths();
        }
    }
}