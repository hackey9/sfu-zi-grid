using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabGrid
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var crypto = new CryptoGrid();
            var message = "message_1234";
            var grid = new byte[,]
            {
                {1, 1, 2, 2},
                {1, 2, 1, 2},
                {4, 3, 2, 3},
                {4, 4, 3, 3}
            };
            var order = new byte[] {1, 2, 3, 4};
            var height = grid.GetLength(0);
            var width = grid.GetLength(1);
            grid = crypto.GenerateNewGrid(width, height, order);
            
            var rect = crypto.WriteToRect(message, width, height);

            var encrypted = crypto.ReadFromGrid(rect, grid, order);
            var decrypted = crypto.WriteToGrid(encrypted, grid, order);

            var text = crypto.ReadFromRect(decrypted);
            
            Debug.Assert(message == text);

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}