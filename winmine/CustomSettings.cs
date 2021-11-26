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

    public partial class CustomSettings : Form
    {
        public Settings settings;
        public CustomSettings()
        {
            InitializeComponent();
        }

        private void CustomSettings_Load(object sender, EventArgs e)
        {
            txtWidth.Text = settings.Width.ToString();
            txtHeight.Text = settings.Height.ToString();
            txtBombs.Text = settings.Bombs.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            try
            {
                settings.Width = ushort.Parse(txtWidth.Text);
                settings.Height = ushort.Parse(txtHeight.Text);
                settings.Bombs = ushort.Parse(txtBombs.Text);
                settings.Save();

                List<Score> scores = settings.Custom;
                scores.Clear();
                for (int i = 0; i < 10; i++)
                    scores.Add(new Score("Anonymous", 999));
            }
            catch
            {
            }
            this.Close();
        }
    }
}
