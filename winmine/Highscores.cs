using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winmine
{
    public partial class Highscores : Form
    {
        public Settings settings;
        public Highscores()
        {
            InitializeComponent();
            foreach(string name in Enum.GetNames(typeof(Settings.Difficulty)))
            {
                cboDifficulty.Items.Add(name);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void populateScores(List<Score> scores)
        {
            List<Label> labels = new List<Label>();
            foreach (Label lbl in gbScores.Controls.OfType<Label>())
            {
                labels.Add(lbl);
            }

            for(int i = 0; i < labels.Count; i++)
            {
                gbScores.Controls.Remove(labels[i]);
                labels[i].Dispose();
            }
            Point location = new Point(6, 16);
            Point scoreLocation = new Point(172, location.Y);
            for(int i = 0; i < scores.Count;i++)
            {
                Label name = new Label();
                Label score = new Label();

                int YPos = location.Y + (i * name.Height);

                name.Location = new Point(location.X, YPos);
                name.Text = (i + 1).ToString().PadLeft(2) + ": " + scores[i].Name;

                score.Location = new Point(scoreLocation.X, YPos);
                score.Text = scores[i].Time.ToString().PadLeft(3);
                score.Width = 25;

                gbScores.Controls.Add(name);
                gbScores.Controls.Add(score);
            }
            gbScores.Refresh();
        }

        private List<Score> getSelectedScores()
        {
            if (0 == cboDifficulty.SelectedIndex)
                return settings.Easy;

            if (1 == cboDifficulty.SelectedIndex)
                return settings.Medium;

            if (2 == cboDifficulty.SelectedIndex)
                return settings.Hard;

            return settings.Custom;
        }

        private void cboDifficulty_SelectedIndexChanged(object sender, EventArgs e)
        {
             populateScores(getSelectedScores());
        }

        private void Highscores_Load(object sender, EventArgs e)
        {
            if (settings.difficulty == Settings.Difficulty.Beginner)
            {
                cboDifficulty.SelectedIndex = 0;
                return;
            }
            if (settings.difficulty == Settings.Difficulty.Intermediate)
            {
                cboDifficulty.SelectedIndex = 1;
                return;
            }
            if (settings.difficulty == Settings.Difficulty.Expert)
            {
                cboDifficulty.SelectedIndex = 2;
                return;
            }
            if (settings.difficulty == Settings.Difficulty.Custom)
            {
                cboDifficulty.SelectedIndex = 3;
                return;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult =
                MessageBox.Show
                (
                    this, "Warning this will reset all the scores for this difficulty are you sure?",
                    "Warning",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.None,
                    MessageBoxDefaultButton.Button2
                );
            if(dialogResult == DialogResult.Yes)
            {
                List<Score> scores = getSelectedScores();
                scores.Clear();
                for(int i = 0; i < 10; i++)
                    scores.Add(new Score("Anonymous", 999));
                settings.Save();
                populateScores(scores);
            }
        }
    }

}
