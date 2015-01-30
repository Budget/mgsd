using GameAPI;
using GameAPI.BudgetBoy;

namespace Games.TestGame
{
    public class GameStage : Stage
    {
        public new Main Game { get { return (Main) base.Game; } }
        
        // called when this stage is created
        public GameStage(Main game) : base(game)
        {
            
        }

        // called when this stage is entered
        protected override void OnEnter()
        {
            Debug.Log("In GameStage");
            Graphics.SetClearColor(Game.Swatches.ClearColor);

            float Padding = 20.0f; //just test shit k

            /*
            Wall wall = Add(new Wall(), 1);
            wall.Position = new Vector2F(Padding, Padding);
            Debug.Log("Wall created");*/


            Map testMap = Add(new Map(), 1);
            testMap.Populate(this);

            Player player = Add(new Player(), 1);
            player.Position = new Vector2F(Padding * 2, Padding * 3);
            Debug.Log("Player created");
        }

        // called each tick
        protected override void OnUpdate()
        {
            base.OnUpdate();
        }

        // called when this stage is rendered
        protected override void OnRender()
        {
            base.OnRender();

        }
    }
}
