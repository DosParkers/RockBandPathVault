namespace Rock_Band_4_Path_Vault
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Label_Message = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Thread1 = new System.ComponentModel.BackgroundWorker();
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItem_Options = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripItem_OnlinePlay = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Reload = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_About = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Label_Vocals1 = new System.Windows.Forms.Label();
            this.Label_Vocals2 = new System.Windows.Forms.Label();
            this.Label_Drums1 = new System.Windows.Forms.Label();
            this.Label_Guitar1 = new System.Windows.Forms.Label();
            this.Label_Bass1 = new System.Windows.Forms.Label();
            this.Label_Drums2 = new System.Windows.Forms.Label();
            this.Label_Guitar2 = new System.Windows.Forms.Label();
            this.Label_Bass2 = new System.Windows.Forms.Label();
            this.MenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextBox_Input
            // 
            this.TextBox_Input.BackColor = System.Drawing.Color.Black;
            this.TextBox_Input.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox_Input.ForeColor = System.Drawing.Color.White;
            this.TextBox_Input.Location = new System.Drawing.Point(68, 31);
            this.TextBox_Input.Name = "TextBox_Input";
            this.TextBox_Input.Size = new System.Drawing.Size(300, 30);
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
            this.ListBox_SongSelect.ItemHeight = 19;
            this.ListBox_SongSelect.Location = new System.Drawing.Point(68, 67);
            this.ListBox_SongSelect.Name = "ListBox_SongSelect";
            this.ListBox_SongSelect.ScrollAlwaysVisible = true;
            this.ListBox_SongSelect.Size = new System.Drawing.Size(300, 80);
            this.ListBox_SongSelect.TabIndex = 3;
            this.ListBox_SongSelect.SelectedIndexChanged += new System.EventHandler(this.ListBox_SongSelect_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 38);
            this.label1.TabIndex = 16;
            this.label1.Text = "SONG\r\nSEARCH";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Bahnschrift Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(8, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 46);
            this.label2.TabIndex = 17;
            this.label2.Text = "SONG\r\nSELECT";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_Message
            // 
            this.Label_Message.Font = new System.Drawing.Font("Bahnschrift Condensed", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Message.ForeColor = System.Drawing.Color.White;
            this.Label_Message.Location = new System.Drawing.Point(211, 80);
            this.Label_Message.Name = "Label_Message";
            this.Label_Message.Size = new System.Drawing.Size(124, 58);
            this.Label_Message.TabIndex = 18;
            this.Label_Message.Text = "label3";
            this.Label_Message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Label_Message.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(5, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 23);
            this.label3.TabIndex = 23;
            this.label3.Text = "VOCALS";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(8, 261);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 23);
            this.label4.TabIndex = 24;
            this.label4.Text = "DRUMS";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(8, 341);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 23);
            this.label5.TabIndex = 25;
            this.label5.Text = "GUITAR";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(20, 423);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 23);
            this.label6.TabIndex = 26;
            this.label6.Text = "BASS";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.ToolStripMenuItem_About,
            this.ToolStripMenuItem_Exit});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Size = new System.Drawing.Size(864, 24);
            this.MenuStrip1.TabIndex = 28;
            this.MenuStrip1.Text = "menuStrip1";
            this.MenuStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MenuStrip1_MouseDown);
            // 
            // ToolStripMenuItem_Options
            // 
            this.ToolStripMenuItem_Options.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripItem_OnlinePlay});
            this.ToolStripMenuItem_Options.Name = "ToolStripMenuItem_Options";
            this.ToolStripMenuItem_Options.Size = new System.Drawing.Size(58, 20);
            this.ToolStripMenuItem_Options.Text = "Options";
            // 
            // ToolStripItem_OnlinePlay
            // 
            this.ToolStripItem_OnlinePlay.CheckOnClick = true;
            this.ToolStripItem_OnlinePlay.Name = "ToolStripItem_OnlinePlay";
            this.ToolStripItem_OnlinePlay.Size = new System.Drawing.Size(131, 22);
            this.ToolStripItem_OnlinePlay.Text = "Online Play";
            this.ToolStripItem_OnlinePlay.Click += new System.EventHandler(this.ToolStripItem_OnlinePlay_Click);
            // 
            // ToolStripMenuItem_Reload
            // 
            this.ToolStripMenuItem_Reload.Name = "ToolStripMenuItem_Reload";
            this.ToolStripMenuItem_Reload.Size = new System.Drawing.Size(63, 20);
            this.ToolStripMenuItem_Reload.Text = "Reload...";
            this.ToolStripMenuItem_Reload.Click += new System.EventHandler(this.ToolStripMenuItem_Reload_Click);
            // 
            // ToolStripMenuItem_Help
            // 
            this.ToolStripMenuItem_Help.Name = "ToolStripMenuItem_Help";
            this.ToolStripMenuItem_Help.Size = new System.Drawing.Size(51, 20);
            this.ToolStripMenuItem_Help.Text = "Help...";
            this.ToolStripMenuItem_Help.Click += new System.EventHandler(this.ToolStripMenuItem_Help_Click);
            // 
            // ToolStripMenuItem_About
            // 
            this.ToolStripMenuItem_About.Name = "ToolStripMenuItem_About";
            this.ToolStripMenuItem_About.Size = new System.Drawing.Size(48, 20);
            this.ToolStripMenuItem_About.Text = "Info...";
            this.ToolStripMenuItem_About.Click += new System.EventHandler(this.ToolStripMenuItem_About_Click);
            // 
            // ToolStripMenuItem_Exit
            // 
            this.ToolStripMenuItem_Exit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ToolStripMenuItem_Exit.Name = "ToolStripMenuItem_Exit";
            this.ToolStripMenuItem_Exit.Size = new System.Drawing.Size(39, 20);
            this.ToolStripMenuItem_Exit.Text = "Exit";
            this.ToolStripMenuItem_Exit.Click += new System.EventHandler(this.ToolStripMenuItem_Exit_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Impact", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Location = new System.Drawing.Point(475, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(264, 60);
            this.label7.TabIndex = 29;
            this.label7.Text = "Rock Band 4";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label8.Location = new System.Drawing.Point(502, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(211, 58);
            this.label8.TabIndex = 30;
            this.label8.Text = "Path Vault";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_Vocals1
            // 
            this.Label_Vocals1.BackColor = System.Drawing.Color.Gold;
            this.Label_Vocals1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label_Vocals1.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Vocals1.Location = new System.Drawing.Point(68, 153);
            this.Label_Vocals1.Name = "Label_Vocals1";
            this.Label_Vocals1.Size = new System.Drawing.Size(784, 35);
            this.Label_Vocals1.TabIndex = 31;
            this.Label_Vocals1.Text = "label9";
            this.Label_Vocals1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Vocals2
            // 
            this.Label_Vocals2.BackColor = System.Drawing.Color.Gold;
            this.Label_Vocals2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label_Vocals2.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Vocals2.Location = new System.Drawing.Point(68, 194);
            this.Label_Vocals2.Name = "Label_Vocals2";
            this.Label_Vocals2.Size = new System.Drawing.Size(784, 35);
            this.Label_Vocals2.TabIndex = 32;
            this.Label_Vocals2.Text = "label10";
            this.Label_Vocals2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Drums1
            // 
            this.Label_Drums1.BackColor = System.Drawing.Color.Crimson;
            this.Label_Drums1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label_Drums1.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Drums1.Location = new System.Drawing.Point(68, 235);
            this.Label_Drums1.Name = "Label_Drums1";
            this.Label_Drums1.Size = new System.Drawing.Size(784, 35);
            this.Label_Drums1.TabIndex = 33;
            this.Label_Drums1.Text = "label11";
            this.Label_Drums1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Guitar1
            // 
            this.Label_Guitar1.BackColor = System.Drawing.Color.RoyalBlue;
            this.Label_Guitar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label_Guitar1.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Guitar1.Location = new System.Drawing.Point(68, 317);
            this.Label_Guitar1.Name = "Label_Guitar1";
            this.Label_Guitar1.Size = new System.Drawing.Size(784, 35);
            this.Label_Guitar1.TabIndex = 34;
            this.Label_Guitar1.Text = "label12";
            this.Label_Guitar1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Bass1
            // 
            this.Label_Bass1.BackColor = System.Drawing.Color.LimeGreen;
            this.Label_Bass1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label_Bass1.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Bass1.Location = new System.Drawing.Point(68, 399);
            this.Label_Bass1.Name = "Label_Bass1";
            this.Label_Bass1.Size = new System.Drawing.Size(784, 35);
            this.Label_Bass1.TabIndex = 35;
            this.Label_Bass1.Text = "label13";
            this.Label_Bass1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Drums2
            // 
            this.Label_Drums2.BackColor = System.Drawing.Color.Crimson;
            this.Label_Drums2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label_Drums2.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Drums2.Location = new System.Drawing.Point(68, 276);
            this.Label_Drums2.Name = "Label_Drums2";
            this.Label_Drums2.Size = new System.Drawing.Size(784, 35);
            this.Label_Drums2.TabIndex = 36;
            this.Label_Drums2.Text = "label14";
            this.Label_Drums2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Guitar2
            // 
            this.Label_Guitar2.BackColor = System.Drawing.Color.RoyalBlue;
            this.Label_Guitar2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label_Guitar2.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Guitar2.Location = new System.Drawing.Point(68, 358);
            this.Label_Guitar2.Name = "Label_Guitar2";
            this.Label_Guitar2.Size = new System.Drawing.Size(784, 35);
            this.Label_Guitar2.TabIndex = 37;
            this.Label_Guitar2.Text = "label15";
            this.Label_Guitar2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Bass2
            // 
            this.Label_Bass2.BackColor = System.Drawing.Color.LimeGreen;
            this.Label_Bass2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label_Bass2.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Bass2.Location = new System.Drawing.Point(68, 440);
            this.Label_Bass2.Name = "Label_Bass2";
            this.Label_Bass2.Size = new System.Drawing.Size(784, 35);
            this.Label_Bass2.TabIndex = 38;
            this.Label_Bass2.Text = "label16";
            this.Label_Bass2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(864, 486);
            this.Controls.Add(this.Label_Bass2);
            this.Controls.Add(this.Label_Guitar2);
            this.Controls.Add(this.Label_Drums2);
            this.Controls.Add(this.Label_Bass1);
            this.Controls.Add(this.Label_Guitar1);
            this.Controls.Add(this.Label_Drums1);
            this.Controls.Add(this.Label_Vocals2);
            this.Controls.Add(this.Label_Vocals1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Label_Message);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ListBox_SongSelect);
            this.Controls.Add(this.TextBox_Input);
            this.Controls.Add(this.MenuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip1;
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rock Band 4 - Path Vault";
            this.Shown += new System.EventHandler(this.Form_Main_Shown);
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBox_Input;
        private System.Windows.Forms.ListBox ListBox_SongSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Label_Message;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.ComponentModel.BackgroundWorker Thread1;
        private System.Windows.Forms.MenuStrip MenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Help;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_About;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Exit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Reload;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Options;
        private System.Windows.Forms.ToolStripMenuItem ToolStripItem_OnlinePlay;
        private System.Windows.Forms.Label Label_Vocals1;
        private System.Windows.Forms.Label Label_Vocals2;
        private System.Windows.Forms.Label Label_Drums1;
        private System.Windows.Forms.Label Label_Guitar1;
        private System.Windows.Forms.Label Label_Bass1;
        private System.Windows.Forms.Label Label_Drums2;
        private System.Windows.Forms.Label Label_Guitar2;
        private System.Windows.Forms.Label Label_Bass2;
    }
}

