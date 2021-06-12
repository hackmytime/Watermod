using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System.Collections.Generic;
using Terraria.Localization;

namespace Watermod.NPCs.Ezfic
{
	public class 佝偻头 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Skull");
			DisplayName.AddTranslation(GameCulture.Chinese, "佝偻头");
			Main.projFrames[projectile.type] = 1;
		}
		public override void SetDefaults()
		{
			projectile.width = 80;
			projectile.height =102;
			projectile.hostile = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
			projectile.extraUpdates = 1;
			projectile.timeLeft = 1200;
			cooldownSlot = 1;
		}
		float G;
		public override void AI()
		{
			G += 0.5f;
			projectile.rotation = G;
		}
	}
}