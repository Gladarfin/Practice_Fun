using System;
using System.Collections.Generic;
using System.Linq;

namespace Minesweeper
{
    class Game
    {
        private bool isGameOver = false;
        public FieldCell[] Cells { get; set; }
        private int Columns { get; set; }
        private int Rows { get; set; }
        private int BombCount { get; set; }
  
        public void GameStart(int columns, int rows)
        {
            Columns = columns;
            Rows = rows;
            FillTheField();

        }
 
        public List<int> IsGameOver()
        {
            isGameOver = true;
            //reveal bombs
            return RevealAllBombs();
        }       
 
        public bool IsGameInProgress()
        {
            return isGameOver;
        }
 
        public string RevealField(NoSelectButton button, int i, int j)
        {
            return Reveal(button, i, j);
        }
 
        public string GetElement(int index)
        {
            return Cells[index].NeighboursIsBombCount.ToString();
        }

        public bool IsBomb(int cellIndex)
        {
            return Cells[cellIndex].IsBomb;
        }

        public void RestartGame()
        {
            FillTheField();
            isGameOver = false;
        }

        public string BombsCount()
        {
            return "Количество бомб: " + BombCount.ToString();
        }

        public void FillTheField()
        {
            BombCount = 0;
            CreateCells();
            CountBombsAround();
        }

        private void CreateCells()
        {
            Cells = new FieldCell[Rows * Columns];
            Random rnd = new Random();
            for (int i = 0; i < Columns; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    Cells[i + j * Rows] = new FieldCell()
                    {
                        CoordX = i,
                        CoordY = j,
                        IsBomb = rnd.NextDouble() <= 0.15
                    };
                    BombCount += Cells[i + j * Rows].IsBomb ? 1 : 0;
                }
            }
        }

        //fill cells with numbers of bombs around
        private void CountBombsAround()
        {
            for (int i = 0; i < Columns; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    if (!Cells[i + j * Rows].IsBomb)
                        CountBombsInNeighbours(Cells[i + j * Rows]);
                }
            }
        }
 
        private void CountBombsInNeighbours(FieldCell fc)
        {
            int total = 0;
            int index;
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    int indexX = fc.CoordX + i;
                    int indexY = fc.CoordY + j;
                    if (!InBoundaries(indexX, indexY))
                    {
                        continue;
                    }
                    index = indexX + indexY * Columns;
                    if (Cells[index].IsBomb)
                        total++;
                }
            }
            fc.NeighboursIsBombCount += total;
        }
 
        private bool InBoundaries(int x, int y)
        {
            return x >= 0 && x < Columns &&
                        y >= 0 && y < Columns;
        }
        //reveal field after press on field cell without bombs around
        public string Reveal(NoSelectButton button, int i, int j)
        {
            int tempX = Cells[int.Parse(button.Tag.ToString())].CoordX + i;
            int tempY = Cells[int.Parse(button.Tag.ToString())].CoordY + j;

            if (!InBoundaries(tempX, tempY))
                return "";

            int tempIndex = tempX + tempY * Rows;

            if (tempIndex < 0 ||
                tempIndex > Rows * Columns - 1 ||
                Cells[tempIndex].IsBomb)
                return "";
            return tempIndex.ToString();
        }
 
        public List<int> RevealAllBombs()
        {
            return Cells.Where(elem => elem.IsBomb)
                        .Select(index => index.CoordX + index.CoordY * Rows)
                        .ToList();
        }
    }
}
