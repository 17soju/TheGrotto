using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

using TheGrotto.Core;

using Terraria.ModLoader;
using Terraria.ModLoader.Core;
using Terraria.Graphics.Effects;
using Terraria;

namespace TheGrotto.Common.Graphics.ParticleSystem
{
    public class Particle
    {

        /// <summary>
        /// Position of your particle.
        /// </summary>
        internal Vector2 Position;

        /// <summary>
        /// Velocity of your particle.
        /// </summary>
        internal Vector2 Velocity;

        /// <summary>
        /// Rotation of your particle.
        /// </summary>
        internal float Rotation;

        /// <summary>
        /// Scale of your particle.
        /// </summary>
        internal float Scale;

        /// <summary>
        /// Represents the transparency of your particle.
        /// </summary>
        internal float Alpha;

        /// <summary>
        /// The color of your particle.
        /// </summary>
        internal Color Color;

        /// <summary>
        /// The texture of your particle.
        /// </summary>
        public virtual string Texture => "";

        /// <summary>
        /// Current frame of your particle.
        /// </summary>
        internal Rectangle Frame;









    }
}
