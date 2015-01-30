using System;

using GameAPI;
using GameAPI.BudgetBoy;

namespace Games.TestGame
{
    public class Player : Entity
    {
        public new Main Game { get { return (Main) base.Game; } }

        protected Sprite _sprite;

        double _rotation;
        double _rotRadians;

        float _rotationSpeed;
        float _moveSpeed;

        Axis2 _moveAxis;

        Vector2F _radianAngle;
        

       
        public Player()
        {
            
        }

        // called when this entity is added to a stage
        protected override void OnEnterStage(Stage stage)
        {
            base.OnEnterStage(stage);

            _moveAxis = stage.Game.Controls.LeftAnalog;

            _rotationSpeed = 180;
            _moveSpeed = 100;

            //StartCoroutine(RotCoro);
        }

        protected override void OnLoadGraphics(Graphics graphics)
        {
            Image image = graphics.GetImage("Resources/player");
            _sprite = new Sprite(image, Game.Swatches.Player);

            // need to set LocalBounds because we draw our own sprites
            var size = (Vector2F)(_sprite.Size * 0.75f);
            LocalBounds = new RectF(-(size / 2), size);
        }

        protected override void OnLoadAudio(Audio audio)
        {

        }

        protected override void OnUpdate(double dt)
        {
            base.OnUpdate(dt);
            
    
            if(_moveAxis.X.IsPositive)
            {
                _rotation -= (_moveAxis.X.Value * dt) * _rotationSpeed;
            }
            else if(_moveAxis.X.IsNegative)
            {
                _rotation -= (_moveAxis.X.Value * dt) * _rotationSpeed;
            }

            if(_rotation >= 360)
            {
                _rotation -= 360;
            }
            else if(_rotation < 0)
            {
                _rotation += 360;
            }

            if (_moveAxis.Y.IsPositive)
            {
                
            }
            else if (_moveAxis.Y.IsNegative)
            {
               
            }

            _rotRadians = (Math.PI / 180) * _rotation;
            var returnedRadians = RotateVector2F(1.0,1.0,_rotRadians);
            _radianAngle = new Vector2F((float)returnedRadians[0], (float)returnedRadians[1]);
           
        }

        /*private IEnumerator RotCoro() //testing rotation of CenterSprite
        {
            while (true)
            {
                _sprite.Rotation++;
                yield return Delay(0.5);
            }
        }*/

        Double[] RotateVector2F(double x, double y, double degrees)
        {
            double[] result = new double[2];
            result[0] = x * Math.Cos(degrees) - y * Math.Sin(degrees);
            result[1] = x * Math.Sin(degrees) + y * Math.Cos(degrees);

            return result;

            //Debug.Log(newRotation);


        }

        protected override void OnRender(Graphics graphics)
        {
            base.OnRender(graphics);

            CenterSprite(_sprite);
            _sprite.Render(graphics);

            Game.Graphics.DrawLine(Game.Swatches.White, 1, Position, new Vector2F(Position.X, Position.Y) + _radianAngle*5);
            
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
