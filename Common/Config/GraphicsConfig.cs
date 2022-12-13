using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

using TheGrotto;
using TheGrotto.Common.Core;

using Terraria.ModLoader;
using Terraria.ModLoader.Core;
using Terraria.Graphics.Effects;
using Terraria.ModLoader.Config;
using Terraria;

namespace TheGrotto.Common.Config
{
    public class GraphicsConfig : ModConfig
    {

        public static GraphicsConfig Instance;
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Label("$Mods.TheGrotto.Configuration.MaxParticles.Label")]
        [Range(0, 1000)]
        public int MaxParticles { get; set; }


    }
}
