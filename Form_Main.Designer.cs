namespace RockBand4PathVault
{
    partial class Form_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.TextBox_Input = new System.Windows.Forms.TextBox();
            this.ListBox_SongSelect = new System.Windows.Forms.ListBox();
            this.Label_Title_Search = new System.Windows.Forms.Label();
            this.Label_Title_Select = new System.Windows.Forms.Label();
            this.Label_Message = new System.Windows.Forms.Label();
            this.Label_Title_Vocals = new System.Windows.Forms.Label();
            this.Label_Title_Drums = new System.Windows.Forms.Label();
            this.Label_Title_Guitar = new System.Windows.Forms.Label();
            this.Label_Title_Bass = new System.Windows.Forms.Label();
            this.Thread1 = new System.ComponentModel.BackgroundWorker();
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItem_Options = new System.Windows.Forms.ToolStripMenuItem();
            this.allInstrumentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_OnlinePlay = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_FullBand = new System.Windows.Forms.ToolStripMenuItem();
            this.vocalsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_GoldStar = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Harmonies = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Reload = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Info = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Min = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_LastReload = new System.Windows.Forms.ToolStripMenuItem();
            this.Label_Vocals1 = new System.Windows.Forms.Label();
            this.Label_Vocals2 = new System.Windows.Forms.Label();
            this.Label_Drums1 = new System.Windows.Forms.Label();
            this.Label_Guitar1 = new System.Windows.Forms.Label();
            this.Label_Bass1 = new System.Windows.Forms.Label();
            this.Label_Drums2 = new System.Windows.Forms.Label();
            this.Label_Guitar2 = new System.Windows.Forms.Label();
            this.Label_Bass2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.PictureBox_Spotlight = new System.Windows.Forms.PictureBox();
            this.MenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Spotlight)).BeginInit();
            this.SuspendLayout();
            // 
            // TextBox_Input
            // 
            this.TextBox_Input.BackColor = System.Drawing.Color.Black;
            this.TextBox_Input.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox_Input.ForeColor = System.Drawing.Color.White;
            this.TextBox_Input.Location = new System.Drawing.Point(85, 39);
            this.TextBox_Input.Margin = new System.Windows.Forms.Padding(4);
            this.TextBox_Input.Name = "TextBox_Input";
            this.TextBox_Input.Size = new System.Drawing.Size(374, 36);
            this.TextBox_Input.TabIndex = 0;
            this.TextBox_Input.TextChanged += new System.EventHandler(this.TextBox_Input_TextChanged);
            this.TextBox_Input.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_Input_KeyDown);
            // 
            // ListBox_SongSelect
            // 
            this.ListBox_SongSelect.BackColor = System.Drawing.Color.Black;
            this.ListBox_SongSelect.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ListBox_SongSelect.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListBox_SongSelect.ForeColor = System.Drawing.Color.White;
            this.ListBox_SongSelect.FormattingEnabled = true;
            this.ListBox_SongSelect.ItemHeight = 24;
            this.ListBox_SongSelect.Location = new System.Drawing.Point(85, 84);
            this.ListBox_SongSelect.Margin = new System.Windows.Forms.Padding(4);
            this.ListBox_SongSelect.Name = "ListBox_SongSelect";
            this.ListBox_SongSelect.Size = new System.Drawing.Size(374, 100);
            this.ListBox_SongSelect.TabIndex = 3;
            this.ListBox_SongSelect.SelectedIndexChanged += new System.EventHandler(this.ListBox_SongSelect_SelectedIndexChanged);
            // 
            // Label_Title_Search
            // 
            this.Label_Title_Search.BackColor = System.Drawing.Color.Transparent;
            this.Label_Title_Search.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Title_Search.ForeColor = System.Drawing.Color.White;
            this.Label_Title_Search.Location = new System.Drawing.Point(0, 39);
            this.Label_Title_Search.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_Title_Search.Name = "Label_Title_Search";
            this.Label_Title_Search.Size = new System.Drawing.Size(86, 36);
            this.Label_Title_Search.TabIndex = 16;
            this.Label_Title_Search.Text = "SEARCH";
            this.Label_Title_Search.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_Title_Select
            // 
            this.Label_Title_Select.BackColor = System.Drawing.Color.Transparent;
            this.Label_Title_Select.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Title_Select.ForeColor = System.Drawing.Color.White;
            this.Label_Title_Select.Location = new System.Drawing.Point(0, 84);
            this.Label_Title_Select.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_Title_Select.Name = "Label_Title_Select";
            this.Label_Title_Select.Size = new System.Drawing.Size(86, 100);
            this.Label_Title_Select.TabIndex = 17;
            this.Label_Title_Select.Text = "SELECT";
            this.Label_Title_Select.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_Message
            // 
            this.Label_Message.Font = new System.Drawing.Font("Bahnschrift Condensed", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Message.ForeColor = System.Drawing.Color.White;
            this.Label_Message.Location = new System.Drawing.Point(264, 100);
            this.Label_Message.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_Message.Name = "Label_Message";
            this.Label_Message.Size = new System.Drawing.Size(155, 72);
            this.Label_Message.TabIndex = 18;
            this.Label_Message.Text = "label3";
            this.Label_Message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Label_Message.Visible = false;
            // 
            // Label_Title_Vocals
            // 
            this.Label_Title_Vocals.BackColor = System.Drawing.Color.Transparent;
            this.Label_Title_Vocals.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Title_Vocals.ForeColor = System.Drawing.Color.White;
            this.Label_Title_Vocals.Location = new System.Drawing.Point(0, 191);
            this.Label_Title_Vocals.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_Title_Vocals.Name = "Label_Title_Vocals";
            this.Label_Title_Vocals.Size = new System.Drawing.Size(86, 94);
            this.Label_Title_Vocals.TabIndex = 23;
            this.Label_Title_Vocals.Text = "VOCALS";
            this.Label_Title_Vocals.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_Title_Drums
            // 
            this.Label_Title_Drums.BackColor = System.Drawing.Color.Transparent;
            this.Label_Title_Drums.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Title_Drums.ForeColor = System.Drawing.Color.White;
            this.Label_Title_Drums.Location = new System.Drawing.Point(0, 294);
            this.Label_Title_Drums.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_Title_Drums.Name = "Label_Title_Drums";
            this.Label_Title_Drums.Size = new System.Drawing.Size(86, 94);
            this.Label_Title_Drums.TabIndex = 24;
            this.Label_Title_Drums.Text = "DRUMS";
            this.Label_Title_Drums.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_Title_Guitar
            // 
            this.Label_Title_Guitar.BackColor = System.Drawing.Color.Transparent;
            this.Label_Title_Guitar.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Title_Guitar.ForeColor = System.Drawing.Color.White;
            this.Label_Title_Guitar.Location = new System.Drawing.Point(0, 396);
            this.Label_Title_Guitar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_Title_Guitar.Name = "Label_Title_Guitar";
            this.Label_Title_Guitar.Size = new System.Drawing.Size(86, 95);
            this.Label_Title_Guitar.TabIndex = 25;
            this.Label_Title_Guitar.Text = "GUITAR";
            this.Label_Title_Guitar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_Title_Bass
            // 
            this.Label_Title_Bass.BackColor = System.Drawing.Color.Transparent;
            this.Label_Title_Bass.Font = new System.Drawing.Font("Bahnschrift Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Title_Bass.ForeColor = System.Drawing.Color.White;
            this.Label_Title_Bass.Location = new System.Drawing.Point(0, 499);
            this.Label_Title_Bass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_Title_Bass.Name = "Label_Title_Bass";
            this.Label_Title_Bass.Size = new System.Drawing.Size(86, 94);
            this.Label_Title_Bass.TabIndex = 26;
            this.Label_Title_Bass.Text = "BASS";
            this.Label_Title_Bass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Thread1
            // 
            this.Thread1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Thread1_DoWork);
            this.Thread1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Thread1_RunWorkerCompleted);
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Options,
            this.ToolStripMenuItem_Reload,
            this.ToolStripMenuItem_Help,
            this.ToolStripMenuItem_Info,
            this.ToolStripMenuItem_Exit,
            this.ToolStripMenuItem_Min,
            this.ToolStripMenuItem_LastReload});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.MenuStrip1.Size = new System.Drawing.Size(1080, 29);
            this.MenuStrip1.TabIndex = 28;
            this.MenuStrip1.Text = "menuStrip1";
            this.MenuStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MenuStrip1_MouseDown);
            // 
            // ToolStripMenuItem_Options
            // 
            this.ToolStripMenuItem_Options.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolStripMenuItem_Options.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allInstrumentsToolStripMenuItem,
            this.vocalsToolStripMenuItem});
            this.ToolStripMenuItem_Options.Name = "ToolStripMenuItem_Options";
            this.ToolStripMenuItem_Options.Size = new System.Drawing.Size(71, 25);
            this.ToolStripMenuItem_Options.Text = "Options";
            // 
            // allInstrumentsToolStripMenuItem
            // 
            this.allInstrumentsToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.allInstrumentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_OnlinePlay,
            this.ToolStripMenuItem_FullBand});
            this.allInstrumentsToolStripMenuItem.Name = "allInstrumentsToolStripMenuItem";
            this.allInstrumentsToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.allInstrumentsToolStripMenuItem.Text = "All Instruments";
            // 
            // ToolStripMenuItem_OnlinePlay
            // 
            this.ToolStripMenuItem_OnlinePlay.CheckOnClick = true;
            this.ToolStripMenuItem_OnlinePlay.Name = "ToolStripMenuItem_OnlinePlay";
            this.ToolStripMenuItem_OnlinePlay.Size = new System.Drawing.Size(158, 26);
            this.ToolStripMenuItem_OnlinePlay.Text = "Online Play";
            this.ToolStripMenuItem_OnlinePlay.Click += new System.EventHandler(this.ToolStripMenuItem_OnlinePlay_Click);
            // 
            // ToolStripMenuItem_FullBand
            // 
            this.ToolStripMenuItem_FullBand.CheckOnClick = true;
            this.ToolStripMenuItem_FullBand.Name = "ToolStripMenuItem_FullBand";
            this.ToolStripMenuItem_FullBand.Size = new System.Drawing.Size(158, 26);
            this.ToolStripMenuItem_FullBand.Text = "Full Band";
            // 
            // vocalsToolStripMenuItem
            // 
            this.vocalsToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.vocalsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_GoldStar,
            this.ToolStripMenuItem_Harmonies});
            this.vocalsToolStripMenuItem.Name = "vocalsToolStripMenuItem";
            this.vocalsToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.vocalsToolStripMenuItem.Text = "Vocals";
            // 
            // ToolStripMenuItem_GoldStar
            // 
            this.ToolStripMenuItem_GoldStar.CheckOnClick = true;
            this.ToolStripMenuItem_GoldStar.Name = "ToolStripMenuItem_GoldStar";
            this.ToolStripMenuItem_GoldStar.Size = new System.Drawing.Size(177, 26);
            this.ToolStripMenuItem_GoldStar.Text = "Gold Star Only";
            this.ToolStripMenuItem_GoldStar.Click += new System.EventHandler(this.ToolStripMenuItem_GoldStar_Click);
            // 
            // ToolStripMenuItem_Harmonies
            // 
            this.ToolStripMenuItem_Harmonies.CheckOnClick = true;
            this.ToolStripMenuItem_Harmonies.Name = "ToolStripMenuItem_Harmonies";
            this.ToolStripMenuItem_Harmonies.Size = new System.Drawing.Size(177, 26);
            this.ToolStripMenuItem_Harmonies.Text = "Harmonies";
            // 
            // ToolStripMenuItem_Reload
            // 
            this.ToolStripMenuItem_Reload.Name = "ToolStripMenuItem_Reload";
            this.ToolStripMenuItem_Reload.Size = new System.Drawing.Size(77, 25);
            this.ToolStripMenuItem_Reload.Text = "Update...";
            this.ToolStripMenuItem_Reload.Click += new System.EventHandler(this.ToolStripMenuItem_Reload_Click);
            // 
            // ToolStripMenuItem_Help
            // 
            this.ToolStripMenuItem_Help.Name = "ToolStripMenuItem_Help";
            this.ToolStripMenuItem_Help.Size = new System.Drawing.Size(60, 25);
            this.ToolStripMenuItem_Help.Text = "Help...";
            this.ToolStripMenuItem_Help.Click += new System.EventHandler(this.ToolStripMenuItem_Help_Click);
            // 
            // ToolStripMenuItem_Info
            // 
            this.ToolStripMenuItem_Info.Name = "ToolStripMenuItem_Info";
            this.ToolStripMenuItem_Info.Size = new System.Drawing.Size(56, 25);
            this.ToolStripMenuItem_Info.Text = "Info...";
            this.ToolStripMenuItem_Info.Click += new System.EventHandler(this.ToolStripMenuItem_Info_Click);
            // 
            // ToolStripMenuItem_Exit
            // 
            this.ToolStripMenuItem_Exit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ToolStripMenuItem_Exit.Name = "ToolStripMenuItem_Exit";
            this.ToolStripMenuItem_Exit.Size = new System.Drawing.Size(49, 25);
            this.ToolStripMenuItem_Exit.Text = "EXIT";
            this.ToolStripMenuItem_Exit.Click += new System.EventHandler(this.ToolStripMenuItem_Exit_Click);
            // 
            // ToolStripMenuItem_Min
            // 
            this.ToolStripMenuItem_Min.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ToolStripMenuItem_Min.Name = "ToolStripMenuItem_Min";
            this.ToolStripMenuItem_Min.Size = new System.Drawing.Size(47, 25);
            this.ToolStripMenuItem_Min.Text = "MIN";
            this.ToolStripMenuItem_Min.Click += new System.EventHandler(this.ToolStripMenuItem_Min_Click);
            // 
            // ToolStripMenuItem_LastReload
            // 
            this.ToolStripMenuItem_LastReload.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ToolStripMenuItem_LastReload.Enabled = false;
            this.ToolStripMenuItem_LastReload.Name = "ToolStripMenuItem_LastReload";
            this.ToolStripMenuItem_LastReload.Size = new System.Drawing.Size(79, 25);
            this.ToolStripMenuItem_LastReload.Text = "Updated:";
            // 
            // Label_Vocals1
            // 
            this.Label_Vocals1.BackColor = System.Drawing.Color.Gold;
            this.Label_Vocals1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label_Vocals1.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Vocals1.Location = new System.Drawing.Point(85, 191);
            this.Label_Vocals1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_Vocals1.Name = "Label_Vocals1";
            this.Label_Vocals1.Size = new System.Drawing.Size(980, 43);
            this.Label_Vocals1.TabIndex = 31;
            this.Label_Vocals1.Text = "label9";
            this.Label_Vocals1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Vocals2
            // 
            this.Label_Vocals2.BackColor = System.Drawing.Color.Gold;
            this.Label_Vocals2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label_Vocals2.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Vocals2.Location = new System.Drawing.Point(85, 242);
            this.Label_Vocals2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_Vocals2.Name = "Label_Vocals2";
            this.Label_Vocals2.Size = new System.Drawing.Size(980, 43);
            this.Label_Vocals2.TabIndex = 32;
            this.Label_Vocals2.Text = "label10";
            this.Label_Vocals2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Drums1
            // 
            this.Label_Drums1.BackColor = System.Drawing.Color.Crimson;
            this.Label_Drums1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label_Drums1.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Drums1.Location = new System.Drawing.Point(85, 294);
            this.Label_Drums1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_Drums1.Name = "Label_Drums1";
            this.Label_Drums1.Size = new System.Drawing.Size(980, 43);
            this.Label_Drums1.TabIndex = 33;
            this.Label_Drums1.Text = "label11";
            this.Label_Drums1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Guitar1
            // 
            this.Label_Guitar1.BackColor = System.Drawing.Color.RoyalBlue;
            this.Label_Guitar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label_Guitar1.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Guitar1.Location = new System.Drawing.Point(85, 396);
            this.Label_Guitar1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_Guitar1.Name = "Label_Guitar1";
            this.Label_Guitar1.Size = new System.Drawing.Size(980, 43);
            this.Label_Guitar1.TabIndex = 34;
            this.Label_Guitar1.Text = "label12";
            this.Label_Guitar1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Bass1
            // 
            this.Label_Bass1.BackColor = System.Drawing.Color.LimeGreen;
            this.Label_Bass1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label_Bass1.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Bass1.Location = new System.Drawing.Point(85, 499);
            this.Label_Bass1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_Bass1.Name = "Label_Bass1";
            this.Label_Bass1.Size = new System.Drawing.Size(980, 43);
            this.Label_Bass1.TabIndex = 35;
            this.Label_Bass1.Text = "label13";
            this.Label_Bass1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Drums2
            // 
            this.Label_Drums2.BackColor = System.Drawing.Color.Crimson;
            this.Label_Drums2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label_Drums2.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Drums2.Location = new System.Drawing.Point(85, 345);
            this.Label_Drums2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_Drums2.Name = "Label_Drums2";
            this.Label_Drums2.Size = new System.Drawing.Size(980, 43);
            this.Label_Drums2.TabIndex = 36;
            this.Label_Drums2.Text = "label14";
            this.Label_Drums2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Guitar2
            // 
            this.Label_Guitar2.BackColor = System.Drawing.Color.RoyalBlue;
            this.Label_Guitar2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label_Guitar2.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Guitar2.Location = new System.Drawing.Point(85, 448);
            this.Label_Guitar2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_Guitar2.Name = "Label_Guitar2";
            this.Label_Guitar2.Size = new System.Drawing.Size(980, 43);
            this.Label_Guitar2.TabIndex = 37;
            this.Label_Guitar2.Text = "label15";
            this.Label_Guitar2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Bass2
            // 
            this.Label_Bass2.BackColor = System.Drawing.Color.LimeGreen;
            this.Label_Bass2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label_Bass2.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Bass2.Location = new System.Drawing.Point(85, 550);
            this.Label_Bass2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_Bass2.Name = "Label_Bass2";
            this.Label_Bass2.Size = new System.Drawing.Size(980, 43);
            this.Label_Bass2.TabIndex = 38;
            this.Label_Bass2.Text = "label16";
            this.Label_Bass2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(523, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(305, 133);
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.InitialImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(733, 116);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(332, 72);
            this.pictureBox2.TabIndex = 40;
            this.pictureBox2.TabStop = false;
            // 
            // PictureBox_Spotlight
            // 
            this.PictureBox_Spotlight.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox_Spotlight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PictureBox_Spotlight.BackgroundImage")));
            this.PictureBox_Spotlight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PictureBox_Spotlight.Location = new System.Drawing.Point(466, 134);
            this.PictureBox_Spotlight.Name = "PictureBox_Spotlight";
            this.PictureBox_Spotlight.Size = new System.Drawing.Size(50, 50);
            this.PictureBox_Spotlight.TabIndex = 41;
            this.PictureBox_Spotlight.TabStop = false;
            this.PictureBox_Spotlight.Visible = false;
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1080, 608);
            this.Controls.Add(this.PictureBox_Spotlight);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.Label_Bass2);
            this.Controls.Add(this.Label_Guitar2);
            this.Controls.Add(this.Label_Drums2);
            this.Controls.Add(this.Label_Bass1);
            this.Controls.Add(this.Label_Guitar1);
            this.Controls.Add(this.Label_Drums1);
            this.Controls.Add(this.Label_Vocals2);
            this.Controls.Add(this.Label_Vocals1);
            this.Controls.Add(this.Label_Title_Bass);
            this.Controls.Add(this.Label_Title_Guitar);
            this.Controls.Add(this.Label_Title_Drums);
            this.Controls.Add(this.Label_Title_Vocals);
            this.Controls.Add(this.Label_Message);
            this.Controls.Add(this.Label_Title_Select);
            this.Controls.Add(this.Label_Title_Search);
            this.Controls.Add(this.ListBox_SongSelect);
            this.Controls.Add(this.TextBox_Input);
            this.Controls.Add(this.MenuStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rock Band 4 - Path Vault";
            this.Shown += new System.EventHandler(this.Form_Main_Shown);
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Spotlight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBox_Input;
        private System.Windows.Forms.ListBox ListBox_SongSelect;
        private System.Windows.Forms.Label Label_Title_Search;
        private System.Windows.Forms.Label Label_Title_Select;
        private System.Windows.Forms.Label Label_Message;
        private System.Windows.Forms.Label Label_Title_Vocals;
        private System.Windows.Forms.Label Label_Title_Drums;
        private System.Windows.Forms.Label Label_Title_Guitar;
        private System.Windows.Forms.Label Label_Title_Bass;
        private System.ComponentModel.BackgroundWorker Thread1;
        private System.Windows.Forms.MenuStrip MenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Help;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Info;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Exit;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Reload;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Options;
        private System.Windows.Forms.Label Label_Vocals1;
        private System.Windows.Forms.Label Label_Vocals2;
        private System.Windows.Forms.Label Label_Drums1;
        private System.Windows.Forms.Label Label_Guitar1;
        private System.Windows.Forms.Label Label_Bass1;
        private System.Windows.Forms.Label Label_Drums2;
        private System.Windows.Forms.Label Label_Guitar2;
        private System.Windows.Forms.Label Label_Bass2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_LastReload;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Min;
        private System.Windows.Forms.ToolStripMenuItem allInstrumentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_OnlinePlay;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_FullBand;
        private System.Windows.Forms.ToolStripMenuItem vocalsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_GoldStar;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Harmonies;
        private System.Windows.Forms.PictureBox PictureBox_Spotlight;
    }
}

