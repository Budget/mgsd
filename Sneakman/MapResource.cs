using System;
using System.IO;
using System.Linq;

namespace Games.TestGame
{
    public class MapResource
    {
        public int Rows { get; private set; }
        public int Cols { get; private set; }

        public readonly char[,] Tiles;

        public MapResource(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;

            Tiles = new char[rows, cols];
        }

        public static void Save(Stream stream, MapResource map)
        {
        }

        public static MapResource Load(Stream stream, String extension)
        {
            var reader = new StreamReader(stream);

            string[] lines = reader.ReadToEnd()
                              .Split('\n')
                              .Select(x => x.Trim(','))
                              .Where(x => x.Length > 0)
                              .ToArray();

            for(int i = 0; i < lines.Length - 1; i++)
            {
                lines[i] = lines[i].Replace(",", "");
            }

            var rows = lines.Length;

            var cols = lines.Max(x => x.Length);

            var map = new MapResource(rows, cols);

            var X = 0;
            foreach (var line in lines)
            {
                var Y = 0;
                foreach (var character in line)
                {
                    map.Tiles[X, Y] = character;
                    Y++;
                }
                X++;
            }

            return map;
        }

    }
}
