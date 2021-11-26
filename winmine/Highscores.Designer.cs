
namespace winmine
{
    partial class Highscores
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
            this.gbOuter = new System.Windows.Forms.GroupBox();
            this.gbScores = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblDifficulty = new System.Windows.Forms.Label();
            this.cboDifficulty = new System.Windows.Forms.ComboBox();
            this.gbOuter.SuspendLayout();
            this.gbScores.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbOuter
            // 
            this.gbOuter.Controls.Add(this.gbScores);
            this.gbOuter.Controls.Add(this.lblDifficulty);
            this.gbOuter.Controls.Add(this.cboDifficulty);
            this.gbOuter.Location = new System.Drawing.Point(12, 12);
            this.gbOuter.Name = "gbOuter";
            this.gbOuter.Size = new System.Drawing.Size(222, 329);
            this.gbOuter.TabIndex = 0;
            this.gbOuter.TabStop = false;
            // 
            // gbScores
            // 
            this.gbScores.Controls.Add(this.btnClose);
            this.gbScores.Controls.Add(this.btnReset);
            this.gbScores.Location = new System.Drawing.Point(6, 46);
            this.gbScores.Name = "gbScores";
            this.gbScores.Size = new System.Drawing.Size(207, 277);
            this.gbScores.TabIndex = 2;
            this.gbScores.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(116, 248);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(7, 248);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(103, 23);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "Reset Scores";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblDifficulty
            // 
            this.lblDifficulty.AutoSize = true;
            this.lblDifficulty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDifficulty.Location = new System.Drawing.Point(6, 22);
            this.lblDifficulty.Name = "lblDifficulty";
            this.lblDifficulty.Size = new System.Drawing.Size(57, 13);
            this.lblDifficulty.TabIndex = 1;
            this.lblDifficulty.Text = "Difficulty";
            // 
            // cboDifficulty
            // 
            this.cboDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDifficulty.FormattingEnabled = true;
            this.cboDifficulty.Location = new System.Drawing.Point(76, 19);
            this.cboDifficulty.Name = "cboDifficulty";
            this.cboDifficulty.Size = new System.Drawing.Size(129, 21);
            this.cboDifficulty.TabIndex = 0;
            this.cboDifficulty.SelectedIndexChanged += new System.EventHandler(this.cboDifficulty_SelectedIndexChanged);
            // 
            // Highscores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(243, 353);
            this.Controls.Add(this.gbOuter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Highscores";
            this.Text = "Highscores";
            this.Load += new System.EventHandler(this.Highscores_Load);
            this.gbOuter.ResumeLayout(false);
            this.gbOuter.PerformLayout();
            this.gbScores.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbOuter;
        private System.Windows.Forms.Label lblDifficulty;
        private System.Windows.Forms.ComboBox cboDifficulty;
        private System.Windows.Forms.GroupBox gbScores;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnReset;
    }
}