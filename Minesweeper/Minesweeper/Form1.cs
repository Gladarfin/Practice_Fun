using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;

namespace Minesweeper
{
    //refactoring gogogo

    public partial class Form1 : Form
    {
        
        private int Columns { get; set; }
        private int Rows { get; set; }
        private ImageList Imgs { get; set; }
        private Game Game { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Game = new Game();
            int cellSize = int.Parse(Properties.Resources.CellSize);
            Columns = gamePanel.Height / cellSize;
            Rows = gamePanel.Width / cellSize;
            Game.GameStart(Columns, Rows);
            LoadImages();
            GenerateElements();
            bombCount.Text = Game.BombsCount();
        }

        public void GenerateElements()
        {
            for (int i = 0; i < Columns; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    CreateFieldElem(i, j);
                }
            }
        }

        private void CreateFieldElem(int i, int j)
        {
            int cellSize = int.Parse(Properties.Resources.CellSize);

            NoSelectButton b =  new NoSelectButton
            {
                Left = i * cellSize,
                Top = j * cellSize,
                Height = cellSize,
                Width = cellSize,
                Tag = i + j * Rows,
                TabStop = false,
            };
            b.Click += FieldElem_Click;
            gamePanel.Controls.Add(b);
        }

        private void LoadImages()
        {
            Imgs = new ImageList
            {
                ImageSize = new Size(32, 32)
            };
            Imgs.Images.Add(Properties.Resources.bomb);
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            ResetField();
            Game.RestartGame(Columns, Rows);
            bombCount.Text = Game.BombsCount();
        }

        private void ResetField()
        {
            foreach (NoSelectButton child in gamePanel.Controls)
            {
                child.Enabled = true;
                child.BackgroundImage = null;
                child.Text = "";
                child.BackColor = Color.FromArgb(225, 225, 225);
            }
        }

        private void FieldElem_Click(object sender, EventArgs e)
        {
            if (Game.IsGameInProgress())
                return;
            NoSelectButton clickedButton = (NoSelectButton)sender;
            clickedButton.Enabled = false;
            clickedButton.BackColor = Color.LightGray;
            int cellIndex = int.Parse(clickedButton.Tag.ToString());
            if (Game.IsBomb(cellIndex))
            {
                GameOver();
            }
            else
            {
                int index = int.Parse(clickedButton.Tag.ToString());
                clickedButton.Text = Game.GetElement(index);
                if (clickedButton.Text == "0")
                {
                    clickedButton.Text = "";
                    CheckNeighbours(clickedButton);
                }
            }
        }

        private void GameOver()
        {
            List<int> bombsList = Game.IsGameOver();
            foreach (NoSelectButton button in gamePanel.Controls)
            {
                if (bombsList.Contains(int.Parse(button.Tag.ToString())))
                {
                    button.BackgroundImage = Imgs.Images[0];
                    button.BackgroundImageLayout = ImageLayout.Center;
                }
            }
            MessageBox.Show("Game Over!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CheckNeighbours(NoSelectButton clickedButton)
        {
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    string nextFieldCell = Game.RevealField(clickedButton, i, j);
                    if (nextFieldCell == "")
                        continue;
                    var btn = gamePanel.Controls.OfType<NoSelectButton>().FirstOrDefault(elem => elem.Tag.ToString() == nextFieldCell);
                    if (!btn.Enabled || btn == null)
                        continue;

                    FieldElem_Click(btn, null);
                }
            }
        }
    }
}
