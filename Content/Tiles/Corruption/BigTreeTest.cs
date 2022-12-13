using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

using TheGrotto;
using TheGrotto.Common.Bases.Tiles;
using TheGrotto.Utilities;

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


namespace TheGrotto.Content.Tiles.Corruption
{
    internal class BigTreeTest : BaseBigTreeTile
    {

        public override int LeafType => GoreID.TreeLeaf_Corruption;
        public override int TreeDust => DustID.Shadewood;
        public override string mapText => "Mods.TheGrotto.MapIcons.BaseBigTreeTile";


        public override void SetStaticDefaults()
        {
            GrowsOnTileId = new int[1]
            {
                TileID.CorruptGrass
            };
        }





    }
}
