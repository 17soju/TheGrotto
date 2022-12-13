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

namespace TheGrotto.Common.Systems.LootPools
{
    /// <summary>
    /// system i made for easily making loot pools/chest loot without weird tmod shit
    /// </summary>
    public interface ILootPool
    {
        public void SetLootPool(Chest chest);

    }
}
