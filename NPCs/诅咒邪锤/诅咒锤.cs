﻿using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using Terraria.Localization;

namespace Watermod.NPCs.诅咒邪锤
{
	public class 诅咒锤 : ModProjectile
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
			DisplayName.SetDefault("Cursed Hammer");
			DisplayName.AddTranslation(GameCulture.Chinese, "诅咒锤");

			Main.projFrames[projectile.type] = 6;
		}
		public override void SetDefaults()
		{
			projectile.width = 82;
			projectile.height = 82;
			projectile.hostile = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.alpha = 0;
			projectile.penetrate = -1;
			projectile.extraUpdates = 1;

			if (projectile.ai[1] == 1)
			{
				projectile.timeLeft = 180;
			}
			else
			{
				projectile.timeLeft = 600;

			}
			cooldownSlot = 1;
		}
		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			if (G == 0)
			{
				if (player.HeldItem.damage > 0)
				{
					player.HeldItem.SetDefaults(player.HeldItem.type);
					player.HeldItem.Prefix(-2);
					player.HeldItem.position.X = player.position.X + (player.width / 2) - (player.HeldItem.width / 2);
					player.HeldItem.position.Y = player.position.Y + (player.height / 2) - (player.HeldItem.height / 2);
					ItemText.NewText(player.HeldItem, player.HeldItem.stack, true, false);
					G = 60;
				}
			}
		}

		public override void SendExtraAI(BinaryWriter writer)
		{
			Utils.WriteVector2(writer, OldVelocity);
		}
		int G;
		int H;
		public override void ReceiveExtraAI(BinaryReader reader)
		{
			OldVelocity = Utils.ReadVector2(reader);
		}
        public override void Kill(int timeLeft)
		{
			if (projectile.ai[1] == 1)
            {
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (float)(Math.Cos(projectile.rotation - 0.785) * 7), (float)(Math.Sin(projectile.rotation - 0.785) * 7), ModContent.ProjectileType<诅咒锤>(), 100, 1f, 0, 0, 0);
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (float)(Math.Cos(projectile.rotation - 2.355) * 7), (float)(Math.Sin(projectile.rotation - 2.355) * 7), ModContent.ProjectileType<诅咒锤>(), 100, 1f, 0, 0, 0);
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (float)(Math.Cos(projectile.rotation - 3.925) * 7), (float)(Math.Sin(projectile.rotation - 3.925) * 7), ModContent.ProjectileType<诅咒锤>(), 100, 1f, 0, 0, 0);
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (float)(Math.Cos(projectile.rotation - 5.495) * 7), (float)(Math.Sin(projectile.rotation - 5.495) * 7), ModContent.ProjectileType<诅咒锤>(), 100, 1f, 0, 0, 0);
			}
		}
        public override void AI()
		{
			if(G>0)
            {
				G--;
            }
			if(G<0)
            {
				G=0;
            }
			
			if(projectile.ai[1] == 1)
            {
				projectile.scale = 1.5f;
			}
			if(projectile.ai[1] == 2)
            {
				projectile.scale = 1.25f;
            }
			projectile.frameCounter++;
			if (projectile.frameCounter > 5)
			{
				projectile.frame++;
				projectile.frameCounter = 0;
			}
			if (projectile.frame >= 6)
			{
				projectile.frame = 0;
				return;
			}
			projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 0.785f;
			/*
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
				projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) +0.785f;
			}
			else if (OldVelocity == Vector2.Zero)
			{
				OldVelocity = projectile.velocity;
				projectile.velocity = Vector2.Zero;
				projectile.netUpdate = true;
				projectile.rotation = Utils.ToRotation(OldVelocity) + 1.57079637f;
			}
			float telegraphDelay = TelegraphDelay;
			TelegraphDelay = telegraphDelay + 1f;*/
		}
        public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
        {
			damage /= 2;
			if(damage<50)
            {
				damage = 50;

			}
        }
        public override bool CanDamage()
		{
			return TelegraphDelay < 75f;
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(208, 86, 201, projectile.alpha));
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			/*
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
			Vector2 scaleOuter = scaleInner * new Vector2(1f, 5f);
			Color colorOuter = new Color(123, 29, 220);
			Color colorInner = new Color(123, 29, 220);
			colorOuter *= 0.7f;
			colorInner *= 0.7f;
			spriteBatch.Draw(laserTelegraph, projectile.Center - Main.screenPosition, null, colorInner, Utils.ToRotation(OldVelocity), origin, scaleInner, 0, 0f);
			spriteBatch.Draw(laserTelegraph, projectile.Center - Main.screenPosition, null, colorOuter, Utils.ToRotation(OldVelocity), origin, scaleOuter, 0, 0f);
			*/
			return true;
		}
		public Vector2 OldVelocity;
		public const float TelegraphTotalTime = 75f;
		public const float TelegraphFadeTime = 15f;
		public const float TelegraphWidth = 4200f;
	}
}