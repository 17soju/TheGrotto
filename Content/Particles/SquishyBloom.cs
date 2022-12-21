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
using TheGrotto.Common.Graphics.ParticleSystem;
using TheGrotto.Utilities;

using Terraria.ModLoader;
using Terraria.ModLoader.Core;
using Terraria.Graphics.Effects;
using Terraria;

namespace TheGrotto.Content.Particles
{
    internal class SquishyBloom : Particle
    {

        public override string Texture => null; // temp

        public override bool IsAdditive => true;
        public override bool IsUsingCustomDrawing => true;


        public override void CustomDrawing(SpriteBatch spriteBatch)
        {

        }


    }
}
