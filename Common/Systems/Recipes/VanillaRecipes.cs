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

namespace TheGrotto.Common.Systems.Recipes
{
    public class VanillaRecipes : ModSystem
    {

        //ALL OF THESE ARE SUBJECT TO CHANGE

        public void AddFledglingWingsRecipe()
        {
            Recipe recipe = Recipe.Create(ItemID.CreativeWings);
            recipe.AddIngredient(ItemID.Feather, 10);
            recipe.AddIngredient(ItemID.CopperBar, 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }

        public void AddStarfuryRecipe()
        {
            Recipe recipe = Recipe.Create(ItemID.Starfury); 
            recipe.AddIngredient(ItemID.Star, 10);
            recipe.AddRecipeGroup(RecipeGroupManager.GoldBar, 5); 
            recipe.AddIngredient(ItemID.Ruby);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }

        #region bottle accessories
        public void AddBlizzardBottleRecipe()
        {
            Recipe recipe = Recipe.Create(ItemID.BlizzardinaBottle);
            recipe.AddIngredient(ItemID.IceBlock, 30);
            recipe.AddIngredient(ItemID.Snowball, 50);
            recipe.AddIngredient(ItemID.FlinxFur, 5);
            recipe.AddIngredient(ItemID.SnowBlock, 30);
            recipe.AddIngredient(ItemID.Bottle);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }

        public void AddSanstormBottleRecipe()
        {
            Recipe recipe = Recipe.Create(ItemID.SandstorminaBottle);
            recipe.AddIngredient(ItemID.SandBlock, 30);
            recipe.AddIngredient(ItemID.AntlionMandible, 10);
            recipe.AddIngredient(ItemID.Sandstone, 30);
            recipe.AddIngredient(ItemID.DesertFossil, 5);
            recipe.AddIngredient(ItemID.Bottle);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }

        #endregion bottle accessories


    }
}
