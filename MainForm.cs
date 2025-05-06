using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Task6_Algorithms
{
    internal partial class MainForm : Form
    {
        private int _gridSize;
        private List<Point> _path = new List<Point>();
        private int _currentDrawingIndex;
        private int _cellSize;
        private int _offsetX;
        private int _offsetY;
        private int _dotSize = 12;

        internal MainForm() => InitializeComponent();

        private void delayNumericUpDown_ValueChanged(object sender, EventArgs e) => _drawingTimer.Interval = (int)delayNumericUpDown.Value;

        private void gridSizeNumericUpDown_ValueChanged(object sender, EventArgs e) => InitializeDrawing();

        private void MainForm_Load(object sender, EventArgs e) => InitializeDrawing();

        private void InitializeDrawing()
        {
            _gridSize = (int)gridSizeNumericUpDown.Value;
            _currentDrawingIndex = 0;
        }

        private void startGreedyAlgorithmButton_Click(object sender, EventArgs e)
        {
         //   InitializeDrawing();
          //  _path = GenerateGreedyPath(_gridSize);
          //  _drawingTimer.Start();
          //  drawingPanel.Invalidate();
        }

        private void startDynamicProgrammingAlgorithmButton_Click(object sender, EventArgs e)
        {
            InitializeDrawing();
            _path = GenerateDynamicProgrammingPath(_gridSize);
            _drawingTimer.Start();
            drawingPanel.Invalidate();
        }
        private List<Point> GenerateDynamicProgrammingPath(int gridSize)
        {
            // DP table to store the minimum lines required to cover (0,0) to (i,j)
            int[,] dp = new int[gridSize + 1, gridSize + 1];

            // Parent array to help in reconstructing the path
            Point[,] parent = new Point[gridSize + 1, gridSize + 1];

            // Initialize the DP table with large values
            for (int i = 0; i <= gridSize; i++)
            {
                for (int j = 0; j <= gridSize; j++)
                {
                    dp[i, j] = int.MaxValue; // Initialize to infinity
                }
            }

            // Base case: No lines needed to cover (0,0)
            dp[0, 0] = 0;

            // Fill the DP table
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    // Consider adding a horizontal line at row i
                    if (dp[i + 1, j] > dp[i, j] + 1)
                    {
                        dp[i + 1, j] = dp[i, j] + 1;
                        parent[i + 1, j] = new Point(i, j); // Parent is the current point
                    }

                    // Consider adding a vertical line at column j
                    if (dp[i, j + 1] > dp[i, j] + 1)
                    {
                        dp[i, j + 1] = dp[i, j] + 1;
                        parent[i, j + 1] = new Point(i, j); // Parent is the current point
                    }
                }
            }

            // Reconstruct the path from the DP table
            List<Point> path = new List<Point>();
            Point current = new Point(gridSize, gridSize);

            // Backtrack to reconstruct the sequence of lines
            while (current.X != 0 || current.Y != 0)
            {
                path.Add(current);
                current = parent[current.X, current.Y]; // Move to the parent point
            }

            path.Add(new Point(0, 0));  // Add the starting point
            path.Reverse();  // Reverse the path to get it from (0,0) to (n-1,n-1)

            return path;
        }


        private void DrawingTimer_Tick(object sender, EventArgs e)
        {
            if (_currentDrawingIndex < _path.Count - 1)
            {
                _currentDrawingIndex++;

                if (_currentDrawingIndex < _path.Count)
                {
                    var prev = _path[_currentDrawingIndex - 1];
                    var curr = _path[_currentDrawingIndex];

                    var minX = Math.Min(prev.X, curr.X);
                    var minY = Math.Min(prev.Y, curr.Y);
                    var maxX = Math.Max(prev.X, curr.X);
                    var maxY = Math.Max(prev.Y, curr.Y);

                    var invalidateRect = new Rectangle(
                        minX * _cellSize + _offsetX - _dotSize,
                        minY * _cellSize + _offsetY - _dotSize,
                        (maxX - minX + 1) * _cellSize + _dotSize * 2,
                        (maxY - minY + 1) * _cellSize + _dotSize * 2
                    );

                    drawingPanel.Invalidate(invalidateRect);
                }
            }
            else
            {
                _drawingTimer.Stop();
            }
        }

        private void DrawGridDots(Graphics g)
        {
            using Brush dotBrush = new SolidBrush(Color.White);
            for (var y = 0; y < _gridSize; y++)
            {
                for (var x = 0; x < _gridSize; x++)
                {
                    var px = x * _cellSize + _offsetX;
                    var py = y * _cellSize + _offsetY;
                    g.FillEllipse(dotBrush, px - _dotSize / 2, py - _dotSize / 2, _dotSize, _dotSize);
                }
            }
        }

        private void drawingPanel_Paint(object sender, PaintEventArgs e)
        {
            if (_gridSize <= 2)
            {
                return;
            }

            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            var panelWidth = drawingPanel.ClientSize.Width;
            var panelHeight = drawingPanel.ClientSize.Height;
            var marginRatio = 0.7f;
            _cellSize = (int)(Math.Min(panelWidth, panelHeight) * marginRatio / (_gridSize - 1));
            var gridPixelWidth = (_gridSize - 1) * _cellSize;
            var gridPixelHeight = (_gridSize - 1) * _cellSize;
            _offsetX = (panelWidth - gridPixelWidth) / 2;
            _offsetY = (panelHeight - gridPixelHeight) / 2;
            _dotSize = Math.Max(4, _cellSize / 5);

            DrawGridDots(g);

            if (_path.Count > 0 && _currentDrawingIndex > 0)
            {
                using var pathPen = new Pen(Color.Blue, 3);
                for (var i = 0; i < _currentDrawingIndex && i < _path.Count - 1; i++)
                {
                    var p1 = new Point(_path[i].X * _cellSize + _offsetX, _path[i].Y * _cellSize + _offsetY);
                    var p2 = new Point(_path[i + 1].X * _cellSize + _offsetX, _path[i + 1].Y * _cellSize + _offsetY);
                    g.DrawLine(pathPen, p1, p2);
                }
            }

            if (_currentDrawingIndex >= _path.Count)
            {
                return;
            }

            var current = _path[_currentDrawingIndex];
            var x = current.X * _cellSize + _offsetX;
            var y = current.Y * _cellSize + _offsetY;

            using Brush currentBrush = new SolidBrush(Color.Red);
            g.FillEllipse(currentBrush, x - _dotSize / 2, y - _dotSize / 2, _dotSize, _dotSize);
        }
    }
}
