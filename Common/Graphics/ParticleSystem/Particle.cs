using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

using TheGrotto;

using Terraria.ModLoader;
using Terraria.ModLoader.Core;
using Terraria.Graphics.Effects;
using Terraria;

namespace TheGrotto.Common.Graphics.ParticleSystem
{
    public class Particle
    {
        #region stuff
        /// <summary>
        /// type of particle
        /// </summary>
        public int Type;
        /// <summary>
        /// represents the position of the particle
        /// </summary>
        public Vector2 Position;
        /// <summary>
        /// represents the origin of this particle
        /// </summary>
        public Vector2 Origin;
        /// <summary>
        /// color of particle
        /// </summary>
        public Color Color;

        /// <summary>
        /// rotation of this particle
        /// </summary>
        public float Rotation;
        /// <summary>
        /// scale of this particle
        /// </summary>
        public float Scale;
        /// <summary>
        /// ???
        /// </summary>
        public int Variant;
        #endregion

        public virtual bool UsesCustomDrawing => false;
        public virtual bool isImportant => false;
        public virtual bool UseAdditiveBlending => false;
        public virtual int FrameVariants => 1;
        public virtual string Texture => "";

        public virtual void Update() { }

        public void Kill() { ParticleHandler.KillParticle(this); }
        //public void Spawn() { ParticleHandler.SpawnParticle(this); }

        public virtual void CustomDraw(SpriteBatch spriteBatch) { }
        public virtual void CustomDraw(SpriteBatch spriteBatch, Vector2 basePosition) { }

    }
}
