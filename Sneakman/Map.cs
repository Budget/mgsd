using System.Collections.Generic;

using GameAPI;
using GameAPI.BudgetBoy;

namespace Games.TestGame
{
    public class Map : MapManager
    {
        public Map(){}

        public string[] usedMap { get; set; }

        public void Populate()
        {
            if (usedMap == null) return;

            List<GameAPI.BudgetBoy.Entity> entityList;
            
            char[] itemsOnLine;

            for(int i = 0; i < 15; i++)
            {
                itemsOnLine = usedMap[i].ToCharArray();

                for(int j = 0; j < 15; j++)
                {
                    if(itemsOnLine[j] == '1')
                    {
                        entityList.Add(GameAPI.BudgetBoy.Entity.Add(new Wall(), 1))
                                  .Position = new Vector2f((16f - i) * 16f, j * 16f);
                    }
                }
            }
        }
    }
}