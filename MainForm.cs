﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Task_6_Algorithms_Project;

internal partial class MainForm : Form
{
    private int _gridSize;
    private List<Point> _path = [];
    private int _currentDrawingIndex;
    private int _cellSize;
    private int _offsetX;
    private int _offsetY;
    private int _dotSize = 12;
    private readonly Dictionary<(int, int), List<Point>> _dpMemo = [];

    internal MainForm() => InitializeComponent();
    private void MainForm_Load(object sender, EventArgs e) => InitializeDrawing();
    private void DelayNumericUpDown_ValueChanged(object sender, EventArgs e) => _drawingTimer.Interval = (int)delayNumericUpDown.Value;
    private void GridSizeNumericUpDown_ValueChanged(object sender, EventArgs e) => InitializeDrawing();

    private void InitializeDrawing()
    {
        _gridSize = (int)gridSizeNumericUpDown.Value;
        _currentDrawingIndex = 0;
        lineCountLabel.Text = $"Line Count: 0 (Required: {2 * _gridSize - 1})";
    }

    private void Start(List<Point> path)
    {
        InitializeDrawing();

        _path = path;

        var lineCount = 1;
        if (path.Count > 1)
        {
            for (var i = 1; i < path.Count - 1; i++)
            {
                var p1 = path[i - 1];
                var p2 = path[i];
                var p3 = path[i + 1];

                // Check if points are co-linear
                if ((p2.Y - p1.Y) * (p3.X - p2.X) != (p3.Y - p2.Y) * (p2.X - p1.X))
                {
                    lineCount++;
                }
            }
        }
        else
        {
            lineCount = 0;
        }

        lineCountLabel.Text = $"Line Count: {lineCount} (Required: {2 * _gridSize - 1})";

        _drawingTimer.Start();
        drawingPanel.Invalidate();
    }

    private void StartGreedyAlgorithmButton_Click(object sender, EventArgs e) => Start(GenerateGreedyPath_Spiral(_gridSize));
    private void StartDynamicProgrammingAlgorithmButton_Click(object sender, EventArgs e) => Start(GenerateDynamicProgrammingPath(_gridSize));

    private List<Point> GenerateDynamicProgrammingPath(int n)
    {
        _dpMemo.Clear();
        return SolveDp(0, 0, n, n);
    }

    private List<Point> SolveDp(int startX, int startY, int width, int height)
    {
        var key = (width, height);
        if (_dpMemo.TryGetValue(key, out var value))
        {
            return OffsetPath(value, startX, startY);
        }

        List<Point> path = [];

        // Base case: small grid
        if (width <= 2 || height <= 2)
        {
            for (var i = 0; i < height; i++)
            {
                if (i % 2 == 0)
                {
                    for (var j = 0; j < width; j++)
                    {
                        path.Add(new Point(j, i));
                    }
                }
                else
                {
                    for (var j = width - 1; j >= 0; j--)
                    {
                        path.Add(new Point(j, i));
                    }
                }
            }

            _dpMemo[key] = new List<Point>(path);
            return OffsetPath(path, startX, startY);
        }

        // Trace the outer perimeter first (4 edges)
        // Top row (left to right)
        for (var j = 0; j < width; j++)
        {
            path.Add(new Point(j, 0));
        }

        // Right column (top to bottom, excluding top-right corner)
        for (var i = 1; i < height; i++)
        {
            path.Add(new Point(width - 1, i));
        }

        // Bottom row (right to left, excluding bottom-right corner)
        for (var j = width - 2; j >= 0; j--)
        {
            path.Add(new Point(j, height - 1));
        }

        // Left column (bottom to top, excluding bottom-left corner)
        for (var i = height - 2; i > 0; i--)
        {
            path.Add(new Point(0, i));
        }

        // Recursively solve the inner grid
        var inner = SolveDp(1, 1, width - 2, height - 2);
        path.AddRange(inner);

        _dpMemo[key] = new List<Point>(path.Select(p => new Point(p.X - startX, p.Y - startY)));
        return OffsetPath(path, startX, startY);

        static List<Point> OffsetPath(List<Point> path, int offsetX, int offsetY) => path.Select(p => new Point(p.X + offsetX, p.Y + offsetY)).ToList();
    }

