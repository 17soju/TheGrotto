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
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent;

namespace TheGrotto.Common.Systems.Swimming
{

    //TODO | aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa make this not a godclass i think
    public class SwimBuff : ModBuff
    {

    }


    public class SwimmingSystemManager : ModSystem
    {

    }

    public class SwimmingPlayer : ModPlayer
    {
        public bool Swimming = false;

        public void CheckSwimming()
        {

            if (Player.HasBuff(BuffType<SwimBuff>()))
                Swimming = true;




        }

        public override void PreUpdate()
        {
            CheckSwimming();
        }


    }
}
