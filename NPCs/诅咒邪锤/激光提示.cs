using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Watermod.NPCs.诅咒邪锤
{
	public class 激光提示 : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 36;
			projectile.height = 32;
			projectile.light = 0.8f;
			projectile.hostile = false;
			projectile.magic = true;
			projectile.penetrate = -1;
			Main.projFrames[projectile.type] = 1;
			projectile.aiStyle = -1;
			if (projectile.ai[1] == 0)
			{
				projectile.timeLeft = 30;

			}
			else
			{
				projectile.timeLeft = 60;
			}
			projectile.scale = 1f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("激光提示");

		}

		public override void AI()
		{
			if (projectile.ai[0] == 0)
			{
				projectile.velocity *= 0.01f;
				projectile.ai[0] = 1;
			}
		}
		public override void Kill(int timeLeft)
		{
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X, projectile.velocity.Y, ModContent.ProjectileType<诅咒激光>(), 100, 0f, 0);
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
		{
			Vector2 FF = projectile.velocity;
			Texture2D laserTelegraph = ModContent.GetTexture("Watermod/NPCs/提示");
			float yScale = 2.4f;
			yScale -= 0.04f;
			Vector2 scaleInner;
			scaleInner = new Vector2(4200f / laserTelegraph.Width, yScale);
			Vector2 origin = Utils.Size(laserTelegraph) * new Vector2(0f, 0.5f);
			Vector2 scaleOuter = scaleInner * new Vector2(1f, 1.6f);
			Color colorOuter = new Color(208, 86, 201);
			Color colorInner = new Color(208, 86, 201);
			colorOuter *= 0.7f;
			colorInner *= 0.7f;
			spriteBatch.Draw(laserTelegraph, projectile.Center - Main.screenPosition, null, colorInner, Utils.ToRotation(FF), origin, scaleInner, 0, 0f);
			spriteBatch.Draw(laserTelegraph, projectile.Center - Main.screenPosition, null, colorOuter, Utils.ToRotation(FF), origin, scaleOuter, 0, 0f);

			return true;
		}
	}
}