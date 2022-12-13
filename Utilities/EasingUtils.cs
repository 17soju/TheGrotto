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

namespace TheGrotto.Utilities
{
    public static class EasingUtils
    {

        public enum EasingType
        {
            EaseInQuad,
            EaseInHexic,
        }

        public static float EaseInQuad(float x){
            return x * x;
        }

        public static float EaseInHexic(float x) {
            return x * x * x * x * x * x;
        }





    }
}
