using GameAPI;
using GameAPI.BudgetBoy;

namespace Games.TestGame
{
    public class Map : Entity
    {
        public new Main Game { get { return (Main)base.Game; } }

        Tilemap tilemap = new Tilemap(new Vector2i(16, 16), new Vector2i(15, 15) );

        public Map() { }

        public string[] usedMap { get; set; }

        public void Populate(Stage stage)
        {
            Debug.Log("Populating...");
            if (usedMap == null) return;

            for (int y = 0; y < 15; y++)
            {
                char[] itemsOnLine = usedMap[y].ToCharArray();

                for (int x = 0; x < 15; x++)
                {
                    switch (itemsOnLine[x])
                    {
                        case '1':
                            tilemap.SetTile(x, 14 - y, _wall, Game.Swatches.Wall);
                            Wall wall = stage.Add(new Wall(), 1);
                            wall.Position = new Vector2f(16 + (x * 16f), (16f - y) * 16f - 16f);
                            Debug.Log("Set wall.");
                            break;
                        case '2':
                            tilemap.SetTile(x, 14 - y, _wallV, Game.Swatches.Wall);
                            Wall wallV = stage.Add(new Wall(), 1);
                            wallV.Position = new Vector2f(16 + (x * 16f), (16f - y) * 16f - 16f);
                            Debug.Log("Set wallV.");
                            break;
                        case '3':
                            tilemap.SetTile(x, 14 - y, _door, Game.Swatches.Door); //Gonna take this back out since door needs to be an entity
                            Debug.Log("Set door.");
                            break;
                        /*
                        case '1':
                            Wall wall = stage.Add(new Wall(), 1);
                            wall.Position = new Vector2f(16 + (x * 16f), (16f - y) * 16f - 16f);
                            break;
                        case '2':
                            Wall_v wallV = stage.Add(new Wall_v(), 1);
                            wallV.Position = new Vector2f(16 + (x * 16f), (16f - y) * 16f - 16f);
                            break;
                        case '3':
                            Door door = stage.Add(new Door(), 1);
                            door.Position = new Vector2f(16 + (x * 16f), (16f - y) * 16f - 16f);
                            break; 
                         */
                    }
                }
            }
        }

        protected override void OnEnterStage(Stage stage)
        {
            base.OnEnterStage(stage);
        }

        protected override void OnRender(Graphics graphics)
        {
            base.OnRender(graphics);

            tilemap.Render(graphics);
        }

        private Image _wall;
        private Image _wallV;
        private Image _door;
        protected override void OnLoadGraphics(Graphics graphics)
        {
            _wall = Game.Graphics.GetImage("Resources", "wall");
            _wallV = Game.Graphics.GetImage("Resources", "wall_v");
            _door = Game.Graphics.GetImage("Resources", "door");
        }
    }
}