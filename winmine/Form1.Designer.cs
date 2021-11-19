
namespace winmine
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.gbTop = new System.Windows.Forms.GroupBox();
            this.Time = new ThreeDigitDisplay.ThreeDigitDisplay();
            this.Mines = new ThreeDigitDisplay.ThreeDigitDisplay();
            this.btnSmile = new System.Windows.Forms.Button();
            this.gbMain = new System.Windows.Forms.GroupBox();
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
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "&Game";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
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
            this.btnSmile.BackColor = System.Drawing.Color.DarkGray;
            this.btnSmile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSmile.ForeColor = System.Drawing.Color.Yellow;
            this.btnSmile.Location = new System.Drawing.Point(257, 11);
            this.btnSmile.Name = "btnSmile";
            this.btnSmile.Size = new System.Drawing.Size(34, 23);
            this.btnSmile.TabIndex = 4;
            this.btnSmile.Text = "🙂";
            this.btnSmile.UseVisualStyleBackColor = false;
            this.btnSmile.Click += new System.EventHandler(this.btnSmile_Click);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 424);
            this.Controls.Add(this.gbMain);
            this.Controls.Add(this.gbTop);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
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
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.GroupBox gbTop;
        private System.Windows.Forms.Button btnSmile;
        private System.Windows.Forms.GroupBox gbMain;
        private ThreeDigitDisplay.ThreeDigitDisplay Time;
        private ThreeDigitDisplay.ThreeDigitDisplay Mines;
    }
}

