using System;

using GameAPI;

namespace Games.TestGame
{
    public static class MapLoader
    {
        public static string[] Load(string mapsrc)
        {
            string[] map = System.IO.File.ReadAllLines(mapsrc);

            for (int i = 0; i < 15; i++) //simply ignore whatever comes after line #16
            {
                map[i] = map[i].Replace(",", "");
            }
            return map;
        }
    }
}