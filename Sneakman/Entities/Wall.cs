using GameAPI;
using GameAPI.BudgetBoy;

namespace Games.TestGame
{
    public class Wall : Entity
    {
        public new Main Game { get { return (Main)base.Game;  } }

        protected Sprite _sprite;

        public Wall(){}

        //called when this entity is added to a stage
        protected override void OnEnterStage(Stage stage)
        {
            base.OnEnterStage(stage);
            var size = new Vector2F(16, 16); //yay hardcoded
            LocalBounds = new RectF(size, size);
        }
    }
}
