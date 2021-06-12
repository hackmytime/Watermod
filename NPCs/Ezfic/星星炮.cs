using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Watermod.NPCs.Ezfic
{
	public class 星星炮 : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Star cannon");
			DisplayName.AddTranslation(GameCulture.Chinese, "星星炮");
			Main.npcFrameCount[npc.type] = 1;
		}

		public override void SetDefaults()
		{
			npc.damage = 100;
			npc.width = 56;
			npc.height = 22;
			npc.defense = 8;
			npc.lifeMax = 2000;
			npc.aiStyle = -1;
			npc.knockBackResist = 0f;
			animationType = 10;
			npc.behindTiles = true;
			npc.noGravity = true;
			npc.canGhostHeal = false;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.netAlways = true;
			npc.dontCountMe = true;
		}
		public int moveSpeed;
		public int moveSpeedY;
		int 探针攻击;
		public override void AI()
		{
			npc.TargetClosest();
			Player player = Main.player[npc.target];
			Vector2 direction = Main.player[npc.target].Center - npc.Center;
			direction.Normalize();
			direction.X *= 14f;
			direction.Y *= 14f;
			if (!Main.player[npc.target].dead)
			{
				探针攻击++;
				if (探针攻击 == 20)
				{
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X, direction.Y, mod.ProjectileType("星星"), 100, 0.5f,0);
				}
				if (探针攻击 == 40)
				{
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X, direction.Y, mod.ProjectileType("星星"), 100, 0.5f,0);
				}
				if (探针攻击 == 60)
				{
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X, direction.Y, mod.ProjectileType("星星"), 100, 0.5f,0);
				}
				if (探针攻击 == 80)
				{
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X, direction.Y, mod.ProjectileType("星星"), 100, 0.5f,0);
				}
				if (探针攻击 == 100)
				{
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X, direction.Y, mod.ProjectileType("星星"), 100, 0.5f,0);
				}
				if (探针攻击 == 160)
                {
					探针攻击 = 0;
				}

				npc.rotation = (float)Math.Atan2(direction.Y * -1, direction.X * -1);
				if (npc.ai[0] == 0)
				{
					Vector2 vector4 = Vector2.Subtract(player.Center - new Vector2(-500, 0f), npc.Center);
					float A = 20f;
					vector4.Normalize();
					vector4 *= A;
					npc.velocity = (npc.velocity * 8 + vector4) / 10;
				}
				else if (npc.ai[0] == 1)
				{
					Vector2 vector4 = Vector2.Subtract(player.Center - new Vector2(500, 0f), npc.Center);
					float A = 20f;
					vector4.Normalize();
					vector4 *= A;
					npc.velocity = (npc.velocity * 8 + vector4) / 10;

				}
				else if (npc.ai[0] == 2)
				{
					Vector2 vector4 = Vector2.Subtract(player.Center - new Vector2(500, 50f), npc.Center);
					float A = 20f;
					vector4.Normalize();
					vector4 *= A;
					npc.velocity = (npc.velocity * 8 + vector4) / 10;

				}
				else if (npc.ai[0] == 3)
				{
					Vector2 vector4 = Vector2.Subtract(player.Center - new Vector2(-500, -50f), npc.Center);
					float A = 20f;
					vector4.Normalize();
					vector4 *= A;
					npc.velocity = (npc.velocity * 8 + vector4) / 10;

				}
				else if (npc.ai[0] == 4)
				{
					Vector2 vector4 = Vector2.Subtract(player.Center - new Vector2(500, -100f), npc.Center);
					float A = 20f;
					vector4.Normalize();
					vector4 *= A;
					npc.velocity = (npc.velocity * 8 + vector4) / 10;

				}
				else if (npc.ai[0] == 5)
				{
					Vector2 vector4 = Vector2.Subtract(player.Center - new Vector2(-500, -100f), npc.Center);
					float A = 20f;
					vector4.Normalize();
					vector4 *= A;
					npc.velocity = (npc.velocity * 8 + vector4) / 10;

				}
			}
		}
	}
}