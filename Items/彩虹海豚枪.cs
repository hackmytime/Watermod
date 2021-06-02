using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Watermod.Items
{
	public class 彩虹海豚枪 : ModItem
	{
		public override void SetDefaults()
		{
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.autoReuse = true;
			item.useAnimation = 5;
			item.useTime = 5;
			item.crit += 10;
			item.width = 60;
			item.height = 26;
			item.shoot = ProjectileID.PurificationPowder;
			item.useAmmo = AmmoID.Bullet;
			item.UseSound = SoundID.Item40;
			item.damage = 200;
			item.shootSpeed = 12f;
			item.noMelee = true;
			item.value = 750000;
			item.rare = ItemRarityID.Red;
			item.knockBack = 2.5f;
			item.ranged = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rainbow Dolphin Gun");
			DisplayName.AddTranslation(GameCulture.Chinese, "彩虹海豚枪");
			Tooltip.SetDefault("Am I a dolphin or a cat? I don't know meow meow meow\nFavorite to disable rainbow");
			Tooltip.AddTranslation(GameCulture.Chinese, "我是海豚还是猫？我也不知道喵喵喵\n收藏以禁用彩虹");
		}
		bool 彩虹;
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = 502;
			if (!item.favorited)
			{
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.RainbowFront, damage, knockBack, player.whoAmI, 0f, 0f);
			}
			return true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SDMG, 1);
			recipe.AddIngredient(ItemID.Meowmere, 1);
			recipe.AddTile(TileID.PlanteraBulb);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-20, 0);
		}

	}
}