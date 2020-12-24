using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace LabGrid
{
    public interface ICryptoGrid
    {
        char[,] WriteToRect(string text, int width, int height);

        string ReadFromGrid(char[,] rect, byte[,] grid, byte[] order);

        char[,] WriteToGrid(string text, byte[,] grid, byte[] order);

        string ReadFromRect(char[,] rect);

        byte[,] GenerateNewGrid(int width, int height, byte[] order);

        string Serialize(byte[,] grid, byte[] order);

        byte[,] Deserialize(string serializedGrid, out byte[] order);
        
        string Encrypt(string message, byte[,] grid, byte[] order)
        {
            var height = grid.GetLength(0);
            var width = grid.GetLength(1);
            
            var rect = WriteToRect(message, width, height);
            return ReadFromGrid(rect, grid, order);
        }

        string Decrypt(string encrypted, byte[,] grid, byte[] order)
        {
            var decrypted = WriteToGrid(encrypted, grid, order);

            return ReadFromRect(decrypted);
        }
    }

    public class CryptoGrid : ICryptoGrid
    {
        public char[,] WriteToRect(string text, int width, int height)
        {
            text = text.PadRight(width * height, '\0');
            var rect = new char[height, width];

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    var i = y * width + x;
                    rect[y, x] = text[i];
                }
            }

            return rect;
        }

        public string ReadFromRect(char[,] rect)
        {
            var height = rect.GetLength(0);
            var width = rect.GetLength(1);

            var sb = new StringBuilder(width * height, width * height);

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    sb.Append(rect[y, x]);
                }
            }

            return sb.ToString().TrimEnd('\0');
        }

        public byte[,] GenerateNewGrid(int width, int height, byte[] order)
        {
            var grid = new byte[height, width];

            for (var y = 0; y < height / 2; y++)
            {
                for (var x = 0; x < width / 2; x++)
                {
                    var randIndex = Random.Next(0, 4);
                    Debug.Assert(randIndex < 4);
                    var rotation = order[randIndex];
                    grid[y, x] = rotation;

                    //continue;
                    if (rotation == order[0])
                    {
                        grid[y, width - x - 1] = order[1];
                        grid[height - y - 1, width - x - 1] = order[2];
                        grid[height - y - 1, x] = order[3];
                    }

                    if (rotation == order[1])
                    {
                        grid[y, width - x - 1] = order[0];
                        grid[height - y - 1, width - x - 1] = order[3];
                        grid[height - y - 1, x] = order[2];
                    }

                    if (rotation == order[2])
                    {
                        grid[y, width - x - 1] = order[3];
                        grid[height - y - 1, width - x - 1] = order[0];
                        grid[height - y - 1, x] = order[1];
                    }

                    if (rotation == order[3])
                    {
                        grid[y, width - x - 1] = order[2];
                        grid[height - y - 1, width - x - 1] = order[1];
                        grid[height - y - 1, x] = order[0];
                    }
                }
            }

            return grid;
        }

        public string Serialize(byte[,] grid, byte[] order)
        {
            var height = grid.GetLength(0);
            var width = grid.GetLength(1);
            using var stream = new MemoryStream();
            using var writer = new BinaryWriter(stream, Encoding.UTF8);

            writer.Write(width);
            writer.Write(height);

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    writer.Write(grid[y, x]);
                }
            }

            writer.Flush();

            return Convert.ToBase64String(stream.ToArray(), Base64FormattingOptions.None);
        }

        public byte[,] Deserialize(string serializedGrid, out byte[] order)
        {
            var keyBytes = Convert.FromBase64String(serializedGrid);
            using var stream = new MemoryStream(keyBytes);
            using var reader = new BinaryReader(stream);

            var width = reader.ReadInt32();
            var height = reader.ReadInt32();

            var grid = new byte[height, width];

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    grid[y, x] = reader.ReadByte();
                }
            }

            order = new byte[] {1, 2, 3, 4};
            return grid;
        }

        private Random Random { get; } = new();

        public string ReadFromGrid(char[,] rect, byte[,] grid, byte[] order)
        {
            var grid1 = RotateGrid(grid, order[0]);
            var grid2 = RotateGrid(grid, order[1]);
            var grid3 = RotateGrid(grid, order[2]);
            var grid4 = RotateGrid(grid, order[3]);

            var height = rect.GetLength(0);
            var width = rect.GetLength(1);

            var sb = new StringBuilder(width * height);

            sb.Append(ReadFromGrid(rect, grid1));
            sb.Append(ReadFromGrid(rect, grid2));
            sb.Append(ReadFromGrid(rect, grid3));
            sb.Append(ReadFromGrid(rect, grid4));

            return sb.ToString().TrimEnd('\0');
        }

        private static string ReadFromGrid(char[,] rect, bool[,] grid)
        {
            var height = grid.GetLength(0);
            var width = grid.GetLength(1);

            var sb = new StringBuilder(width * height / 4);

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    if (grid[y, x])
                    {
                        sb.Append(rect[y, x]);
                    }
                }
            }

            return sb.ToString();
        }

        private static bool[,] RotateGrid(byte[,] grid, byte rotation)
        {
            var height = grid.GetLength(0);
            var width = grid.GetLength(1);

            var rotated = new bool[height, width];

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    if (grid[y, x] == rotation)
                    {
                        rotated[y, x] = true;
                    }
                }
            }

            return rotated;
        }

        public char[,] WriteToGrid(string text, byte[,] grid, byte[] order)
        {
            var grid1 = RotateGrid(grid, order[0]);
            var grid2 = RotateGrid(grid, order[1]);
            var grid3 = RotateGrid(grid, order[2]);
            var grid4 = RotateGrid(grid, order[3]);

            var height = grid.GetLength(0);
            var width = grid.GetLength(1);
            var length = width * height;
            text = text.PadRight(length, '\0');

            var text1 = text[0..(length / 4)];
            var text2 = text[(length / 4)..(length / 2)];
            var text3 = text[(length / 2)..(3 * length / 4)];
            var text4 = text[(3 * length / 4)..];

            var rect = new char[height, width];

            var i1 = 0;
            var i2 = 0;
            var i3 = 0;
            var i4 = 0;
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    if (grid1[y, x])
                    {
                        rect[y, x] = text1[i1++];
                    }

                    if (grid2[y, x])
                    {
                        rect[y, x] = text2[i2++];
                    }

                    if (grid3[y, x])
                    {
                        rect[y, x] = text3[i3++];
                    }

                    if (grid4[y, x])
                    {
                        rect[y, x] = text4[i4++];
                    }
                }
            }

            return rect;
        }
    }
}