using System.Collections.Generic;

using GameAPI;
using GameAPI.BudgetBoy;

namespace Games.TestGame
{
    public class Map
    {
        public Map(){}

        public string[] usedMap { get; set; }

        public void Populate()
        {
            if (usedMap == null) return;

            Wall wall;
            
            char[] itemsOnLine;

            for(int i = 0; i < 15; i++)
            {
                itemsOnLine = usedMap[i].ToCharArray();

                for(int j = 0; j < 15; j++)
                {
                    if(itemsOnLine[j] == '1')
                    {
                        wall = Add(new Wall(), 1);
                        wall.Position = new Vector2f((16f - i) * 16f, j * 16f);
                    }
                }
            }
        }
    }
}