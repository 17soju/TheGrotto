using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

using TheGrotto;
using TheGrotto.Common.Bases.Tiles;
using TheGrotto.Common.Graphics.PrimitiveSystem;

using Terraria.ModLoader;
using Terraria.ModLoader.Core;
using Terraria.Graphics.Effects;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.Enums;
using Terraria;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.Bestiary;
using Terraria.Localization;


namespace TheGrotto.Common.Systems.BiomeTombstones
{
    public abstract class CustomTombstoneHandler : ModSystem
    {

        public override void Load()
        {
            On.Terraria.Player.DropTombstone += DropCustomTombstone;
        }
        public override void Unload()
        {
            On.Terraria.Player.DropTombstone -= DropCustomTombstone;
        }

        /// <summary>
        /// Spawns custom tombstones.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="self"></param>
        private void SpawnTomb(int type, Player self) => Projectile.NewProjectile(self.GetSource_Death(), self.Center, -Vector2.UnitY.RotatedByRandom(0.5f) * Main.rand.NextFloat(5, 7) * 0.5f, 0, 0, 3, 0);

        private void DropCustomTombstone(On.Terraria.Player.orig_DropTombstone orig, Player self, int coinsOwned, NetworkText deathText, int hitDirection)
        {
            if (coinsOwned < 10000)
            {
                SpawnTomb(ProjectileType<CustomTombstoneProj>(), self);
            }

        }
    }

    public class CustomTombstoneProj : ModProjectile 
    {

        public override void SetDefaults()
        {
            AIType = ProjectileID.Tombstone;

        }




    }
}
