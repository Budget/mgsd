using System;
using System.Collections;
using System.Collections.Generic;

using GameAPI;
using GameAPI.BudgetBoy;

namespace Games.TestGame
{
    public class MenuStage : Stage
    {
        public new Main Game { get { return (Main) base.Game; } }

        Image font;

        int TEXT_DEPTH = 0;
        Text menuText1;
        Text menuText2;
        Text flashText;

        int tick = 0; // should probably make a better system than a hacky timer

        // called when this stage is created
        public MenuStage(Main game) : base(game)
        {
            
        }

        public void FlashText(Text obj, string text, Vector2I pos) //function to handle flashing text DUHHHHHH
        {
            obj.Value = text;
            obj.Position = pos;
            if (tick > 30)
            {
                obj.IsVisible = true;

            }
            else
            {
                obj.IsVisible = false;
            }
        }

        // called when this stage is entered
        protected override void OnEnter()
        {
            Graphics.SetClearColor(Game.Swatches.ClearColor); // set the background color

            font = Graphics.GetImage("Resources/font"); // setting up text shit
            menuText1 = Add(new Text(font, Game.Swatches.White), TEXT_DEPTH);
            menuText2 = Add(new Text(font, Game.Swatches.White), TEXT_DEPTH);
            flashText = Add(new Text(font, Game.Swatches.White), TEXT_DEPTH);

            menuText1.Value = ("SNEAKMAN:\nTACTICAL MAN AVOIDANCE");
            menuText1.Position = Graphics.Size / 2 + new Vector2I(-menuText1.Width / 2, 30);
        }

        // called each tick
        protected override void OnUpdate()
        {
            base.OnUpdate();

            tick++;
            if(tick == 60)
            {
                tick = 0;
            }

            FlashText(menuText2, "Press START", Graphics.Size / 2 + new Vector2I(-menuText2.Width / 2, 10)); // will be changed and added into a stack function that makes it all neat

            if (Controls.A.JustPressed) Game.SetStage(new GameStage(Game));
        }

        // called when this stage is rendered
        protected override void OnRender()
        {
            base.OnRender();

        }
    }
}
