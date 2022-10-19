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
using Terraria.ID;

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