    private static List<Point> GenerateGreedyPath_Spiral(int n)
    {
        List<Point> path = [];
        switch (n)
        {
            case <= 0: return path;
            case 1: path.Add(new Point(0, 0)); return path;
        }

        // visited array can be useful for more complex greedy, but for a simple spiral,
        // changing bounds is enough. For this problem, all points must be visited.
        // bool[,] visited = new bool[n, n]; 

        int x = 0, y = 0;
        int minRow = 0, maxRow = n - 1;
        int minCol = 0, maxCol = n - 1;

        path.Add(new Point(x, y)); // Starting point

        while (minRow <= maxRow && minCol <= maxCol)
        {
            // 1. Traverse Right (Top row of current subgrid)
            // Ensure we don't re-add the very first point if it's not the absolute start
            if (path.Last().X == minCol && path.Last().Y == minRow && (x != minCol || y != minRow))
            {
                // This condition is tricky; simpler to just ensure x,y are at start of segment
            }

            x = path.Last().X;
            y = path.Last().Y;

            // If we are at the start of this segment, the first point is already added (or is the path start)
            // So, loop from the next point onwards.
            // However, if the path is just one point (initial state), we start from that point.

            if (y == minRow && x < maxCol) // Only if there's space to move right
            {
                for (x = path.Last().X + 1; x <= maxCol; x++)
                    path.Add(new Point(x, y));
            }
            minRow++;
            if (!(minRow <= maxRow && minCol <= maxCol)) break;

            // 2. Traverse Down (Rightmost col of current subgrid)
            x = path.Last().X; // update current x
            if (x == maxCol && path.Last().Y < maxRow) // Only if there's space to move down
            {
                for (y = path.Last().Y + 1; y <= maxRow; y++)
                {
                    path.Add(new Point(x, y));
                }
            }
            maxCol--;
            if (!(minRow <= maxRow && minCol <= maxCol)) break;

            // 3. Traverse Left (Bottom row of current subgrid)
            y = path.Last().Y; // update current y
            if (y == maxRow && path.Last().X > minCol) // Only if there's space to move left
            {
                for (x = path.Last().X - 1; x >= minCol; x--)
                {
                    path.Add(new Point(x, y));
                }
            }
            maxRow--;
            if (!(minRow <= maxRow && minCol <= maxCol)) break;

            // 4. Traverse Up (Leftmost col of current subgrid)
            x = path.Last().X; // update current x
            if (x == minCol && path.Last().Y > minRow) // Only if there's space to move up
            {
                for (y = path.Last().Y - 1; y >= minRow; y--)
                {
                    path.Add(new Point(x, y));
                }
            }
            minCol++;
        }

        return path;
    }

    private void DrawingTimer_Tick(object sender, EventArgs e)
    {
        startDynamicProgrammingAlgorithmButton.Enabled = false;
        startGreedyAlgorithmButton.Enabled = false;
        gridSizeNumericUpDown.Enabled = false;

        if (_currentDrawingIndex < _path.Count - 1)
        {
            var prev = _path[_currentDrawingIndex];
            var curr = _path[_currentDrawingIndex + 1];

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
            _currentDrawingIndex++;
        }
        else
        {
            _drawingTimer.Stop();

            startDynamicProgrammingAlgorithmButton.Enabled = true;
            startGreedyAlgorithmButton.Enabled = true;
            gridSizeNumericUpDown.Enabled = true;
        }
    }
    private void DrawingPanel_Paint(object sender, PaintEventArgs e)
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

        using Brush dotBrush = new SolidBrush(Color.White);
        for (var yG = 0; yG < _gridSize; yG++)
        {
            for (var xG = 0; xG < _gridSize; xG++)
            {
                var px = xG * _cellSize + _offsetX;
                var py = yG * _cellSize + _offsetY;
                g.FillEllipse(dotBrush, px - _dotSize / 2, py - _dotSize / 2, _dotSize, _dotSize);
            }
        }

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