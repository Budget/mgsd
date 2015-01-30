using GameAPI;
using GameAPI.BudgetBoy;

namespace Games.TestGame
{
    public class Door : Entity
    {
        public new Main Game { get { return (Main)base.Game; } }

        protected Sprite _sprite;

        public enum Orientation
        {
            Top,
            Right,
            Bottom,
            Left
        }

        private Orientation _reqOri;

        public Door()
        {
            //_reqOri = ori;
        }

        //called when this entity is added to a stage
        protected override void OnEnterStage(Stage stage)
        {
            base.OnEnterStage(stage);
        }

        protected override void OnLoadGraphics(Graphics graphics)
        {
            Image image = graphics.GetImage("Resources/door");
            _sprite = new Sprite(image, Game.Swatches.Door);
            
            // need to set LocalBounds because we draw our own sprites
            var size = (Vector2F)(_sprite.Size);
            LocalBounds = new RectF(size, size);
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
            //var rotation = sprite.Rotation;
            Vector2I size;

            //if (rotation == 0 || rotation == 2) // horizontal
            //{
            size = sprite.Size;
            //}
            //else // vertical
            //{
            //    size = new Vector2I(sprite.Height, sprite.Width);
            //}

            sprite.Position = (Vector2I)Position - (size / 2);
        }
    }
}
