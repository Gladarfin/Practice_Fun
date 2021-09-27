using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace MazeGeneratorWF
{
    public partial class MazeGenerator : Form
    {
        public MazeGenerator()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            windowSideSize = Convert.ToInt32(nLabyrinthWindowSize.Value);
            cellSideSize = Convert.ToInt32(nCellSideSize.Value);
            SaveSettings();
            MazeGeneratorBaseClass mazeGenerator = new MazeGeneratorBaseClass();
            mazeGenerator.InitializeVariables();
            mazeGenerator.GenerateMaze(0, 0);
        }


        private int windowSideSize;
        private int cellSideSize;        
        
        private void MazeGenerator_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
            Close();
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.LabCellSideSize = cellSideSize;
            Properties.Settings.Default.LabyrinthWinSize = windowSideSize;
            Properties.Settings.Default.Save();
        }
    }
}
