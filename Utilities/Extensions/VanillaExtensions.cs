using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

using Terraria.ModLoader;
using Terraria.ModLoader.Core;
using Terraria.GameContent.Creative;
using Terraria.Graphics.Effects;
using Terraria;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent;

namespace TheGrotto.Utilities.Extensions
{
    public static class VanillaExtensions
    {

		public static bool ZoneForest(this Player Player)
		{
			return !Player.ZoneJungle
				&& !Player.ZoneCorrupt
				&& !Player.ZoneCrimson
				&& !Player.ZoneHallow
				&& !Player.ZoneSnow
				&& !Player.ZoneGlowshroom
				&& !Player.ZoneBeach
				&& !Player.ZoneDesert
				&& Player.ZoneOverworldHeight;
		}

		public static bool ZoneUnderground(this Player Player)
        {
			return !Player.ZoneDirtLayerHeight
				&& !Player.ZoneGemCave
				&& !Player.ZoneRockLayerHeight
				&& !Player.ZoneNormalUnderground
				&& !Player.ZoneMarble
				&& !Player.ZoneGranite
				&& !Player.ZoneDungeon;
		}










	}
}
