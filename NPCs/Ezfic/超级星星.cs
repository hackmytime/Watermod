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
	public class 超级星星 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Super star");
			DisplayName.AddTranslation(GameCulture.Chinese, "超级星星");
			Main.projFrames[projectile.type] = 1;
		}
		public override void SetDefaults()
		{
			projectile.width = 22;
			projectile.height = 24;
			projectile.hostile = false;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
			projectile.extraUpdates = 1;
			projectile.timeLeft = 1000;
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
			if (Main.rand.Next(20) == 0)
			{
				Dust.NewDust(projectile.position, projectile.width, projectile.height, 58, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f, 150, default(Color), 1.2f);
				return;
			}
			int num6;
			if (Main.rand.Next(20) == 0)
			{
				for (int num606 = 0; num606 < 7; num606 = num6 + 1)
				{
					Dust.NewDust(projectile.position, projectile.width, projectile.height, 58, projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 150, default(Color), 0.8f);
					num6 = num606;
				}
				for (float num607 = 0f; num607 < 1f; num607 += 0.125f)
				{
					Dust.NewDustPerfect(projectile.Center, 278, new Vector2?(Vector2.UnitY.RotatedBy((double)(num607 * 6.28318548f + Main.rand.NextFloat() * 0.5f), default(Vector2)) * (4f + Main.rand.NextFloat() * 4f)), 150, Color.CornflowerBlue, 1f).noGravity = true;
				}
				for (float num608 = 0f; num608 < 1f; num608 += 0.25f)
				{
					Dust.NewDustPerfect(projectile.Center, 278, new Vector2?(Vector2.UnitY.RotatedBy((double)(num608 * 6.28318548f + Main.rand.NextFloat() * 0.5f), default(Vector2)) * (2f + Main.rand.NextFloat() * 3f)), 150, Color.Gold, 1f).noGravity = true;
				} }
			Vector2 value21 = new Vector2((float)Main.screenWidth, (float)Main.screenHeight);
			bool flag6 = projectile.Hitbox.Intersects(Utils.CenteredRectangle(Main.screenPosition + value21 / 2f, value21 + new Vector2(400f)));
			if (Main.rand.Next(20) == 0)
			{
				if (flag6)
				{
					for (int num609 = 0; num609 < 7; num609 = num6 + 1)
					{
						Gore.NewGore(projectile.position, Main.rand.NextVector2CircularEdge(0.5f, 0.5f) * projectile.velocity.Length(), Utils.SelectRandom<int>(Main.rand, new int[]
						{
									16,
									17,
									17,
									17,
									17,
									17,
									17,
									17
						}), 1f);
						num6 = num609;
					}
				}
			}
			if (Main.rand.Next(20) == 0)
			{
				for (int num615 = 0; num615 < 10; num615 = num6 + 1)
				{
					Dust.NewDust(projectile.position, projectile.width, projectile.height, 57, projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 150, default(Color), 1.2f);
					num6 = num615;
				}
				for (int num616 = 0; num616 < 3; num616 = num6 + 1)
				{
					Gore.NewGore(projectile.position, new Vector2(projectile.velocity.X * 0.05f, projectile.velocity.Y * 0.05f), Main.rand.Next(16, 18), 1f);
					num6 = num616;
				}
			}
			Player player = Main.player[projectile.owner];
			if (player.position.Y >= projectile.Center.Y + 1500)
            {
				if (!NPC.AnyNPCs(ModContent.NPCType<Ezfic>()))
				{
					NPC.NewNPC((int)projectile.Center.X, (int)projectile.Center.Y, ModContent.NPCType<Ezfic>());
				}
				projectile.Kill();
			}
		}
        public override void Kill(int timeLeft)
        {
        }
    }
}