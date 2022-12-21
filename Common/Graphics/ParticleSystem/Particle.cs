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
        public virtual string Texture => "";
        public virtual bool IsAdditive => false;
        public virtual bool IsUsingCustomDrawing => false;

        public Vector2 Position;
        public Vector2 Origin;
        public Vector2 Velocity;
        public Color Color;
        public SpriteEffects Effects;
        public Rectangle FrameSize;

        public float Scale;
        public float Rotation;
        public int Lifetime;
        public int Frame;


        public virtual void Update() { }
        public virtual void OnKill() { }
        public virtual void OnSpawn() { }

        public virtual void CustomDrawing(SpriteBatch spriteBatch) { }
        public void Kill()
        {

        } 
    }
}
