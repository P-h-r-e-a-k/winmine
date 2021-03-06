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
    public partial class InputName : Form
    {
        public ushort Time;
        public string Name;
        public InputName()
        {
            InitializeComponent();
        }

        private void InputName_Load(object sender, EventArgs e)
        {
            lblCongratulations.Text = "Congratulations you got a new top ten time of " + Time.ToString() + " seconds. Please enter your name.";
            btnOkay.Select();
            txtName.SelectAll();
            txtName.Select();
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
                Name = "Anoymous";
            else
                Name = txtName.Text;
            this.Close();
        }

    }
}
