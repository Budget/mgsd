using GameAPI;
using GameAPI.BudgetBoy;
using ResourceLibrary;

namespace Games.TestGame
{
    [GameInfo(
        Title = "Sneakman: Tactical Man Avoidance",
        AuthorName = "Psoeter n Krix",
        Version = "0.0.2.1",
        UpdateRate = 60
    )]
    [GraphicsInfo(Width = 256, Height = 240)]
    public class Main : Game
    {
        public Swatches Swatches { get; private set; }

        protected override void OnLoadPalette(PaletteBuilder builder)
        {
            Swatches = new Swatches(builder);
        }

        protected override void OnReset()
        {
            SetStage(new Content(this));
        }
    }
}
