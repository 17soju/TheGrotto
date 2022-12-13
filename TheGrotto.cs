using Terraria.ModLoader;
using TheGrotto.Common.Graphics.PrimitiveSystem;
using static Terraria.ModLoader.ModContent;

namespace TheGrotto
{
    public class TheGrotto : Mod
    {

        public static PrimitiveBatch PrimitiveBatch => GetInstance<PrimitiveBatch>();



        public static TheGrotto Instance { get; set; }
        public const string ModName = nameof(TheGrotto);
        public const string ModPrefix = ModName + ":";




        public override void Load()
        {

        }

        public override void Unload()
        {
            base.Unload();
        }



    }
}