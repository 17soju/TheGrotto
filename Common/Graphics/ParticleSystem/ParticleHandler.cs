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

using Terraria.ModLoader;
using Terraria.ModLoader.Core;
using Terraria.Graphics.Effects;
using Terraria;

namespace TheGrotto.Common.Graphics.ParticleSystem
{
    //TODO: maybe rewrite this later on
    // first particle sytem ive made entirely from scratch
    [Autoload(Side = ModSide.Client)]
    public class ParticleHandler : IOrderedLoadable
    {
        private static List<Particle> particles;
        private static List<Particle> additiveBlendingParticles;
        private static List<Particle> particlesToKill;
        internal static Dictionary<int, Texture2D> particleTextures; 


        public void Load() 
        {
            particles = new List<Particle>();
            additiveBlendingParticles = new List<Particle>();
        }
        public void Unload()
        {
            particles = new List<Particle>();
            additiveBlendingParticles = new List<Particle>();
        }

        public static void SpawnParticle(Particle particle)
        {
            if (!Main.gamePaused && (particles.Count < GraphicsConfig.Instance.MaxParticles || particle.isImportant))
            {
                particles.Add(particle);
            }
        }

        public static void KillParticle(Particle particle)
        {
            particlesToKill.Add(particle);
        }

        public static void DrawParticles(SpriteBatch spriteBatch)
        {
            if (particles.Count == 0)
            {
                return;
            }
            spriteBatch.End();

            if (additiveBlendingParticles.Count > 0)
            {
                spriteBatch.Begin();
                foreach (Particle particle in additiveBlendingParticles)
                {
                    if (particle.UsesCustomDrawing)
                    {
                        particle.CustomDraw(spriteBatch);
                        continue;
                    }
                    Rectangle frame = particleTextures[particle.Type].Frame(1, particle.FrameVariants, 0, particle.Variant); 
                    spriteBatch.Draw(particleTextures[particle.Type], particle.Position - Main.screenPosition, frame, particle.Color, particle.Rotation, frame.Size() * 0.5f, particle.Scale, SpriteEffects.None, 0f);
                }
                spriteBatch.End();
            }

        }

        public static Texture2D GetTexture(int type)
        {
            return particleTextures[type];
        }

    }
}
