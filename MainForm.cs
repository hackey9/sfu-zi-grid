using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabGrid
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private ICryptoGrid Crypto { get; } = new CryptoGrid();

        private byte[,]? _grid = null;
        private byte[]? _order = new byte[] {1, 2, 3, 4};
        
        private void GenerateButton_Click(object sender, EventArgs e)
        {
            var width = int.Parse(WidthInput.Text);
            var height = int.Parse(HeightInput.Text);

            _grid = Crypto.GenerateNewGrid(width, height, _order!);

            var serializedGrid = Crypto.Serialize(_grid, _order);

            GridInput.Text = serializedGrid;

            RenderGrid();
        }

        private void RenderGrid()
        {
            var map = _grid!;
            var height = map.GetLength(0);
            var width = map.GetLength(1);
            var rotation = _order![0];
            
            GridImage.SuspendLayout();

            using var g = GridImage.CreateGraphics();

            using var pen = new Pen(Color.Black);
            var w = 14;
            var h = 14;

            g.Clear(Color.White);

            for (var i = 0; i < width; i++)
            {
                var x = 5 + i * 15;

                for (var j = 0; j < height; j++)
                {
                    var y = 5 + j * 15;

                    if (map[j, i] == rotation)
                    {
                        g.FillRectangle(Brushes.Black, x, y, w, h);
                    }
                    else
                    {
                        g.DrawRectangle(pen, x, y, w - 1, h - 1);
                    }
                }
            }

            GridImage.ResumeLayout();
        }

        private void SetGridButton_Click(object sender, EventArgs e)
        {
            var serializedGrid = GridInput.Text;

            _grid = Crypto.Deserialize(serializedGrid, out _order);

            HeightInput.Text = _grid.GetLength(0).ToString();
            WidthInput.Text = _grid.GetLength(1).ToString();

            RenderGrid();
        }

        private void Encrypt_Click(object sender, EventArgs e)
        {
            var message = MessageTextInput.Text;

            var encrypted = Crypto.Encrypt(message, _grid!, _order!);

            MessageTextInput.Text = "";
            EncryptedTextInput.Text = encrypted.Replace('\0', '_');
        }

        private void Decrypt_Click(object sender, EventArgs e)
        {
            var encrypted = EncryptedTextInput.Text;

            var message = Crypto.Decrypt(encrypted, _grid!, _order!);

            MessageTextInput.Text = message.Replace('\0', '_');
            EncryptedTextInput.Text = "";
        }
    }
}
