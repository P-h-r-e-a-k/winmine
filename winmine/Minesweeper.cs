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
using IniParser;
using IniParser.Model;
using System.Windows.Input;

namespace winmine
{
    public partial class Minesweeper : Form
    {
        Settings settings;
        Game game = new Game();
        byte buttonSizePX = 20;
        Image Flag;
        Image Bomb;
        Image Chan;
        Button[] Grid;
        byte NumberOfFlags;
        Board beginnerBoard = new Board(9, 9, 10);
        Board intermediateBoard = new Board(16, 16, 40);
        Board expertBoard = new Board(30, 16, 99);
        Board customBoard;
        Board CurrentBoard;
        Color One = Color.Blue;
        Color Two = Color.Green;
        Color Three = Color.Red;
        Color Four = Color.Navy;
        Color Five = Color.Maroon;
        Color Six = Color.SkyBlue;
        Color Seven = Color.Purple;
        Color Eight = Color.Black;
        Color RevealedBackColour = Color.Gainsboro;
        Color ButtonBackColour = Color.LightGray;

        bool FirstClick;
        bool IsGameover;

        System.Windows.Forms.Timer t;

        public Minesweeper()
        {
            InitializeComponent();
            Flag = Image.FromFile(getBasePath() + "\\flag.png");
            Bomb = Image.FromFile(getBasePath() + "\\Bomb.png");
            Chan = Properties.Resources.chan;
            LoadSettings();
            btnSmile_Click(null, null);
        }

        ushort NumOfSeconds;
        private void SetupTimer()
        {
            if (null != t)
            {
                t.Enabled = false;
                t.Dispose();
            }
            NumOfSeconds = 0;
            t = new System.Windows.Forms.Timer();
            t.Interval = 1000;
            t.Tick += t_Tick;
            Time.SetNumber(0);
        }

        private void t_Tick(object sender, EventArgs e)
        {
            Time.SetNumber(++NumOfSeconds);
        }
        private void Cheat()
        {
            for(int i =0; i < Grid.Length;i++)
            {
                if (!game.Board[i].IsMine) CheckSquare((ushort)i);
            }
        }
        private Board getBoard(Settings.Difficulty diff)
        {
            if (Settings.Difficulty.Beginner == diff) return beginnerBoard;
            if (Settings.Difficulty.Intermediate == diff) return intermediateBoard;
            if (Settings.Difficulty.Expert == diff) return expertBoard;
            return customBoard = new Board((byte)settings.Width, (byte)settings.Height, settings.Bombs);
        }
        private void btnSmile_Click(object sender, EventArgs e)
        {
            //LoadBoardSize(settings.difficulty);
            NumberOfFlags = 0;
            CurrentBoard = getBoard(settings.difficulty);
            settings.Bombs = CurrentBoard.Bombs;
            this.Width = (CurrentBoard.Width * buttonSizePX) + 30;
            this.Height = (CurrentBoard.Height * buttonSizePX) + gbTop.Height + 50 + menuStrip1.Height;
            SetupTimer();

            IsGameover = false;
            Grid = new Button[CurrentBoard.Width * CurrentBoard.Height];
            for(int i = gbMain.Controls.Count; i > 0; i--)
            {
                Control c = gbMain.Controls[i-1];
                gbMain.Controls.Remove(c);
                c.Dispose();
            }
            //gbMain.Controls.Clear();

            for (ushort i = 0; i < Grid.Length; i++)
            {
                Grid[i] = new Button();
                Grid[i].Width = buttonSizePX;
                Grid[i].Height = buttonSizePX;
                Grid[i].Padding = new Padding(0);
                Grid[i].MouseDown += btnMine_MouseDown;
                Grid[i].MouseUp += btnMine_MouseUp;
                Grid[i].BackgroundImage = null;
                Grid[i].FlatStyle= FlatStyle.System;
            }

            gbMain.Width = buttonSizePX * CurrentBoard.Width;
            gbMain.Height = buttonSizePX * CurrentBoard.Height;

            for (int c = 0, x = 0; c < CurrentBoard.Height; c++)
            {
                for (int w = 0; w < CurrentBoard.Width; w++, x++)
                {
                    gbMain.Controls.Add(Grid[x]);
                    Grid[x].Location = new Point(buttonSizePX * w, buttonSizePX * c);
                    Grid[x].Click += btnMine_Click;
                    Grid[x].MouseHover += btnMine_MouseHover;
                    Grid[x].BackColor = ButtonBackColour;
                    Grid[x].FlatStyle = FlatStyle.Popup;
                }
            }
            Mines.SetNumber(CurrentBoard.Bombs);
            Time.SetNumber(0);
            game = new Game();
            game.New(CurrentBoard.Width, CurrentBoard.Height, (byte)CurrentBoard.Bombs);
            FirstClick = true;
            gbMain.Refresh();
            GC.Collect();

            //Cheat();
        }

