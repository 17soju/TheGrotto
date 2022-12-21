using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

using TheGrotto;
using TheGrotto.Common.Core;
using TheGrotto.Common.Config;
using TheGrotto.Common.Graphics.PrimitiveSystem;
using TheGrotto.Common.Graphics.ParticleSystem;

using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.Core;
using Terraria.Graphics.Effects;
using Terraria;

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