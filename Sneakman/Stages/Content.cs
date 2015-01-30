using System.Collections;

using GameAPI;
using GameAPI.BudgetBoy;

namespace Games.TestGame
{
    public class Content : Stage
    {
        public new Main Game { get { return (Main) base.Game; } }

        public static Sound _audio1;
        public static string[] gameSounds = {   "footstep",
                                                "alert",
                                                "encounter",
                                                "gameover1",
                                                "gameover2",
                                                "sneak",
                                                "handgun_reload",
                                                "handgun_shoot",
                                                "shotgun_pump",
                                                "shotgun_shoot",
                                                "snakedie",
                                                "start_game",
                                                "hit1"};

        Image font;

        int TEXT_DEPTH = 0;
        Text menuText1;
        Text menuText2;

        int contentLoadNumber = 0;

        public IEnumerator LoadContent()
        {
            foreach (string soundToLoad in gameSounds)
            {

                menuText2.Value = (contentLoadNumber.ToString() + "/" + (gameSounds.Length - 1).ToString());
                menuText2.Position = Graphics.Size / 2 + new Vector2I(-menuText2.Width / 2, 10);

                _audio1 = Audio.GetSound("Resources/sounds/" + soundToLoad);
                _audio1.Play();
                _audio1.Stop();

                contentLoadNumber++;
                Debug.Log("Loaded Content #" + contentLoadNumber.ToString() + ": " + soundToLoad);

                yield return Delay(0.2); // requires a delay otherwise it stalls while loading and might crash if something seriously fucks up, also makes it look neater to players
            }

            Game.SetStage(new MenuStage(Game));
        }

        // called when this stage is created
        public Content(Main game) : base(game)
        {
            
        }

        // called when this stage is entered
        protected override void OnEnter()
        {
            Graphics.SetClearColor(Game.Swatches.ClearColor); // set the background color

            font = Graphics.GetImage("Resources/font");
            menuText1 = Add(new Text(font, Game.Swatches.White), TEXT_DEPTH);
            menuText2 = Add(new Text(font, Game.Swatches.White), TEXT_DEPTH);

            menuText1.Value = ("LOADING");
            menuText1.Position = Graphics.Size / 2 + new Vector2I(-menuText1.Width / 2, 30);
            
            StartCoroutine(LoadContent);

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
