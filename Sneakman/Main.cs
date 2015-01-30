using GameAPI;
using GameAPI.BudgetBoy;

namespace Games.TestGame
{
    [GameInfo(
        Title = "Sneakman: Tactical Man Avoidance",
        AuthorName = "Psoeter n Krix",
        Version = "0.0.4.2",
        UpdateRate = 60
    )]
    [GraphicsInfo(Width = 240, Height = 240)]
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
        
        protected override void OnRegisterResourceTypes(ResourceManager library)
        {
            base.OnRegisterResourceTypes(library);

            library.Register<MapResource>(ResourceFormat.Default, MapResource.Save, MapResource.Load, ".map");
            Debug.Log("Registered.");
        }
        public static MapResource MapR;

        protected override void OnLoadResources(Resources volume)
        {
            base.OnLoadResources(volume);
            MapR = volume.Get<MapResource>("Resources/maps/test");
            Debug.Log("Loaded test.map.");

            Debug.Log(MapR.Tiles.ToString());
        }
    }
}
