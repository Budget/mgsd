using System;

using GameAPI;
using GameAPI.BudgetBoy;

namespace Games.TestGame
{
    public class Wall : Entity
    {
        public new Main Game { get { return (Main)base.Game;  } }

        protected Sprite _sprite;
        public Vector2f _bounds;

        public Wall()
        {            
        }

        //called when this entity is added to a stage
        protected override void OnEnterStage(Stage stage)
        {
            base.OnEnterStage(stage);
        }

        protected override void OnLoadGraphics(Graphics graphics)
        {
            Image image = graphics.GetImage("Resources", "wall");
            _sprite = new Sprite(image, Game.Swatches.Wall);

            // need to set LocalBounds because we draw our own sprites
            var size = (Vector2f)(_sprite.Size * 0.75f);
            LocalBounds = new RectF(-(size / 2), size);
        }        

        protected override void OnRender(Graphics graphics)
        {
            base.OnRender(graphics);

            _sprite.Render(graphics);
        }
    }
}
