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
using Terraria.Graphics.Shaders;
using Terraria;
using Terraria.ID;
using Terraria.Graphics;

namespace TheGrotto.Content.Items.Weapons.Summon
{

    //  arctarus todo
    public class VacPack : ModItem
    {

        public override string Texture => AssetDirectory.Weapons + "Summon/VacPack";

        public override void SetDefaults()
        {
            Item.damage = 15;
            Item.DamageType = DamageClass.Summon;

            Item.channel = true;
            Item.noUseGraphic = true;
            Item.noMelee = true;

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shoot = ModContent.ProjectileType<VacPackHoldout>();
            Item.shootSpeed = 27;
        }

        public override void AddRecipes()
        {
            base.AddRecipes();
        }
    }

    public class VacPackPlayer : ModPlayer { }

    public class VacPackHoldout : ModProjectile
    {
        private int time;
        public Player owner => Main.player[Projectile.owner];

        public override string Texture => AssetDirectory.Weapons + "Summon/VacPack";
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Summon;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
        } 

        public override void AI()
        {
            time++;

            Vector2 ArmPos = owner.RotatedRelativePoint(owner.MountedCenter, true);
        }


        private static VertexStrip _vertexStrip = new VertexStrip();

        public void Draw(Projectile proj)
        {
            MiscShaderData miscShaderData = GameShaders.Misc["RainbowRod"];
            miscShaderData.UseSaturation(-2.8f);
            miscShaderData.UseOpacity(4f);
            miscShaderData.Apply();
            _vertexStrip.PrepareStripWithProceduralPadding(proj.oldPos, proj.oldRot, StripColors, StripWidth, -Main.screenPosition + proj.Size / 2f);
            _vertexStrip.DrawTrail();
            Main.pixelShader.CurrentTechnique.Passes[0].Apply();
        }
        private Color StripColors(float progressOnStrip)
        {
            Color value = Main.hslToRgb((progressOnStrip * 1.6f - Main.GlobalTimeWrappedHourly) % 1f, 1f, 0.5f);
            Color result = Color.Lerp(Color.White, value, Utils.GetLerpValue(-0.2f, 0.5f, progressOnStrip, clamped: true)) * (1f - Utils.GetLerpValue(0f, 0.98f, progressOnStrip));
            result.A = 0;
            return result;
        }

        private float StripWidth(float progressOnStrip)
        {
            float num = 1f;
            float lerpValue = Utils.GetLerpValue(0f, 0.2f, progressOnStrip, clamped: true);
            num *= 1f - (1f - lerpValue) * (1f - lerpValue);
            return MathHelper.Lerp(0f, 32f, num);
        }





    }

    //public class SlimeProjectile : ModProjectile { }



    public class VacPackGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public int SlimeCount = 4;

        public override void ResetEffects(NPC npc)
        {
            SlimeCount = Utils.Clamp(SlimeCount, 0, 0);
        }

        public void UpdateNPCSpeed(NPC npc, ref int damage)
        {
            if (SlimeCount > 0)
            {
                if (npc.lifeRegen > 0)
                    npc.lifeRegen = 0;

                npc.lifeRegen -= 10 * SlimeCount; //TODO || make this like apply a custom debuff that reduces movement speed and adds cool vfx
                if (damage < 1)
                    damage = 1;
            }
        }
    }
}
