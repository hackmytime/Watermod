using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System.Collections.Generic;
using Terraria.Localization;

namespace Watermod.NPCs
{
	public class 史莱姆亡冠 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Slime Crown");
			DisplayName.AddTranslation(GameCulture.Chinese, "史莱姆亡冠");
			Main.projFrames[projectile.type] = 1;
		}
		public override void SetDefaults()
		{
			projectile.width = 82;
			projectile.height =56;
			projectile.hostile = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
			projectile.extraUpdates = 1;
			projectile.timeLeft = 600;
			cooldownSlot = 1;
		}
		public override void AI()
		{
			projectile.ai[0]++;
			projectile.position.X = Main.player[0].Center.X - projectile.width / 2;
			projectile.position.Y = Main.player[0].Center.Y - projectile.height / 2 - 400;
			if(projectile.ai[0] >= 5)
            {
				projectile.ai[0] = 0;
				Projectile.NewProjectile(projectile.position.X + Main.rand.Next(0, projectile.width), projectile.position.Y+ projectile.height /2, 0, Main.rand.Next(2, 5), ModContent.ProjectileType<史莱姆>(), projectile.damage, 1, 0);
			}
		}
	}
}