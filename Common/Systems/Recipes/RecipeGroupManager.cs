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
using Terraria.Localization;

namespace TheGrotto.Common.Systems.Recipes
{
    public class RecipeGroupManager : ModSystem
    {

        public const string GoldBar = TheGrotto.ModPrefix + "GoldBar";

        public static RecipeGroup GoldBarGroup { get; set; }

        public override void OnModUnload()
        {
            GoldBarGroup = null;
        }

        public override void AddRecipeGroups()
        {
            GoldBarGroup = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37"), ItemID.PlatinumBar, ItemID.GoldBar);

            RecipeGroup.RegisterGroup(GoldBar, GoldBarGroup);
        }


    }
}
