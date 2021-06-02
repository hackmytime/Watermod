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
	public class 雷击 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lightning strike");
			DisplayName.AddTranslation(GameCulture.Chinese, "雷击");
			Main.projFrames[projectile.type] = 2;
		}
		public override void SetDefaults()
		{
			projectile.width = 98;
			projectile.height = 16;
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
			projectile.frameCounter++;
			if (projectile.frameCounter >= 8)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 2;
			}
			projectile.rotation = (float)Math.Atan2(projectile.velocity.Y * -1, projectile.velocity.X * -1);
		}
    }
}