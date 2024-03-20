using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace KPO_Vaja1
{
    
    public partial class Form1 : Form
    {

        private Random rnd = new Random();

        public double birthBlue;
        public double mortalityBlue;
        public double kBlue;

        public double birthGreen;
        public double mortalityGreen;
        public double kGreen;

        public double birthGold;
        public double mortalityGold;
        public double kGold;

        public int startingCellCountBlue = 0;
        public int currentCellCountBlue = 0;

        public int startingCellCountGreen = 0;
        public int currentCellCountGreen = 0;

        public int startingCellCountGold = 0;
        public int currentCellCountGold = 0;

        public int intervalCounter = 0;

        bool start = false;
        int state = 0;
        List<Point> pointListBlue = new List<Point>();
        List<Point> pointListGreen = new List<Point>();
        List<Point> pointListGold= new List<Point>();
        Point startXB;
        Point startXGr;
        Point startXGd;

        public Form1()
        {
            InitializeComponent();
            panel1.BackColor = Color.AliceBlue;
            typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                       .SetValue(panel2, true, null);
            typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                       .SetValue(panel1, true, null);
            textBox4.Text = "10";
            textBox3.Text = "0,1";
            textBox2.Text = "0,05";
            textBox1.Text = "0,0005";

            textBox5.Text = "10";
            textBox6.Text = "0,1";
            textBox7.Text = "0,05";
            textBox8.Text = "0,0005";

            textBox9.Text = "10";
            textBox10.Text = "0,1";
            textBox11.Text = "0,05";
            textBox12.Text = "0,0005";

        }

        private void GenerateCells( )
        {
            for(int i = 0; i < startingCellCountBlue ; i++)
            {
                Cell cell = new Cell(panel1.Size, birthBlue, mortalityBlue, kBlue,Brushes.Blue);
                panel1.Controls.Add(cell);
                currentCellCountBlue++;
            }
            for (int i = 0; i < startingCellCountGreen; i++)
            {
                Cell cell = new Cell(panel1.Size, birthGreen, mortalityGreen, kGreen, Brushes.Green);
                panel1.Controls.Add(cell);
                currentCellCountGreen++;
            }
            for (int i = 0; i < startingCellCountGold; i++)
            {
                Cell cell = new Cell(panel1.Size, birthGold, mortalityGold, kGold, Brushes.Gold);
                panel1.Controls.Add(cell);
                currentCellCountGold++;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(state == 0)
            {
                startingCellCountBlue = int.Parse(textBox4.Text);
                startingCellCountGreen = int.Parse(textBox5.Text);
                startingCellCountGold = int.Parse(textBox9.Text);

                birthBlue = double.Parse(textBox3.Text);
                mortalityBlue = double.Parse(textBox2.Text);
                kBlue = double.Parse(textBox1.Text);

                birthGreen = double.Parse(textBox6.Text);
                mortalityGreen = double.Parse(textBox7.Text);
                kGreen = double.Parse(textBox8.Text);

                birthGold = double.Parse(textBox10.Text);
                mortalityGold = double.Parse(textBox11.Text);
                kGold = double.Parse(textBox12.Text);


                startXB = new Point(20, panel2.Height - 10 - startingCellCountBlue);
                startXGr = new Point(20, panel2.Height - 10 - startingCellCountGreen);
                startXGd = new Point(20, panel2.Height - 10 - startingCellCountGold);

                pointListBlue.Add(startXB);
                pointListGreen.Add(startXGr);
                pointListGold.Add(startXGd);
                GenerateCells();
                start = true;
                state++;
            }
            else if(state % 2 != 0)
            {
                start = false;
                pointListBlue.Clear();
                pointListGreen.Clear();
                pointListGold.Clear();
                panel1.Controls.Clear();
                panel2.Controls.Clear();
                startingCellCountBlue = 0;
                currentCellCountBlue = 0;

                startingCellCountGreen = 0;
                currentCellCountGreen = 0;

                startingCellCountGold = 0;
                currentCellCountGold = 0;
                state++;

            }
            else if (state % 2 == 0)
            {
                startingCellCountBlue = int.Parse(textBox4.Text);
                startingCellCountGreen = int.Parse(textBox5.Text);
                startingCellCountGold = int.Parse(textBox9.Text);

                birthBlue = double.Parse(textBox3.Text);
                mortalityBlue = double.Parse(textBox2.Text);
                kBlue = double.Parse(textBox1.Text);

                birthGreen = double.Parse(textBox6.Text);
                mortalityGreen = double.Parse(textBox7.Text);
                kGreen = double.Parse(textBox8.Text);

                birthGold = double.Parse(textBox10.Text);
                mortalityGold = double.Parse(textBox11.Text);
                kGold = double.Parse(textBox12.Text);


                startXB = new Point(20, panel2.Height - 10 - startingCellCountBlue);
                startXGr = new Point(20, panel2.Height - 10 - startingCellCountGreen);
                startXGd = new Point(20, panel2.Height - 10 - startingCellCountGold);

                pointListBlue.Add(startXB);
                pointListGreen.Add(startXGr);
                pointListGold.Add(startXGd);
                GenerateCells();
                start = true;
                state++;
            }
            
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (start) {
                label5.Text = currentCellCountBlue.ToString();
                label14.Text = currentCellCountGreen.ToString();
                label15.Text = currentCellCountGold.ToString();

                pointListBlue.Add(new Point(pointListBlue.Last().X + 2, startXB.Y - currentCellCountBlue));
                pointListGreen.Add(new Point(pointListGreen.Last().X + 2, startXGr.Y - currentCellCountGreen));
                pointListGold.Add(new Point(pointListGold.Last().X + 2, startXGd.Y - currentCellCountGold));

                panel2.Invalidate();


                foreach (Control c in panel1.Controls)
                {
                    if (c is Cell cell)
                    {
                        if (cell.CheckLifeCycle())
                        {
                            if (cell.GetCellType() == "B")
                            {
                                if (cell.getNewState(currentCellCountBlue))
                                {
                                    Cell new_cell = new Cell(panel1.Size, birthBlue, mortalityBlue, kBlue, Brushes.Blue);
                                    panel1.Controls.Add(new_cell);
                                    currentCellCountBlue++;

                                }
                                else if (!cell.getNewState(currentCellCountBlue))
                                {
                                    panel1.Controls.Remove(cell);
                                    currentCellCountBlue--;

                                }
                            }
                            else if (cell.GetCellType() == "Gr")
                            {
                                if (cell.getNewState(currentCellCountGreen))
                                {
                                    Cell newCell = new Cell(panel1.Size, birthGreen, mortalityGreen, kGreen, Brushes.Green);
                                    panel1.Controls.Add(newCell);
                                    currentCellCountGreen++;
                                }
                                else if (!cell.getNewState(currentCellCountGreen))
                                {
                                    panel1.Controls.Remove(cell);
                                    currentCellCountGreen--;
                                }
                            }
                            else if (cell.GetCellType() == "Gd")
                            {
                                if (cell.getNewState(currentCellCountGold))
                                {
                                    Cell newCell = new Cell(panel1.Size, birthGreen, mortalityGreen, kGreen, Brushes.Gold);
                                    panel1.Controls.Add(newCell);
                                    currentCellCountGold++;

                                }
                                else if (!cell.getNewState(currentCellCountGold))
                                {
                                    panel1.Controls.Remove(cell);
                                    currentCellCountGold--;
                                }
                            }

                        }
                        else
                        {
                            cell.Move(rnd);
                            panel1.Invalidate();

                        }
                    }
                }
            }
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Pen blackPen = new Pen(Color.Black, 3);
            Pen bluePen = new Pen(Color.Blue, 3);
            Pen greenPen = new Pen(Color.Green, 3);
            Pen goldPen = new Pen(Color.Gold, 3);

            e.Graphics.DrawLine(blackPen, 20, panel2.Height - 20, panel2.Width - 20, panel2.Height - 20 );
            e.Graphics.DrawLine(blackPen, 20, panel2.Height - 20, 20, 10);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;


            for (int i = 0; i < pointListBlue.Count - 1; i++)
            {
                
                e.Graphics.DrawLine(bluePen, pointListBlue[i], pointListBlue[i + 1]);
            }
            for (int i = 0; i < pointListGreen.Count - 1; i++)
            {

                e.Graphics.DrawLine(greenPen, pointListGreen[i], pointListGreen[i + 1]);
            }
            for (int i = 0; i < pointListGold.Count - 1; i++)
            {
                
                e.Graphics.DrawLine(goldPen, pointListGold[i], pointListGold[i + 1]);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }


    public class Cell : Control
    {

        private int size = 8;
        private double birth;
        private double mortality;
        private double k;

        private int lifeCycleCount = 0;
        private const int lifeCycleMaxCount = 25;
        Brush b;
        Random random = new Random();

        private Point position;
        private Size panelS;
        public Cell(Size panelSize, double birth, double mortality, double k, Brush b)
        {
            this.panelS = panelSize;
            this.birth = birth;
            this.mortality = mortality;
            this.k = k;
            this.b = b;

            SetPosition();
            
            Size = new Size(size, size);
            Location = position;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            base.OnPaint(e);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            e.Graphics.FillEllipse(b, new Rectangle(Point.Empty, Size));
        }

        private void SetPosition()
        {
            position = new Point(random.Next(panelS.Width - size), random.Next(panelS.Height - size));
            Location = position;
        }
        public string GetCellType()
        {
            return b == Brushes.Blue ? "B" : b == Brushes.Gold ? "Gd" : "Gr"; ; 
        }

        public bool CheckLifeCycle()
        {
            if (lifeCycleCount < lifeCycleMaxCount)
            {
                return false;
            }
            else  
            {
                return true;
            }

        }
        public bool getNewState(int currCell)
        {
            double delta = ((birth - mortality - k * currCell) * currCell);

            int rndNum = random.Next(100);

            if(rndNum > delta * 100)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public void Move(Random random)
        {
            int moveX = Math.Max(Math.Min(position.X + random.Next(-7, 7), panelS.Width - size), 0);
            int moveY = Math.Max(Math.Min(position.Y + random.Next(-7 ,7), panelS.Height - size), 0);
            position = new Point(moveX, moveY);
            Location = position;
            lifeCycleCount++;
        }
    }
}
