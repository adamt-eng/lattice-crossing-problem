namespace Task6_Algorithms
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            startGreedyAlgorithmButton = new System.Windows.Forms.Button();
            drawingPanel = new System.Windows.Forms.Panel();
            numOfPointsLabel = new System.Windows.Forms.Label();
            startDynamicProgrammingAlgorithmButton = new System.Windows.Forms.Button();
            _drawingTimer = new System.Windows.Forms.Timer(components);
            gridSizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            delayNumericUpDown = new System.Windows.Forms.NumericUpDown();
            delayLabel = new System.Windows.Forms.Label();
            lineCountLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)gridSizeNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)delayNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // startGreedyAlgorithmButton
            // 
            startGreedyAlgorithmButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            startGreedyAlgorithmButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            startGreedyAlgorithmButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            startGreedyAlgorithmButton.Location = new System.Drawing.Point(400, 14);
            startGreedyAlgorithmButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            startGreedyAlgorithmButton.Name = "startGreedyAlgorithmButton";
            startGreedyAlgorithmButton.Size = new System.Drawing.Size(206, 77);
            startGreedyAlgorithmButton.TabIndex = 0;
            startGreedyAlgorithmButton.Text = "Start Greedy";
            startGreedyAlgorithmButton.UseVisualStyleBackColor = false;
            startGreedyAlgorithmButton.Click += StartGreedyAlgorithmButton_Click;
            // 
            // drawingPanel
            // 
            drawingPanel.Location = new System.Drawing.Point(13, 151);
            drawingPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            drawingPanel.Name = "drawingPanel";
            drawingPanel.Size = new System.Drawing.Size(1049, 738);
            drawingPanel.TabIndex = 1;
            drawingPanel.Paint += DrawingPanel_Paint;
            // 
            // numOfPointsLabel
            // 
            numOfPointsLabel.Font = new System.Drawing.Font("Segoe UI", 9.857143F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            numOfPointsLabel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            numOfPointsLabel.Location = new System.Drawing.Point(614, 15);
            numOfPointsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            numOfPointsLabel.Name = "numOfPointsLabel";
            numOfPointsLabel.Size = new System.Drawing.Size(149, 35);
            numOfPointsLabel.TabIndex = 2;
            numOfPointsLabel.Text = "# of Points:";
            // 
            // startDynamicProgrammingAlgorithmButton
            // 
            startDynamicProgrammingAlgorithmButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            startDynamicProgrammingAlgorithmButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            startDynamicProgrammingAlgorithmButton.Font = new System.Drawing.Font("Segoe UI", 10F);
            startDynamicProgrammingAlgorithmButton.Location = new System.Drawing.Point(13, 14);
            startDynamicProgrammingAlgorithmButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            startDynamicProgrammingAlgorithmButton.Name = "startDynamicProgrammingAlgorithmButton";
            startDynamicProgrammingAlgorithmButton.Size = new System.Drawing.Size(379, 77);
            startDynamicProgrammingAlgorithmButton.TabIndex = 3;
            startDynamicProgrammingAlgorithmButton.Text = "Start Dynamic Programming";
            startDynamicProgrammingAlgorithmButton.UseVisualStyleBackColor = false;
            startDynamicProgrammingAlgorithmButton.Click += StartDynamicProgrammingAlgorithmButton_Click;
            // 
            // _drawingTimer
            // 
            _drawingTimer.Interval = 250;
            _drawingTimer.Tick += DrawingTimer_Tick;
            // 
            // gridSizeNumericUpDown
            // 
            gridSizeNumericUpDown.Location = new System.Drawing.Point(770, 14);
            gridSizeNumericUpDown.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            gridSizeNumericUpDown.Name = "gridSizeNumericUpDown";
            gridSizeNumericUpDown.Size = new System.Drawing.Size(298, 35);
            gridSizeNumericUpDown.TabIndex = 4;
            gridSizeNumericUpDown.Value = new decimal(new int[] { 4, 0, 0, 0 });
            gridSizeNumericUpDown.ValueChanged += GridSizeNumericUpDown_ValueChanged;
            // 
            // delayNumericUpDown
            // 
            delayNumericUpDown.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            delayNumericUpDown.Location = new System.Drawing.Point(770, 56);
            delayNumericUpDown.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            delayNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            delayNumericUpDown.Name = "delayNumericUpDown";
            delayNumericUpDown.Size = new System.Drawing.Size(298, 35);
            delayNumericUpDown.TabIndex = 6;
            delayNumericUpDown.Value = new decimal(new int[] { 150, 0, 0, 0 });
            delayNumericUpDown.ValueChanged += DelayNumericUpDown_ValueChanged;
            // 
            // delayLabel
            // 
            delayLabel.Font = new System.Drawing.Font("Segoe UI", 9.857143F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            delayLabel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            delayLabel.Location = new System.Drawing.Point(614, 56);
            delayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            delayLabel.Name = "delayLabel";
            delayLabel.Size = new System.Drawing.Size(149, 38);
            delayLabel.TabIndex = 5;
            delayLabel.Text = "Delay (ms):";
            // 
            // lineCountLabel
            // 
            lineCountLabel.Font = new System.Drawing.Font("Segoe UI", 9.857143F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lineCountLabel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            lineCountLabel.Location = new System.Drawing.Point(13, 103);
            lineCountLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lineCountLabel.Name = "lineCountLabel";
            lineCountLabel.Size = new System.Drawing.Size(1055, 43);
            lineCountLabel.TabIndex = 7;
            lineCountLabel.Text = "Line Count: 0";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(33, 33, 33);
            ClientSize = new System.Drawing.Size(1080, 909);
            Controls.Add(lineCountLabel);
            Controls.Add(delayNumericUpDown);
            Controls.Add(delayLabel);
            Controls.Add(gridSizeNumericUpDown);
            Controls.Add(startDynamicProgrammingAlgorithmButton);
            Controls.Add(numOfPointsLabel);
            Controls.Add(drawingPanel);
            Controls.Add(startGreedyAlgorithmButton);
            Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MaximumSize = new System.Drawing.Size(1104, 973);
            Name = "MainForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Task 6";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)gridSizeNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)delayNumericUpDown).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button startGreedyAlgorithmButton;
        private System.Windows.Forms.Panel drawingPanel;
        private System.Windows.Forms.Label numOfPointsLabel;
        private System.Windows.Forms.Button startDynamicProgrammingAlgorithmButton;
        private System.Windows.Forms.Timer _drawingTimer;
        private System.Windows.Forms.NumericUpDown gridSizeNumericUpDown;
        private System.Windows.Forms.NumericUpDown delayNumericUpDown;
        private System.Windows.Forms.Label delayLabel;
        private System.Windows.Forms.Label lineCountLabel;
    }
}

