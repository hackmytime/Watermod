using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Watermod.Items
{
	public class 星星 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Star");
			DisplayName.AddTranslation(GameCulture.Chinese, "星星");
			Tooltip.SetDefault("Use the star cannon to launch toward the sky!");
			Tooltip.AddTranslation(GameCulture.Chinese, "使用星星炮朝着天上发射!");
		}
		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.ranged = true;
			item.damage = 17;
			item.width = 18;
			item.height = 44;
			item.consumable = true;
			item.knockBack = 3f;
			item.value = 1000;
			item.rare = ItemRarityID.Orange;
			item.shoot = mod.ProjectileType("超级星星");
			item.shootSpeed = 7f;
			item.ammo = AmmoID.FallenStar;
		}
	}
}