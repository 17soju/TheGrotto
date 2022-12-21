using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

using TheGrotto;
using TheGrotto.Common.Core;
using TheGrotto.Common.Config;
using TheGrotto.Common.Graphics.ParticleSystem;

using Terraria.ModLoader;
using Terraria.ModLoader.Core;
using Terraria.Graphics.Effects;
using Terraria;
using Terraria.ID;
using Terraria.GameContent;

namespace TheGrotto.Utilities
{
	public static class DrawUtils
	{
        public static readonly BasicEffect basicEffect = Main.dedServ ? null : new BasicEffect(Main.graphics.GraphicsDevice);

        public static Vector2 PointAccur(this Vector2 input) => input.ToPoint().ToVector2();

        public static float ConvertX(float input) => input / (Main.screenWidth * 0.5f) - 1;

        public static float ConvertY(float input) => -1 * (input / (Main.screenHeight * 0.5f) - 1);

        public static Vector2 ConvertVec2(Vector2 input) => new Vector2(1, -1) * (input / (new Vector2(Main.screenWidth, Main.screenHeight) * 0.5f) - Vector2.One);

        public static void DrawHitbox(this SpriteBatch spriteBatch, NPC NPC, Color color) => spriteBatch.Draw(Terraria.GameContent.TextureAssets.BlackTile.Value, NPC.getRect().WorldToScreenCoords(), color);

        public static Rectangle WorldToScreenCoords(this Rectangle rect) => new Rectangle(rect.X - (int)Main.screenPosition.X, rect.Y - (int)Main.screenPosition.Y, rect.Width, rect.Height);

        public static void DrawLineBetter(this SpriteBatch spriteBatch, Vector2 start, Vector2 end, Color color, float width)
        {
            if (!(start == end))
            {
                start -= Main.screenPosition;
                end -= Main.screenPosition;
                Texture2D line = TextureAssets.FishingLine.Value;
                float rotation = (end - start).ToRotation();
                spriteBatch.Draw(scale: new Vector2(Vector2.Distance(start, end) / (float)line.Width, width), texture: line, position: start, sourceRectangle: null, color: color, rotation: rotation, origin: line.Size() * Vector2.UnitY * 0.5f, effects: SpriteEffects.None, layerDepth: 0f);
            }
        }
        
    }
}
