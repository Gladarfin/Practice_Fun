using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StarfieldDemo
{
    public partial class Form1 : Form
    {

        private Star[] starsArr = new Star[5000];

        private Random random = new Random();

        private Graphics graphics;

        private Brush[] starColors = new Brush[6]
        {
            Brushes.White,
            Brushes.Red,
            Brushes.Orange,
            Brushes.Blue,
            Brushes.AliceBlue,
            Brushes.Yellow
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            graphics.Clear(Color.Black);
            for (int i = 0; i < starsArr.Length; i++)
            {
                DrawStar(starsArr[i]);
                MoveStar(starsArr[i], i);
            }
            pictureBox1.Refresh();
        }

        private void MoveStar(Star star, int iterator)
        {
            star.Z -= 30;
            if (star.Z < 1)
                starsArr[iterator] = GenerateNewStar();
        }

        private void DrawStar(Star star)
        {           
            var starSize = Map(star.Z, 0, pictureBox1.Width, 12, 0);
            float x = Map(star.X / star.Z, 0, 1, 0, pictureBox1.Width) + pictureBox1.Width / 2;
            float y = Map(star.Y / star.Z, 0, 1, 0, pictureBox1.Height) + pictureBox1.Height / 2;
            graphics.FillEllipse(star.Color, x, y, starSize, starSize);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(pictureBox1.Image);

            for (int i = 0; i < starsArr.Length; i++)
            {
                starsArr[i] = GenerateNewStar();
            }
            
            timer1.Start();
        }

        private float Map(float n, float start, float stop, float start2, float stop2)
        {
            return ((n - start) / (stop - start)) * (stop2 - start2) + start2;
        }

        private Star GenerateNewStar()
        {
            return new Star
            {
                X = random.Next(-pictureBox1.Width, pictureBox1.Width),
                Y = random.Next(-pictureBox1.Height, pictureBox1.Height),
                Z = random.Next(1, pictureBox1.Width),
                Color = starColors[random.Next(0,6)]
            };
        }
    }
}
