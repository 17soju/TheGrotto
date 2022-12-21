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

namespace TheGrotto.Common.Systems
{
    /// <summary>
    /// auto-sacrifice system so we dont have to manually assign amount of items needed
    /// </summary>
    public class SacrificeSystem : ModSystem
    {
        public override void PostSetupContent()
        {
            foreach (ModItem modItem in GetContent<ModItem>())
            {
                Item item = new(modItem.Type);
                
                bool isTile = item.createTile > -1;
                bool IsWall = item.createWall > -1;
                bool isWeapon = item.damage > 0;
                bool isEquippable = item.accessory = true;

                int sacrificeCount = 25;


                if (isTile)
                {
                    sacrificeCount = 100;
                }
                else if (IsWall)
                {
                    sacrificeCount = 100;
                }
                else if (isWeapon)
                {
                    sacrificeCount = 1;
                }
                else if (isEquippable)
                {
                    sacrificeCount = 1;
                }

                CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[modItem.Type] = sacrificeCount;
            }
        }
    }
}