        Point Button;
        private void btnMine_MouseDown(object sender, EventArgs e)
        {
            System.Windows.Forms.MouseEventArgs args = (System.Windows.Forms.MouseEventArgs)e;
            if (args.Button != MouseButtons.Right) return;
            Button = args.Location;
        }

        private void btnMine_MouseUp(object sender, EventArgs e)
        {
            if (((System.Windows.Forms.MouseEventArgs)e).Button != MouseButtons.Right) return;
            if (Button == ((System.Windows.Forms.MouseEventArgs)e).Location)
                btnMineRight_Click(sender, e);
            Button = Point.Empty;
        }
        private void Gameover(ushort squareClicked)
        {
            t.Enabled = false;
            PictureBox pb;
            for (int i = 0; i < Grid.Length; i++)
                if (game.Board[i].IsMine)
                {
                    SetImage(Grid[i], Bomb);
                    pb = new PictureBox();
                    pb.BackColor = RevealedBackColour;
                    pb.Location = Grid[i].Location;
                    pb.Size = Grid[i].Size;
                    pb.Padding = Grid[i].Padding;
                    pb.Font = new Font(Grid[i].Font, FontStyle.Bold);
                    pb.BackgroundImage = Bomb;
                    pb.BackgroundImageLayout = ImageLayout.Stretch;
                    
                    pb.Paint += pictureBox_Paint;
                    if (i == squareClicked)
                        pb.BackColor = Color.Red;
                    gbMain.Controls.Add(pb);
                    pb.Refresh();

                    Grid[i].Visible = false;
                }
            //Grid[squareClicked].BackColor = Color.Red;
            gbMain.Refresh();
            IsGameover = true;
            t.Stop();
        }
        private void btnMine_Click(object sender, EventArgs e)
        {
            if (IsGameover) return;

            if(!t.Enabled)
            {
                t.Start();
            }

            ushort index = PositionToIndex(((Button)sender).Location);
            //Make sure first click isn't a bomb
            if(FirstClick)
            {
                if (game.Board[index].IsMine)
                    Swap(index);
                FirstClick = false;
            }
            if (game.Board[index].IsFlagged) return;
            CheckSquare(index);
            AlreadyChecked = null;
            if (HasWon())
            {
                settings.NumberOfWins = (ushort)(settings.NumberOfWins+1);
                t.Enabled = false;
                IsGameover = true;
                if (settings.IsTimeTopTen(settings.difficulty, NumOfSeconds))
                {
                    InputName inputName = new InputName();
                    inputName.Time = NumOfSeconds;
                    inputName.ShowDialog();
                    settings.AddTime(settings.difficulty, new Score(inputName.Name, NumOfSeconds));
                    inputName.Dispose();
                    Highscores hs = new Highscores();
                    hs.settings = settings;
                    hs.ShowDialog();
                    gbMain.Refresh();
                }
                settings.Save();
                ShowWinPicture();
            }
            btnSmile.Select();
        }

        private void ShowWinPicture()
        {
            Chan = new Bitmap(Chan, new Size(CurrentBoard.Width * buttonSizePX, CurrentBoard.Height * buttonSizePX));
            for (int i = 0, square = 0, firstSquare=0; i < settings.NumberOfWins && i < CurrentBoard.Width * CurrentBoard.Height; i++, square+=5)
            {
                if(square > (CurrentBoard.Height * CurrentBoard.Width)-1)
                {
                    square = (++firstSquare);
                }
                Bitmap img = new Bitmap(Chan);
                PictureBox pb = new PictureBox();
                pb.Location = Grid[square].Location;
                pb.Size = Grid[square].Size;
                RectangleF rf = new RectangleF();
                rf.X = Grid[square].Location.X;
                rf.Y = Grid[square].Location.Y;
                rf.Size = Grid[square].Size;
                pb.Image = img.Clone(rf, Chan.PixelFormat);
                gbMain.Controls.Add(pb);
                pb.BringToFront();
            }
        }

