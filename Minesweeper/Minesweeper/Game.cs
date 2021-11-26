using System.Collections.Generic;

namespace Minesweeper
{
    class Game
    {
        private bool isGameOver = false;
        private Field GameField { get; set; }
        public void GameStart(int columns, int rows)
        {
            GameField = new Field();
            GameField.FillTheField(columns, rows);
        }

        public List<int> IsGameOver()
        {
            isGameOver = true;
            //reveal bombs
            return GameField.RevealAllBombs();
        }
        
        public bool IsGameInProgress()
        {
            return isGameOver;
        }

        public string RevealField(NoSelectButton button, int i, int j)
        {
            return GameField.Reveal(button, i, j);
        }

        public string GetElement(int index)
        {
            return GameField.GetFieldElement(index);
        }

        public bool IsBomb(int cellIndex)
        {
            return GameField.IsCellBomb(cellIndex);
        }

        public void RestartGame(int columns, int rows)
        {
            GameField.FillTheField(columns, rows);
            isGameOver = false;
        }

        public string BombsCount()
        {
            return GameField.BombCountToString();
        }
    }
}
