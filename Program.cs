using System;
using System.Windows.Forms;

namespace Task_6_Algorithms_Project;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
}