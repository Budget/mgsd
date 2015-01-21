using System.Collections.Generic;

using GameAPI;
using GameAPI.BudgetBoy;

namespace Games.TestGame
{
    public class Map
    {
        public Map(){}

        public string[] usedMap { get; set; }

        public void Populate(Stage stage)
        {
            if (usedMap == null) return;

            for(int y = 0; y < 15; y++)
            {
                char[] itemsOnLine = usedMap[y].ToCharArray();

                for(int x = 0; x < 15; x++)
                {
                    switch (itemsOnLine[x])
                    {
                        case '1':
                            Wall wall = stage.Add(new Wall(), 1);
                            wall.Position = new Vector2f(16 + (x * 16f), (16f - y) * 16f - 16f);
                            break;
                        case '2':
                            Wall_v wallV = stage.Add(new Wall_v(), 1);
                            wallV.Position = new Vector2f(16 + (x * 16f), (16f - y) * 16f - 16f);
                            break;
                    }
                }
            }
        }
    }
}