using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

using TheGrotto.Core;

using Terraria.ModLoader;
using Terraria.ModLoader.Core;
using Terraria.Graphics.Effects;
using Terraria;

namespace TheGrotto.Common.Graphics.MetaballSystem
{
	public class MetaballSystem : IOrderedLoadable
	{
		public static int oldScreenWidth = 0;
		public static int oldScreenHeight = 0;

		public static List<MetaballActor> Actors = new List<MetaballActor>();

		public float Priority => 1;

		public void Load()
		{
			if (Main.dedServ)
				return;

			On.Terraria.Main.DrawNPCs += DrawTargets;
			On.Terraria.Main.CheckMonoliths += BuildTargets;
		}

		public void Unload()
		{
			On.Terraria.Main.DrawNPCs -= DrawTargets;
			On.Terraria.Main.CheckMonoliths -= BuildTargets;

			Actors = null;
		}

		public void UpdateWindowSize(int width, int height)
		{
			Main.QueueMainThreadAction(() =>
			{
				Actors.ForEach(n => n.ResizeTarget(width, height));
			});

			oldScreenWidth = width;
			oldScreenHeight = height;
		}

		private void DrawTargets(On.Terraria.Main.orig_DrawNPCs orig, Main self, bool behindTiles = false)
		{
			if (behindTiles)
				Actors.ForEach(a => a.DrawTarget(Main.spriteBatch));

			orig(self, behindTiles);
		}

		private void BuildTargets(On.Terraria.Main.orig_CheckMonoliths orig)
		{
			if (Main.graphics.GraphicsDevice != null)
			{
				if (Main.screenWidth != oldScreenWidth || Main.screenHeight != oldScreenHeight)
					UpdateWindowSize(Main.screenWidth, Main.screenHeight);
			}

			if (Main.spriteBatch != null && Main.graphics.GraphicsDevice != null)
				Actors.ForEach(a => a.DrawToTarget(Main.spriteBatch, Main.graphics.GraphicsDevice));

			orig();
		}
	}
}
