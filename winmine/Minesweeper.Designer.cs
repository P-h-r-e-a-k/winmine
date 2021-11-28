
namespace winmine
{
    partial class Minesweeper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Minesweeper));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.BeginnerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.intermediateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.highscoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbTop = new System.Windows.Forms.GroupBox();
            this.Time = new ThreeDigitDisplay.ThreeDigitDisplay();
            this.Mines = new ThreeDigitDisplay.ThreeDigitDisplay();
            this.btnSmile = new System.Windows.Forms.Button();
            this.gbMain = new System.Windows.Forms.GroupBox();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.gbTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(549, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.highscoresToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "&Game";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BeginnerToolStripMenuItem,
            this.intermediateToolStripMenuItem,
            this.expertToolStripMenuItem,
            this.customToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "&Difficulty";
            // 
            // BeginnerToolStripMenuItem
            // 
            this.BeginnerToolStripMenuItem.CheckOnClick = true;
            this.BeginnerToolStripMenuItem.Name = "BeginnerToolStripMenuItem";
            this.BeginnerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.BeginnerToolStripMenuItem.Text = "&Beginner";
            this.BeginnerToolStripMenuItem.Click += new System.EventHandler(this.BeginnerToolStripMenuItem_Click);
            // 
            // intermediateToolStripMenuItem
            // 
            this.intermediateToolStripMenuItem.CheckOnClick = true;
            this.intermediateToolStripMenuItem.Name = "intermediateToolStripMenuItem";
            this.intermediateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.intermediateToolStripMenuItem.Text = "&Intermediate";
            this.intermediateToolStripMenuItem.Click += new System.EventHandler(this.intermediateToolStripMenuItem_Click);
            // 
            // expertToolStripMenuItem
            // 
            this.expertToolStripMenuItem.CheckOnClick = true;
            this.expertToolStripMenuItem.Name = "expertToolStripMenuItem";
            this.expertToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.expertToolStripMenuItem.Text = "&Expert";
            this.expertToolStripMenuItem.Click += new System.EventHandler(this.expertToolStripMenuItem_Click);
            // 
            // customToolStripMenuItem
            // 
            this.customToolStripMenuItem.CheckOnClick = true;
            this.customToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem1});
            this.customToolStripMenuItem.Name = "customToolStripMenuItem";
            this.customToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.customToolStripMenuItem.Text = "&Custom";
            this.customToolStripMenuItem.Click += new System.EventHandler(this.customToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem1
            // 
            this.settingsToolStripMenuItem1.Name = "settingsToolStripMenuItem1";
            this.settingsToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.settingsToolStripMenuItem1.Text = "&Settings";
            this.settingsToolStripMenuItem1.Click += new System.EventHandler(this.settingsToolStripMenuItem1_Click);
            // 
            // highscoresToolStripMenuItem
            // 
            this.highscoresToolStripMenuItem.Name = "highscoresToolStripMenuItem";
            this.highscoresToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.highscoresToolStripMenuItem.Text = "&Highscores";
            this.highscoresToolStripMenuItem.Click += new System.EventHandler(this.highscoresToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // gbTop
            // 
            this.gbTop.Controls.Add(this.Time);
            this.gbTop.Controls.Add(this.Mines);
            this.gbTop.Controls.Add(this.btnSmile);
            this.gbTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbTop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbTop.Location = new System.Drawing.Point(0, 24);
            this.gbTop.Name = "gbTop";
            this.gbTop.Size = new System.Drawing.Size(549, 38);
            this.gbTop.TabIndex = 4;
            this.gbTop.TabStop = false;
            // 
            // Time
            // 
            this.Time.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Time.Location = new System.Drawing.Point(494, 3);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(55, 35);
            this.Time.TabIndex = 6;
            // 
            // Mines
            // 
            this.Mines.Location = new System.Drawing.Point(6, 3);
            this.Mines.Name = "Mines";
            this.Mines.Size = new System.Drawing.Size(55, 35);
            this.Mines.TabIndex = 5;
            // 
            // btnSmile
            // 
            this.btnSmile.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSmile.BackColor = System.Drawing.SystemColors.Control;
            this.btnSmile.ForeColor = System.Drawing.Color.Gold;
            this.btnSmile.Location = new System.Drawing.Point(257, 8);
            this.btnSmile.Name = "btnSmile";
            this.btnSmile.Size = new System.Drawing.Size(34, 28);
            this.btnSmile.TabIndex = 4;
            this.btnSmile.UseVisualStyleBackColor = true;
            this.btnSmile.Click += new System.EventHandler(this.btnSmile_Click);
            this.btnSmile.Paint += new System.Windows.Forms.PaintEventHandler(this.btnSmile_Paint);
            // 
            // gbMain
            // 
            this.gbMain.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbMain.Location = new System.Drawing.Point(7, 68);
            this.gbMain.Margin = new System.Windows.Forms.Padding(0);
            this.gbMain.Name = "gbMain";
            this.gbMain.Size = new System.Drawing.Size(535, 349);
            this.gbMain.TabIndex = 5;
            this.gbMain.TabStop = false;
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // Minesweeper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 424);
            this.Controls.Add(this.gbMain);
            this.Controls.Add(this.gbTop);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Minesweeper";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Minesweeper";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbTop.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbTop;
        private System.Windows.Forms.Button btnSmile;
        private System.Windows.Forms.GroupBox gbMain;
        private ThreeDigitDisplay.ThreeDigitDisplay Time;
        private ThreeDigitDisplay.ThreeDigitDisplay Mines;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem BeginnerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem intermediateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem highscoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

