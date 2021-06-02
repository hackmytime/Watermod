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
	public class 飞锤 : ModProjectile
	{
		public float TelegraphDelay
		{
			get
			{
				return projectile.ai[0];
			}
			set
			{
				projectile.ai[0] = value;
			}
		}
		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 2;
			DisplayName.SetDefault("Flying hammer");
			DisplayName.AddTranslation(GameCulture.Chinese, "飞锤");
			Main.projFrames[projectile.type] = 1;
		}
		public override void SetDefaults()
		{
			projectile.width = 38;
			projectile.height = 28;
			projectile.hostile = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
			projectile.extraUpdates = 1;
			projectile.timeLeft = 1200;
			cooldownSlot = 1;
		}
		int A;
		float G;
		public override void SendExtraAI(BinaryWriter writer)
		{
			Utils.WriteVector2(writer, OldVelocity);
		}

		public override void ReceiveExtraAI(BinaryReader reader)
		{
			OldVelocity = Utils.ReadVector2(reader);
		}
		public override void AI()
		{
			G += 0.3f;
			projectile.rotation = G;
			if(projectile.ai[1] == 0)
            {
				A++;
				if (A == 15)
				{
					Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 1000, 0, 10, mod.ProjectileType("飞锤"), (int)(projectile.damage * 0.8f), projectile.knockBack, 0, 0,1);
					A = 0;
				}
			}
			else
            {
				if (projectile.localAI[0] == 0f)
				{
					projectile.localAI[0] = 1f;
					projectile.netUpdate = true;
				}
				if (TelegraphDelay > 75f)
				{
					if (projectile.alpha > 0)
					{
						projectile.alpha -= 25;
					}
					if (projectile.alpha < 0)
					{
						projectile.alpha = 0;
					}
					if (OldVelocity != Vector2.Zero)
					{
						projectile.velocity = OldVelocity;
						OldVelocity = Vector2.Zero;
						projectile.netUpdate = true;
					}
					projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 0.785f;
				}
				else if (OldVelocity == Vector2.Zero)
				{
					OldVelocity = projectile.velocity;
					projectile.velocity = Vector2.Zero;
					projectile.netUpdate = true;
					projectile.rotation = Utils.ToRotation(OldVelocity) + 1.57079637f;
				}
				float telegraphDelay = TelegraphDelay;
				TelegraphDelay = telegraphDelay + 1f;
			}
		}
		public override bool CanDamage()
		{
			return TelegraphDelay > 75f;
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			if (projectile.ai[1] == 1)
			{
				if (TelegraphDelay >= 75f)
				{
					return true;
				}
				Texture2D laserTelegraph = ModContent.GetTexture("Watermod/NPCs/提示");
				float yScale = 2f;
				if (TelegraphDelay < 15f)
				{
					yScale = MathHelper.Lerp(0f, 2f, TelegraphDelay / 15f);
				}
				if (TelegraphDelay > 60f)
				{
					yScale = MathHelper.Lerp(2f, 0f, (TelegraphDelay - 60f) / 15f);
				}
				Vector2 scaleInner;
				scaleInner = new Vector2(4200f / laserTelegraph.Width, yScale);
				Vector2 origin = Utils.Size(laserTelegraph) * new Vector2(0f, 0.5f);
				Vector2 scaleOuter = scaleInner * new Vector2(1f, 1.6f);
				Color colorOuter = new Color(255, 255,255);
				Color colorInner = new Color(255, 255, 255);
				colorOuter *= 0.7f;
				colorInner *= 0.7f;
				spriteBatch.Draw(laserTelegraph, projectile.Center - Main.screenPosition, null, colorInner, Utils.ToRotation(OldVelocity), origin, scaleInner, 0, 0f);
				spriteBatch.Draw(laserTelegraph, projectile.Center - Main.screenPosition, null, colorOuter, Utils.ToRotation(OldVelocity), origin, scaleOuter, 0, 0f);
				return false;
			}
			Rectangle value = new Rectangle(0, 0, 30, 50);
			value.Y += 38 * projectile.frame;
			Vector2 vector = new Vector2(Main.projectileTexture[projectile.type].Width * 0.45f, projectile.height * 0.5f);
			for (int i = 0; i < projectile.oldPos.Length; i++)
			{
				SpriteEffects spriteEffects = (SpriteEffects)((projectile.direction == -1) ? 0 : 1);
				Vector2 vector2 = projectile.oldPos[i] - Main.screenPosition + vector + new Vector2(0f, projectile.gfxOffY);
				Color color = projectile.GetAlpha(lightColor) * ((projectile.oldPos.Length - i) / (float)projectile.oldPos.Length / 2f);
				spriteBatch.Draw(Main.projectileTexture[projectile.type], vector2, new Rectangle?(value), color, projectile.rotation, vector, projectile.scale, spriteEffects, 0f);
			}
			return true;
		}
		public Vector2 OldVelocity;
		public int jj;
		public const float TelegraphTotalTime = 75f;
		public const float TelegraphFadeTime = 15f;
		public const float TelegraphWidth = 4200f;
	}
}