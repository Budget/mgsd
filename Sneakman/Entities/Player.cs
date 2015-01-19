using System;
using System.Collections;

using GameAPI;
using GameAPI.BudgetBoy;

namespace Games.TestGame
{
    public class Player : Entity
    {
        public new Main Game { get { return (Main) base.Game; } }

        protected Sprite _sprite;
       
        public Player()
        {
            
        }

        // called when this entity is added to a stage
        protected override void OnEnterStage(Stage stage)
        {
            base.OnEnterStage(stage);

            StartCoroutine(RotCoro);
        }

        protected override void OnLoadGraphics(Graphics graphics)
        {
            Image image = graphics.GetImage("Resources", "player");
            _sprite = new Sprite(image, Game.Swatches.Player);

            // need to set LocalBounds because we draw our own sprites
            var size = (Vector2f)(_sprite.Size * 0.75f);
            LocalBounds = new RectF(-(size / 2), size);
        }

        protected override void OnLoadAudio(Audio audio)
        {

        }

        protected override void OnUpdate(double dt)
        {
            base.OnUpdate(dt);            
        }

        private IEnumerator RotCoro() //testing rotation of CenterSprite
        {
            while (true)
            {
                _sprite.Rotation++;
                yield return Delay(0.5);
            }
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

            sprite.Position = (Vector2i)Position - (size / 2);
        }
    }
}
