using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace winmine
{
    public partial class Form1 : Form
    {
        const byte rowSize = 9;
        const byte columnSize = 9;
        const byte buttonSizePX = 20;
        ushort NumOfMines = 10;
        Dictionary<int, ushort> ButtonNum = new Dictionary<int, ushort>();
        Button[] Grid;
        public Form1()
        {
            InitializeComponent();
            this.Width = (rowSize * buttonSizePX) + 30;
            this.Height = (columnSize * buttonSizePX) + gbTop.Height + 50 + menuStrip1.Height;
            btnSmile_Click(null, null);
        }

        private void btnSmile_Click(object sender, EventArgs e)
        {
            Grid = new Button[rowSize * columnSize];
            for (ushort i = 0; i < Grid.Length; i++)
            {
                Grid[i] = new Button();
                Grid[i].Width = buttonSizePX;
                Grid[i].Height = buttonSizePX;
                Grid[i].Padding = new Padding(0);
                Grid[i].MouseDown += btnMine_MouseDown;
                Grid[i].MouseUp += btnMine_MouseUp;
                ButtonNum.Add(Grid[i].GetHashCode(), i);
                //Grid[i].Text = i.ToString();
            }

            gbMain.Width = buttonSizePX * rowSize;
            gbMain.Height = buttonSizePX * columnSize;

            for (int c = 0, x = 0; c < columnSize; c++)
            {
                for (int w = 0; w < rowSize; w++, x++)
                {
                    Button b = Grid[x];
                    gbMain.Controls.Add(b);
                    b.Location = new Point(buttonSizePX * w, buttonSizePX * c);
                    b.Click += btnMine_Click;
                }
            }
            Mines.SetNumber(NumOfMines);
            Time.SetNumber(0);
        }

        Point Button;
        private void btnMine_MouseDown(object sender, EventArgs e)
        {
            MouseEventArgs args = (MouseEventArgs)e;
            if (args.Button != MouseButtons.Right) return;
            Button = args.Location;
        }

        private void btnMine_MouseUp(object sender, EventArgs e)
        {
            if (((MouseEventArgs)e).Button != MouseButtons.Right) return;
            if (Button == ((MouseEventArgs)e).Location)
                btnMineRight_Click(sender, e);
            Button = Point.Empty;
        }
        private void btnMine_Click(object sender, EventArgs e)
        {
            List<ushort> AdjacentSquares = new List<ushort>();
            ushort index = ButtonNum[sender.GetHashCode()];
            bool above = HasRowAbove(index);
            bool left = HasColumnLeft(index);
            bool right = HasColumnRight(index);
            bool below = HasRowBelow(index);
            ushort AboveSquare = 0;
            ushort BelowSquare = 0;

            if (above)
                AdjacentSquares.Add(AboveSquare = (ushort)(index - rowSize));
            if(left) 
                AdjacentSquares.Add((ushort)(index -1 ));
            if (right)
                AdjacentSquares.Add((ushort)(index + 1));
            if (below)
                AdjacentSquares.Add(BelowSquare = (ushort)(index + rowSize));
            if (above && left)
                AdjacentSquares.Add((ushort)(AboveSquare - 1));
            if (above && right)
                AdjacentSquares.Add((ushort)(AboveSquare + 1));
            if (below && left)
                AdjacentSquares.Add((ushort)(BelowSquare - 1));
            if (below && right)
                AdjacentSquares.Add((ushort)(BelowSquare + 1));
            string res = "The adjacent squares are: ";
            for (int i = 0; i < AdjacentSquares.Count; i++)
                res += AdjacentSquares[i] + ", ";
            MessageBox.Show(res);
        }

        private bool HasRowAbove(ushort index)
        {
                return index - (rowSize - 1) > 0;            
        }

        private bool HasColumnLeft(ushort index)
        {
            return 0 != index % rowSize;
        }

        private bool HasColumnRight(ushort index)
        {
            return 0 != (index+1) % rowSize;
        }

        private bool HasRowBelow(ushort index)
        {
            return index + rowSize + 1 <= rowSize * columnSize;
        }

        private void btnMineRight_Click(object sender, EventArgs e)
        {
            ushort index = ButtonNum[sender.GetHashCode()];
            MouseEventArgs args = (MouseEventArgs)e;
            if (args.Button != MouseButtons.Right) return;
            Button b = (Button)sender;
            if (b.BackgroundImage == null)
            {

                string path = getBasePath() + "\\flag.png";
                Image flag = Image.FromFile(path);

                b.BackgroundImage = flag;
                b.BackgroundImageLayout = ImageLayout.Stretch;
                b.FlatStyle = FlatStyle.Flat;
                b.ImageAlign = ContentAlignment.MiddleCenter;
                b.Refresh();
                UpdateMines(NumOfMines--);
            }
            else
            {
                b.BackgroundImage = null;
                b.FlatStyle = FlatStyle.System;
            }

        }

        private void UpdateMines(ushort n)
        {
            Mines.SetNumber(n);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("gbMainWidth: "+ gbMain.Width.ToString());
            MessageBox.Show("Form1.Width: " + this.Width);

            MessageBox.Show(getBasePath());
        }


        private string getBasePath()
        {
            return new Uri(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)).LocalPath;
        }
    }
}
