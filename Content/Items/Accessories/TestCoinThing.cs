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
using Terraria.GameContent.Creative;
using Terraria.Graphics.Effects;
using Terraria;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent;


namespace TheGrotto.Content.Items.Accessories
{
    internal class TestCoinThing : ModItem
    {

        public override void Load() { On.Terraria.NPC.NPCLoot_DropMoney += SpawnCoin; }
        public override void Unload() { On.Terraria.NPC.NPCLoot_DropMoney -= SpawnCoin; }
        
        private void SpawnCoin(On.Terraria.NPC.orig_NPCLoot_DropMoney orig, NPC self, Player closestPlayer)
        {
            throw new NotImplementedException();
        }
    }
}
