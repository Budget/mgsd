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
            MapResource map = Main.MapR;
            Debug.Log("Populating...");

            for (int x = 0; x < map.Cols; x++)
            {
                for (int y = 0; y < map.Rows; y++)
                {
                    switch (map.Tiles[x, y])
                    {
                        case '1':
                            tilemap.SetTile(y, map.Cols - 2 - x, _wall, Game.Swatches.Wall);
                            Wall wall = stage.Add(new Wall(), 1);
                            wall.Position = new Vector2f(16 + (x * 16f), (16f - y) * 16f - 16f);
                            Debug.Log("Set wall.");
                            break;
                        case '2':
                            tilemap.SetTile(y, map.Cols - 2 - x, _wallV, Game.Swatches.Wall);
                            Wall wallV = stage.Add(new Wall(), 1);
                            wallV.Position = new Vector2f(16 + (x * 16f), (16f - y) * 16f - 16f);
                            Debug.Log("Set wallV.");
                            break;
                        case '3':
                            tilemap.SetTile(x, map.Cols - 2 - y, _door, Game.Swatches.Door); //Gonna take this back out since door needs to be an entity
                            Debug.Log("Set door.");
                            break;
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