        //Swaps the given square to be a random non-bomb square.
        private void Swap(ushort index)
        {
            Random rnd = new Random();
            ushort i;
            Square sq;
            while (game.Board[i = (ushort)rnd.Next(game.Board.Length+1)].IsMine);
            sq = game.Board[index];
            game.Board[index] = game.Board[i];
            game.Board[i] = sq;
        }

        private bool HasWon()
        {
            for (int i = 0; i < game.Board.Length; i++)
                if (Grid[i].Visible && !game.Board[i].IsMine) return false;
            return true;
        }

        Dictionary<ushort, ushort> AlreadyChecked;
        private void CheckSquare(ushort index)
        {
            if(game.Board[index].IsFlagged && !game.Board[index].IsMine)
            {
                ToggleFlag(index);
            }
            Label label;

            if (game.Board[index].IsMine)
            {
                Gameover(index);
                return;
            }
            List<ushort> AdjacentSquares = GetAdjacentSquares(index);

            byte bombCount = 0;
            for (int i = 0; i < AdjacentSquares.Count; i++)
                if (game.Board[AdjacentSquares[i]].IsMine)
                    bombCount++;
            if (0 != bombCount)
            {
                Color c;
                //Show number
                Grid[index].Font = new Font(Grid[index].Font, FontStyle.Bold);
                switch (bombCount)
                {
                    case 1:     c = One;
                                break;
                    case 2:     c = Two;
                                break;
                    case 3:     c = Three;
                                break;
                    case 4:     c = Four;
                                break;
                    case 5:     c = Five;
                                break;
                    case 6:     c = Six;
                                break;
                    case 7:     c = Seven;
                                break;
                    case 8:     c = Eight;
                                break;
                    default:    c = Color.White;
                                break;
                }
                label = new Label();
                gbMain.Controls.Add(label);
                label.ForeColor = c;
                label = SetLabelProperties(label, Grid[index]);
                gbMain.Controls.Add(label);
                label.Text = bombCount.ToString();
            }
            else
            {
                if(null == AlreadyChecked)
                    AlreadyChecked = new Dictionary<ushort, ushort>();
                for (int i = 0; i < AdjacentSquares.Count; i++)
                {
                    if (!AlreadyChecked.ContainsKey(AdjacentSquares[i]))
                    {
                        AlreadyChecked.Add(AdjacentSquares[i], AdjacentSquares[i]);
                        CheckSquare(AdjacentSquares[i]);
                    }
                }
                label = SetLabelProperties(new Label(), Grid[index]);
                gbMain.Controls.Add(label);
            }

        }
        private Label SetLabelProperties(Label label, Button b)
        {
            label.BackColor = RevealedBackColour;
            label.Location = b.Location;
            label.Size = b.Size;
            label.Padding = b.Padding;
            label.Font = new Font(b.Font, FontStyle.Bold);
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Paint += label_Paint;
            
            b.Visible = false;
            return label;
        }
        void label_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ((Label)sender).DisplayRectangle, Color.LightGray, ButtonBorderStyle.Solid);
        }
        void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ((PictureBox)sender).DisplayRectangle, Color.LightGray, ButtonBorderStyle.Solid);           
        }
        private List<ushort> GetAdjacentSquares(ushort index)
        {
            List<ushort> AdjacentSquares = new List<ushort>();
            bool above = HasRowAbove(index);
            bool left = HasColumnLeft(index);
            bool right = HasColumnRight(index);
            bool below = HasRowBelow(index);
            ushort AboveSquare = 0;
            ushort BelowSquare = 0;

            if (above)
                AdjacentSquares.Add(AboveSquare = (ushort)(index - getBoard(settings.difficulty).Width));
            if (left)
                AdjacentSquares.Add((ushort)(index - 1));
            if (right)
                AdjacentSquares.Add((ushort)(index + 1));
            if (below)
                AdjacentSquares.Add(BelowSquare = (ushort)(index + getBoard(settings.difficulty).Width));
            if (above && left)
                AdjacentSquares.Add((ushort)(AboveSquare - 1));
            if (above && right)
                AdjacentSquares.Add((ushort)(AboveSquare + 1));
            if (below && left)
                AdjacentSquares.Add((ushort)(BelowSquare - 1));
            if (below && right)
                AdjacentSquares.Add((ushort)(BelowSquare + 1));
            return AdjacentSquares;
        }
        private bool HasRowAbove(ushort index)
        {
                return index - (getBoard(settings.difficulty).Width - 1) > 0;            
        }
        private bool HasColumnLeft(ushort index)
        {
            return 0 != index % getBoard(settings.difficulty).Width;
        }
        private bool HasColumnRight(ushort index)
        {
            return 0 != (index+1) % getBoard(settings.difficulty).Width;
        }
        private bool HasRowBelow(ushort index)
        {
            return index + getBoard(settings.difficulty).Width + 1 <= getBoard(settings.difficulty).Width * getBoard(settings.difficulty).Height;
        }

        private void ToggleFlag(ushort index)
        {
            //Flagged to ?
            if((game.Board[index].IsFlagged))
            {
                NumberOfFlags--;
                if(NumberOfFlags <= CurrentBoard.Bombs)
                {
                    Mines.SetNumber((ushort)(CurrentBoard.Bombs -  NumberOfFlags));
                }
                Grid[index].BackgroundImage = null;
                Grid[index].FlatStyle = FlatStyle.System;
                Grid[index].Font = new Font(Grid[index].Font, FontStyle.Bold);
                Grid[index].Text = "?";
                game.Board[index].IsFlagged = false;
                Grid[index].BackColor = ButtonBackColour;
                Grid[index].FlatStyle = FlatStyle.Popup;
                return;
            }
            if ("?" == Grid[index].Text)
            {
                Grid[index].BackgroundImage = null;
                Grid[index].FlatStyle = FlatStyle.Popup;
                Grid[index].BackColor = ButtonBackColour;
                Grid[index].Text = "";
                return;
            }
            SetImage(Grid[index], Flag);
            game.Board[index].IsFlagged = true;
            NumberOfFlags++;
            if(NumberOfFlags <= CurrentBoard.Bombs)
            {
                Mines.SetNumber((ushort)(CurrentBoard.Bombs - NumberOfFlags));
            }
        }

        private void SetImage(Button b, Image i)
        {
            b.BackgroundImage = i;
            b.BackgroundImageLayout = ImageLayout.Stretch;
            b.FlatStyle = FlatStyle.Flat;
            b.ImageAlign = ContentAlignment.MiddleCenter;
        }

        private ushort PositionToIndex(Point p)
        {
            return (ushort) ((getBoard(settings.difficulty).Width * (p.Y / buttonSizePX)) + (p.X / buttonSizePX));
        }
        private void btnMineRight_Click(object sender, EventArgs e)
        {
            if (IsGameover) return;
            //sender.
            ushort index = PositionToIndex(((Button)sender).Location); //ButtonNum[sender.GetHashCode()];
            System.Windows.Forms.MouseEventArgs args = (System.Windows.Forms.MouseEventArgs)e;
            if (args.Button != MouseButtons.Right) return;
            ToggleFlag(index);
        }

        private string getBasePath()
        {
            return new Uri(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)).LocalPath;
        }

        private void LoadSettings()
        {
            settings = new Settings(true);
        }

        private void BeginnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            t.Enabled = false;
            settings.difficulty = Settings.Difficulty.Beginner;
            intermediateToolStripMenuItem.Checked = false;
            expertToolStripMenuItem.Checked = false;
            customToolStripMenuItem.Checked = false;
            btnSmile_Click(null, null);
        }

        private void intermediateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            t.Enabled = false;
            settings.difficulty = Settings.Difficulty.Intermediate;
            BeginnerToolStripMenuItem.Checked = false;
            expertToolStripMenuItem.Checked = false;
            customToolStripMenuItem.Checked = false;
            btnSmile_Click(null, null);
        }

        private void expertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            t.Enabled = false;
            settings.difficulty = Settings.Difficulty.Expert;
            BeginnerToolStripMenuItem.Checked = false;
            intermediateToolStripMenuItem.Checked = false;
            customToolStripMenuItem.Checked = false;
            btnSmile_Click(null, null);
        }

        private void customToolStripMenuItem_Click(object sender, EventArgs e)
        {
            t.Enabled = false;
            settings.difficulty = Settings.Difficulty.Custom;
            BeginnerToolStripMenuItem.Checked = false;
            intermediateToolStripMenuItem.Checked = false;
            expertToolStripMenuItem.Checked = false;
            btnSmile_Click(null, null);
        }

        private void highscoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Highscores h = new Highscores();
            h.settings = settings;
            h.ShowDialog();
        }

        private void settingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CustomSettings cs = new CustomSettings();
            cs.settings = settings;
            cs.ShowDialog();
            if(Settings.Difficulty.Custom == settings.difficulty)
            {
                btnSmile_Click(null, null);
            }
        }

        private void btnMine_MouseHover(object sender, EventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftShift))
            {
                ushort index = PositionToIndex(((Button)sender).Location);
                if(game.Board[index].IsMine)
                {
                    if (!game.Board[index].IsFlagged)
                        ToggleFlag(index);
                }
            }
        }

        private void btnSmile_Paint(object sender, PaintEventArgs e)
        {
            int smileWidth = 20;
            int smileHeight = 20;
            int smileX = (btnSmile.Width - smileWidth) / 2;
            int smileY = (btnSmile.Height - smileHeight) / 2;

            int eyeSize = 5;
            int eyeSidePad = 4;
            int eyeTopPad = 5;

            int LeftEyeX = smileX + eyeSidePad;
            int LeftEyeY = smileY + eyeTopPad;

            int RightEyeX = ((smileWidth + smileX) - (2 * eyeSidePad))-1;
            int RightEyeY = smileY + eyeTopPad;

            int SmileHeight = ((smileX + smileHeight) - eyeTopPad)-5;
            //Head
            e.Graphics.FillEllipse(Brushes.Yellow, smileX ,smileY, smileWidth, smileHeight);
            e.Graphics.DrawEllipse(new Pen(Color.Black), smileX, smileY, smileWidth, smileHeight);

            //Left Eye
            e.Graphics.FillEllipse(Brushes.Black, LeftEyeX, LeftEyeY, eyeSize, eyeSize);
            //Right Eye
            e.Graphics.FillEllipse(Brushes.Black, RightEyeX,RightEyeY , eyeSize, eyeSize);

            //Smile Left
            PointF SmileLeft = new PointF(LeftEyeX+1, SmileHeight);
            //Smile Right
            PointF SmileRight = new PointF(RightEyeX+4, SmileHeight);
            //Smile bottom
            PointF SmileBottom = new PointF(SmileLeft.X + ((SmileRight.X - SmileLeft.X) /2), SmileHeight+3);
            PointF[] smile = { SmileLeft, SmileBottom, SmileRight };
            Pen p = new Pen(Color.Black, (float)1.5);
            e.Graphics.DrawCurve(p, smile);


            PointF SmileBottom0 = new PointF(SmileLeft.X + ((SmileRight.X - SmileLeft.X) / 2), SmileHeight + 1);
            smile = new PointF[] { SmileLeft, SmileBottom, SmileRight };
            e.Graphics.DrawCurve(p, smile);

            p.Dispose();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }
    }
    public class Game
    {
        public Square[] Board;
        Random rnd = new Random();

        public bool New(byte width, byte height, byte mines)
        {
            //Sets a new game i.e. regenerates Square
            ushort size = (ushort)(width * height);
            if (0 == size) return false;
            Board = new Square[width * height];
            for (int i = 0; i < size; i++)
            {
                Board[i] = new Square();
                if(0 != mines)
                {
                    Board[i].IsMine = true;
                    --mines;
                }
            }

            //Shuffle the board
            for (int i = 0; i < size*2;i++)
            {
                ushort x = (ushort) rnd.Next(0, size);
                ushort y = (ushort) rnd.Next(0, size);
                Square t = Board[x];
                Board[x] = Board[y];
                Board[y] = t;
            }
            return true;
        }
    }
    public class Square
    {
        public bool IsMine = false;
        public bool IsFlagged = false;
        public byte AdjacentMines; //0 - 8
    }

    public class Board
    {
        public byte Width;
        public byte Height;
        public ushort Bombs;
        public Board(byte width, byte height, ushort bombs)
        {
            Width = width;
            Height = height;
            Bombs = bombs;
        }
    }
}
