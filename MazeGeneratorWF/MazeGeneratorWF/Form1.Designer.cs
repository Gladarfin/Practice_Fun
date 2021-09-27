
namespace MazeGeneratorWF
{
    partial class MazeGenerator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nCellSideSize = new System.Windows.Forms.NumericUpDown();
            this.nLabyrinthWindowSize = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nCellSideSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nLabyrinthWindowSize)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(487, 414);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "Generate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(418, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Длина стороны окна:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(421, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Размер ячейки:";
            // 
            // nCellSideSize
            // 
            this.nCellSideSize.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::MazeGeneratorWF.Properties.Settings.Default, "LabCellSideSize", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nCellSideSize.Location = new System.Drawing.Point(425, 111);
            this.nCellSideSize.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nCellSideSize.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nCellSideSize.Name = "nCellSideSize";
            this.nCellSideSize.Size = new System.Drawing.Size(151, 20);
            this.nCellSideSize.TabIndex = 3;
            this.nCellSideSize.Value = global::MazeGeneratorWF.Properties.Settings.Default.LabCellSideSize;
            // 
            // nLabyrinthWindowSize
            // 
            this.nLabyrinthWindowSize.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::MazeGeneratorWF.Properties.Settings.Default, "LabyrinthWinSize", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nLabyrinthWindowSize.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nLabyrinthWindowSize.Location = new System.Drawing.Point(425, 45);
            this.nLabyrinthWindowSize.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.nLabyrinthWindowSize.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nLabyrinthWindowSize.Name = "nLabyrinthWindowSize";
            this.nLabyrinthWindowSize.Size = new System.Drawing.Size(150, 20);
            this.nLabyrinthWindowSize.TabIndex = 2;
            this.nLabyrinthWindowSize.Value = global::MazeGeneratorWF.Properties.Settings.Default.LabyrinthWinSize;
            // 
            // MazeGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 461);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nCellSideSize);
            this.Controls.Add(this.nLabyrinthWindowSize);
            this.Controls.Add(this.button1);
            this.Name = "MazeGenerator";
            this.Text = "MazeGenerator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MazeGenerator_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nCellSideSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nLabyrinthWindowSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown nLabyrinthWindowSize;
        private System.Windows.Forms.NumericUpDown nCellSideSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

