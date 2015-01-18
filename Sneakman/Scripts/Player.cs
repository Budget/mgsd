using System;

using GameAPI;
using GameAPI.BudgetBoy;

namespace Games.TestGame
{
    public class Player : Entity
    {
        public new Main Game { get { return (Main) base.Game; } }

       
        public Player()
        {
            
        }

        // called when this entity is added to a stage
        protected override void OnEnterStage(Stage stage)
        {
            base.OnEnterStage(stage);

        }

        protected override void OnLoadGraphics(Graphics graphics)
        {
            
        }

        protected override void OnLoadAudio(Audio audio)
        {

        }

        protected override void OnUpdate(double dt)
        {
            base.OnUpdate(dt);

        }
    }
}
