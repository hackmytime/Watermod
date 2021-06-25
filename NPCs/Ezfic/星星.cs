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
	public class 星星 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Star");
			DisplayName.AddTranslation(GameCulture.Chinese, "星星");
			Main.projFrames[projectile.type] = 1;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 1;
			ProjectileID.Sets.TrailingMode[projectile.type] = 1;
		}
		public override void SetDefaults()
		{
			projectile.width = 22;
			projectile.height = 24;
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
			G += 0.3f;
			projectile.rotation = G;
			Vector2 value4 = new Vector2((float)Main.screenWidth, (float)Main.screenHeight);
			bool flag3 = projectile.Hitbox.Intersects(Utils.CenteredRectangle(Main.screenPosition + value4 / 2f, value4 + new Vector2(400f)));
			if (flag3 && Main.rand.Next(6) == 0)
			{
				Gore.NewGore(projectile.position, projectile.velocity * 0.2f, Utils.SelectRandom<int>(Main.rand, new int[]
				{
							16,
							17,
							17,
							17
				}), 1f);
			}
			projectile.light = 0.9f;
		}
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			return true;
        }
    }
}