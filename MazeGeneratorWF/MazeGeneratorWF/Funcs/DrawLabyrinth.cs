using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeGeneratorWF
{
    public class DrawLabyrinth
    {

        private void Clear(Pen pen, Graphics graphics)
        {
            graphics.FillRectangle(new SolidBrush(Form.ActiveForm.BackColor), new Rectangle(0, 0, 400, 400));
        }
        public void DrawGrid(int cellSideSize, int rowsCount, int columnsCount, Pen pen, Graphics graphics)
        {
            Clear(pen, graphics);
            for (int i = 0; i < rowsCount; i++)
                for (int j = 0; j < columnsCount; j++)
                {
                    graphics.DrawLine(pen, new Point(i * cellSideSize, j * cellSideSize), new Point(i * cellSideSize + cellSideSize, j * cellSideSize));

                    graphics.DrawLine(pen, new Point(i * cellSideSize + cellSideSize, j * cellSideSize + cellSideSize), new Point(i * cellSideSize + cellSideSize, j * cellSideSize));

                    graphics.DrawLine(pen, new Point(i * cellSideSize + cellSideSize, j * cellSideSize + cellSideSize), new Point(i * cellSideSize, j * cellSideSize + cellSideSize));

                    graphics.DrawLine(pen, new Point(i * cellSideSize, j * cellSideSize + cellSideSize), new Point(i * cellSideSize, j * cellSideSize));
                }
        }

        public void RemoveWallFromLabyrinth(int x, int y, int columnsCount, int cellSideSize, Cell[] Maze, Pen pen, Graphics graphics)
        {
            if (Maze[y * columnsCount + x].cellWalls[0])
            {
                pen.Color = Color.Black;
                graphics.DrawLine(pen, new Point(x * cellSideSize, y * cellSideSize), new Point(x * cellSideSize + cellSideSize, y * cellSideSize));
            }
            else
            {
                pen.Color = Form.ActiveForm.BackColor;
                graphics.DrawLine(pen, new Point(x * cellSideSize, y * cellSideSize), new Point(x * cellSideSize + cellSideSize, y * cellSideSize));
            }
            if (Maze[y * columnsCount + x].cellWalls[1])
            {
                pen.Color = Color.Black;
                graphics.DrawLine(pen, new Point(x * cellSideSize + cellSideSize, y * cellSideSize + cellSideSize), new Point(x * cellSideSize + cellSideSize, y * cellSideSize));
            }
            else
            {
                pen.Color = Form.ActiveForm.BackColor;
                graphics.DrawLine(pen, new Point(x * cellSideSize + cellSideSize, y * cellSideSize + cellSideSize), new Point(x * cellSideSize + cellSideSize, y * cellSideSize));
            }
            if (Maze[y * columnsCount + x].cellWalls[2])
            {
                pen.Color = Color.Black;
                graphics.DrawLine(pen, new Point(x * cellSideSize + cellSideSize, y * cellSideSize + cellSideSize), new Point(x * cellSideSize, y * cellSideSize + cellSideSize));
            }
            else
            {
                pen.Color = Form.ActiveForm.BackColor;
                graphics.DrawLine(pen, new Point(x * cellSideSize + cellSideSize, y * cellSideSize + cellSideSize), new Point(x * cellSideSize, y * cellSideSize + cellSideSize));
            }
            if (Maze[y * columnsCount + x].cellWalls[3])
            {
                pen.Color = Color.Black;
                graphics.DrawLine(pen, new Point(x * cellSideSize, y * cellSideSize + cellSideSize), new Point(x * cellSideSize, y * cellSideSize));
            }

            else
            {
                pen.Color = Form.ActiveForm.BackColor;
                graphics.DrawLine(pen, new Point(x * cellSideSize, y * cellSideSize + cellSideSize), new Point(x * cellSideSize, y * cellSideSize));
            }
        }

        public void DrawPointer(SolidBrush sb, Rectangle rect, Graphics graphics)
        {
            graphics.FillEllipse(sb, rect);
        }

    }
}
