using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;

namespace TheGrotto.Utilities
{
    // this shader loader is from slr i think so massive thanks to them for open sourcing their stuff and letting me use this
    // this is super easy and way more effecient to use than loading shaders the "normal" way
    public static partial class ShaderUtils  
    {
        public static bool HasParameter(this Effect effect, string parameterName)
        {
            foreach (EffectParameter parameter in effect.Parameters)
            {
                if (parameter.Name == parameterName)
                {
                    return true;
                }
            }

            return false;
        }

        public static void ActivateScreenShader(string ShaderName, Vector2 vec = default)
        {
            if (Main.netMode != NetmodeID.Server && !Filters.Scene[ShaderName].IsActive())
            {
                Filters.Scene.Activate(ShaderName, vec);
            }
        }

        public static ScreenShaderData GetScreenShader(string ShaderName) => Filters.Scene[ShaderName].GetShader();
    }
}
