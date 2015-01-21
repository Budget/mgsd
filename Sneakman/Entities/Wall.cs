using System;

using GameAPI;
using GameAPI.BudgetBoy;

namespace Games.TestGame
{
    public class Wall : Entity
    {
        public new Main Game { get { return (Main)base.Game;  } }

        protected Sprite _sprite;

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
            var size = (Vector2f)(_sprite.Size);
            LocalBounds = new RectF(size , size);
        }

        protected override void OnUpdate(double dt)
        {
            base.OnUpdate(dt);
        }

        protected override void OnRender(Graphics graphics)
        {
            base.OnRender(graphics);

            CenterSprite(_sprite);
            _sprite.Render(graphics);
        }

        private void CenterSprite(Sprite sprite)
        {
            var rotation = sprite.Rotation;
            Vector2i size;

            if (rotation == 0 || rotation == 2) // horizontal
            {
                size = sprite.Size;
            }
            else // vertical
            {
                size = new Vector2i(sprite.Height, sprite.Width);
            }

            sprite.Position = (Vector2i)Position - (size);
        }
    }
}
