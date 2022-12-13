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
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.Enums;
using Terraria;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.Bestiary;
using Terraria.Localization;


namespace TheGrotto.Common.Bases.Tiles
{
    //if it turns out we need more variety/ functions itd be easier to just make each tree a separate class/ModTile

    //idk. work on this later, will port other big trees eventually
    //TODO
    //Make bottom breakable with axe
    //make tops either affected by wind (somehow) or make it a separate tile
    //make them harder to chop 
    //sfx
    internal abstract class BaseBigTreeTile : ModTile//, ITree, ModTree
    {
        public abstract string mapText { get; }

        public abstract int TreeDust { get; }

        public Color MapColor = Color.White;

        /// <summary>
        /// set this to whatever you want
        /// </summary>
        public abstract int LeafType { get; }
        TreeTypes CountAsTreeType { get; }

        public int[] GrowsOnTileId { get; set; }
        

        /// <summary>
        /// used mostly for loot tables
        /// </summary>
        public virtual TreeTypes CountsAsTreeType => TreeTypes.Forest;

        public override void SetStaticDefaults()
        {
            Main.tileAxe[Type] = true;
            Main.tileMergeDirt[Type] = false;
            Main.tileFrameImportant[Type] = false;

            ModTranslation treename = CreateMapEntryName();
            AddMapEntry(MapColor, treename);



        }






    }
}
