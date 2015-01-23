using GameAPI;
using GameAPI.BudgetBoy;

namespace Games.TestGame
{
    public class Swatches
    {
        public readonly SwatchIndex ClearColor;
        public readonly SwatchIndex Player;
        public readonly SwatchIndex Wall;
        public readonly SwatchIndex Door;

        public readonly SwatchIndex White;

        public Swatches(PaletteBuilder palette)
        {
            ClearColor = palette.Add(0x111111, 0x111111, 0x111111);
            Player = palette.Add(0x84A9BC, 0x2D322E, 0x553E2C);
            Wall = palette.Add(0xcc4444, 0x992222, 0xff0000);
            Door = palette.Add(0x00512C, 0x007F0E, 0x4CFF00);

            White = palette.Add(0xffffff, 0xffffff, 0xffffff);
        }
    }
}