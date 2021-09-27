using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeGeneratorWF
{
    class MazeGeneratorBaseClass
    {
        private static int windowSideSize;
        private static int cellSideSize;
        private static int columnsCount;
        private static int rowsCount;
        private static Cell[] Maze;
        private static Stack<Tuple<int, int>> stackOfApexes;
        private static Pen pen;
        private static Graphics graphics;
        private static DrawLabyrinth drawLabyrinth;
        Tuple<int, int> stackPrevValue;
        public static Random randomValue;

        public MazeGeneratorBaseClass()
        {
            cellSideSize = Properties.Settings.Default.LabCellSideSize;
            windowSideSize = Properties.Settings.Default.LabyrinthWinSize;
            columnsCount = windowSideSize / cellSideSize;
            rowsCount = windowSideSize / cellSideSize;
            Maze = new Cell[columnsCount * rowsCount];
            stackOfApexes = new Stack<Tuple<int, int>>();
            pen = new Pen(Color.Black, 2);
            graphics = Form.ActiveForm.CreateGraphics();
            drawLabyrinth = new DrawLabyrinth();
            randomValue = new Random();
        }
        public void InitializeVariables()
        {
            for (int x = 0; x < rowsCount; x++)
                for (int y = 0; y < columnsCount; y++)
                {
                    Maze[y * columnsCount + x] = new Cell() { X = x, Y = y };
                }

            drawLabyrinth.DrawGrid(cellSideSize, rowsCount, columnsCount, pen, graphics);
            stackOfApexes.Push(new Tuple<int, int>(0, 0));
            Maze[0].isVisited = true;
        }

        public void GenerateMaze(int x, int y)
        {
            stackPrevValue = stackOfApexes.Peek();

            drawLabyrinth.DrawPointer(new SolidBrush(Color.DarkViolet),
                                      new Rectangle(x * cellSideSize, y * cellSideSize, cellSideSize - 5, cellSideSize - 5),
                                      graphics);
            Thread.Sleep(50);
            drawLabyrinth.RemoveWallFromLabyrinth(x, y, columnsCount, cellSideSize, Maze, pen, graphics);

            if (stackOfApexes.Count > 0)
            {
                List<int> neighbours = new List<int>();
                neighbours = CheckNeighbours(x, y);

                ChoseNextApex(x, y, neighbours);

                if (stackOfApexes.Count != 0)
                {

                    drawLabyrinth.DrawPointer(new SolidBrush(Form.ActiveForm.BackColor),
                                              new Rectangle(stackPrevValue.Item1 * cellSideSize, stackPrevValue.Item2 * cellSideSize, cellSideSize - 5, cellSideSize - 5),
                                              graphics);

                    GenerateMaze(stackOfApexes.Peek().Item1, stackOfApexes.Peek().Item2);
                }
            }
        }

        private static List<int> CheckNeighbours(int x, int y)
        {
            List<int> neighbours = new List<int>();
            //Проверяем северного(верхнего) соседа
            if (y > 0 && CheckNeighbour(0, -1))
            {
                neighbours.Add(1);
            }
            //Проверяем восточного(правого) соседа
            if (x < rowsCount - 1 && CheckNeighbour(1, 0))
            {
                neighbours.Add(2);
            }
            //Проверяем южного(нижнего) соседа
            if (y < columnsCount - 1 && CheckNeighbour(0, 1))
            {
                neighbours.Add(3);
            }
            //Проверяем западного(левого) соседа
            if (x > 0 && CheckNeighbour(-1, 0))
            {
                neighbours.Add(4);
            }

            return neighbours;
        }

        private static void ChoseNextApex(int x, int y, List<int> neighbours)
        {
            if (neighbours.Count > 0)
            {
                var nextCellNumber = neighbours[randomValue.Next(neighbours.Count)];

                switch (nextCellNumber)
                {
                    case 1://север(верх)
                        Maze[y * columnsCount + x].cellWalls[0] = false;
                        Maze[(y - 1) * columnsCount + x].isVisited = true;
                        Maze[(y - 1) * columnsCount + x].cellWalls[2] = false;
                        stackOfApexes.Push(new Tuple<int, int>(x, y - 1));
                        break;
                    case 2://восток(право)
                        Maze[y * columnsCount + x].cellWalls[1] = false;
                        Maze[y * columnsCount + (x + 1)].isVisited = true;
                        Maze[y * columnsCount + (x + 1)].cellWalls[3] = false;
                        stackOfApexes.Push(new Tuple<int, int>(x + 1, y));
                        break;
                    case 3://юг(низ)
                        Maze[y * columnsCount + x].cellWalls[2] = false;
                        Maze[(y + 1) * columnsCount + x].isVisited = true;
                        Maze[(y + 1) * columnsCount + x].cellWalls[0] = false;
                        stackOfApexes.Push(new Tuple<int, int>(x, y + 1));
                        break;
                    case 4://запад(лево)
                        Maze[y * columnsCount + x].cellWalls[3] = false;
                        Maze[y * columnsCount + (x - 1)].isVisited = true;
                        Maze[y * columnsCount + (x - 1)].cellWalls[1] = false;
                        stackOfApexes.Push(new Tuple<int, int>(x - 1, y));
                        break;
                    default:
                        break;
                }
            }
            else
            {
                stackOfApexes.Pop();
            }
        }


        public static bool CheckNeighbour(int x, int y)
        {
            return (Maze[(y + stackOfApexes.Peek().Item2) * columnsCount + (stackOfApexes.Peek().Item1 + x)].isVisited == false);
        }
    }
}
