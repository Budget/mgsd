using System;
using System.Collections;
using System.Collections.Generic;

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
