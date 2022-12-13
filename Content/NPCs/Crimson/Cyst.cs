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
using Terraria;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.Bestiary;
using Terraria.Localization;
//TODO  


namespace TheGrotto.Content.NPCs.Crimson
{
    internal class Cyst : ModNPC
    {

        public override void SetDefaults()
        {
            NPC.noGravity = true;
            NPC.aiStyle = -1;
        }

        public override void AI()
        {
            base.AI();
        }





    }
}
