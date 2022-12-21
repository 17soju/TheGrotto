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
using TheGrotto.Utilities;

using Terraria.ModLoader;
using Terraria.ModLoader.Core;
using Terraria.Graphics.Effects;
using Terraria;

namespace TheGrotto.Common.Graphics.ParticleSystem
{
    [Autoload(Side = ModSide.Client)]
    public class ParticleHandler : ModSystem, IOrderedLoadable
    {              
        public static List<Particle> particles;
        public static List<Particle> additiveParticles;
        public static List<Particle> particlesToKill;

        public override void Load()
        {
            particles = new List<Particle>();
            additiveParticles = new List<Particle>();
            particlesToKill = new List<Particle>();
        }
        public override void Unload()
        {
            particles = null;
            additiveParticles = null;
            particlesToKill = null;
        }


        
    }
}
