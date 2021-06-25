using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Watermod.NPCs.Ezfic
{
	[AutoloadBossHead]
	public class Ezfic : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ezfic");
			Main.npcFrameCount[npc.type] = 32;
		}

		public override void SetDefaults()
		{
			npc.damage = 100;
			npc.width = 78;
			npc.height = 78;
			npc.defense = 8;
			npc.lifeMax = 75000;
			npc.aiStyle = -1;
			npc.knockBackResist = 0f;
			npc.behindTiles = true;
			npc.noGravity = true;
			npc.canGhostHeal = false;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.netAlways = true;
			npc.dontCountMe = true;
			music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Ezfic");
			npc.boss = true;
		}
		private int Timer;
		private int Timer2;
		private int Timer3;
		private int Timer4;
		private int Timer5;
		private int fw;
		private double Da;
		public float RR;
		public bool HH = true;
		public bool One = false;
		public bool Two = false;
		public bool Three = false;
		public bool Four = false;
		public bool Fives = true;
		public bool Six = false;
		public bool Seven = false;
		public bool S2 = false;
		public override bool StrikeNPC(ref double damage, int defense, ref float knockback, int hitDirection, ref bool crit)
		{
			if (damage >= Da)
			{
				damage = Da;
			}
			Da -= damage;

			return true;
		}
        public override void NPCLoot()
        {
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 74,591);
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 73,60);
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 72,15);
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 71,3);
		}
        public override void FindFrame(int frameHeight)
		{
			if (Seven)
			{
				fw = 5;
			}
			else
			{
				fw = 10;
			}
			npc.frameCounter++;
			RR = npc.frame.Y / 78;
			if (!One && !Two && !Three)
			{
				if (npc.frameCounter >= 10)
				{
					npc.frameCounter = 0;
					npc.frame.Y = npc.frame.Y + 78;
				}
				if (npc.frame.Y >= 468)
				{
					npc.frame.Y = 0;
				}
			}
			if (One)
			{
				if (npc.frameCounter >= fw)
				{
					npc.frameCounter = 0;
					npc.frame.Y = npc.frame.Y + 78;
				}
				if (npc.frame.Y >= 780)
				{
					HH = true;
					npc.frame.Y = 0;
				}
			}
			if (Two)
			{
				if (npc.frameCounter >= fw)
				{
					npc.frameCounter = 0;
					npc.frame.Y = npc.frame.Y + 78;
				}
				if (npc.frame.Y >= 1560)
				{
					HH = true;
					npc.frame.Y = 780;
				}

			}
			if (Three)
			{
				if (npc.frameCounter >= 10)
				{
					npc.frameCounter = 0;
					npc.frame.Y = npc.frame.Y + 78;
				}
				if (npc.frame.Y >= 2496)
				{
					HH = true;
					npc.frame.Y = 1560;
				}
			}
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 1f * bossLifeScale);
			npc.damage = (int)(npc.damage * 1f);
		}
		int attack1Dla = 1200;
		public override void AI()
		{
			npc.TargetClosest();
			Player player = Main.player[npc.target];
			Vector2 direction = Main.player[npc.target].Center - npc.Center;
			npc.spriteDirection = npc.direction;
			direction.Normalize();
			direction.X *= 14f;
			direction.Y *= 14f;

			/*if (attack1Dla >= 0)
			{
				attack1Dla--;
				//limiting circle
				if (attack1Dla % 15 == 0)
				{
					for (int i = 1; i <= 560; i++)
					{
						Vector2 position = npc.Center;
						float r = i / 280f * MathHelper.Pi;
						Vector2 Range = new Vector2(position.X + (float)Math.Cos(r) * 600f, position.Y + (float)Math.Sin(r) * 600f);
						Color G = new Color((int)(255 * (1 - attack1Dla / 120f)), 0, 0);
						Dust dust = Dust.NewDustPerfect(Range, 263, new Vector2(0f, 0f), 0,G, 2.302632f);
						dust.noGravity = true;
					}
				}
				return;
			}*/
			if (Da <= 1000)
			{
				Da += 15;
			}
			if (Main.player[npc.target].dead)
			{
				npc.active = false;
			}
			if (!Six)
			{
				if (npc.life < npc.lifeMax / 2)
				{
					Four = false;
					Six = true;
					One = false;
					Two = false;
					Three = false;
				}
			}
			if (Four)
			{
				HS();
			}
			if (Seven)
			{
				Hh();
			}
			if (!Main.player[npc.target].dead)
			{
				if (Fives)
				{
					Timer5++;
					npc.dontTakeDamage = true;
					Vector2 vector4 = Vector2.Subtract(player.Center - new Vector2(0, 200f), npc.Center);
					float A = 20f;
					vector4.Normalize();
					vector4 *= A;
					npc.velocity = (npc.velocity * 8 + vector4) / 10;
					if (Timer5 == 300)
					{
						CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), new Color(255, 255, 255), Language.GetTextValue(GameCulture.Chinese.IsActive ? "又来个挑战者" : "Another challenger"), true, false);
					}
					if (Timer5 == 400)
					{
						CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), new Color(255, 255, 255), Language.GetTextValue(GameCulture.Chinese.IsActive ? "300秒够吗？" : "300 seconds should be enough"), true, false);
					}
					if (Timer5 == 500)
					{
						CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), new Color(255, 255, 255), Language.GetTextValue(GameCulture.Chinese.IsActive ? "应该够了吧" : "Should be enough"), true, false);
					}
					if (Timer5 == 600)
					{
						CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), new Color(255, 255, 255), Language.GetTextValue(GameCulture.Chinese.IsActive ? "来吧,试一试你" : "Come on, try you"), true, false);
						Four = true;
						Fives = false;
						Timer5 = 0;
					}
				}
				if(Six)
                {
					Timer5++;
					if (Timer5 == 1)
                    {
						npc.dontTakeDamage = true;
						npc.velocity *= 0;
					}
					if (Timer5 == 100)
					{
						CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), new Color(255, 255, 255), Language.GetTextValue(GameCulture.Chinese.IsActive ? "呃啊,我没有史莱姆亡": "Uh, I have no dead Slime (Slimy Saddle)"), true, false);
					}
					if (Timer5 == 200)
					{
						CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), new Color(255, 255, 255), Language.GetTextValue(GameCulture.Chinese.IsActive ? "我还以为我有史莱姆亡" : "I thought I had a dead Slime (Slimy Saddle)"), true, false);
					}
					if (Timer5 == 300)
					{
						CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), new Color(255, 255, 255), Language.GetTextValue(GameCulture.Chinese.IsActive ? "你真是超难的" : "You are so hard"), true, false);
					}
					if (Timer5 == 400)
					{
						CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), new Color(255, 255, 255), Language.GetTextValue(GameCulture.Chinese.IsActive ? "手没了就好很多" : "It's much better without hands"), true, false);
					}
					if (Timer5 == 500)
					{
						CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), new Color(255, 255, 255), Language.GetTextValue(GameCulture.Chinese.IsActive ? "可以庄心的召唤这个佝偻头" : "You can summon this rickety head solemnly"), true, false);
					}
					if (Timer5 == 600)
					{
						CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), new Color(255, 255, 255), Language.GetTextValue(GameCulture.Chinese.IsActive ? "来吧,再来试一试你" : "Come on, try you again"), true, false);
						npc.dontTakeDamage = false;
						Seven = true;
					}
				}
			}
		}
		public void Hh()
        {

			Player player = Main.player[npc.target];
			Timer4++;
			if (Timer4 == 1800)
			{
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y - 10, mod.NPCType("星星炮"), 0, 0);
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y - 10, mod.NPCType("星星炮"), 0, 1);
				Timer4 = 0;
			}
			npc.dontTakeDamage = false;
			if (!One && !Two && !Three && !S2)
			{
				int A = new Random().Next(1, 5);
				{
					if (A == 1)
					{
						One = true;
					}
					if (A == 2)
					{
						Two = true;
					}
					if (A == 3)
					{
						Three = true;
					}
					if(A == 4)
                    {
						S2 = true;
                    }
				}
			}
			if (One)
			{
				Timer3++;
				if (Timer3 >= 600)
				{
					One = false;
					Timer3 = 0;
				}
				Vector2 vector4 = Vector2.Subtract(player.Center - new Vector2(-500, 0f), npc.Center);
				float A = 20f;
				vector4.Normalize();
				vector4 *= A;
				npc.velocity = (npc.velocity * 8 + vector4) / 10;
				if (RR == 9 && HH)
				{
					Vector2 velocity = Main.player[npc.target].Center - npc.Center;
					velocity.Normalize();
					velocity *= 20;
					Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<雷击>(), 200, 0, 0);
					float rotation = MathHelper.ToRadians(30f);
					int numProj = 2;
					for (int i = 0; i < numProj; i++)
					{
						Vector2 perturbedSpeed = Utils.RotatedBy(velocity, MathHelper.Lerp(-rotation, rotation, i), default);
						Projectile.NewProjectile(npc.Center, perturbedSpeed, ModContent.ProjectileType<雷击>(), 200, 0, 0);
					}
					HH = false;
				}
			}
			if (Two)
			{
				Timer3++;
				if (Timer3 >= 600)
				{
					Two = false;
					Timer3 = 0;
				}
				Vector2 vector4 = Vector2.Subtract(player.Center - new Vector2(-500, 0f), npc.Center);
				float A = 20f;
				vector4.Normalize();
				vector4 *= A;
				npc.velocity = (npc.velocity * 8 + vector4) / 10;
				if (RR == 19 && HH)
				{
					Vector2 velocity = Main.player[npc.target].Center - npc.Center;
					velocity.Normalize();
					velocity *= 10;
					Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<飞锤>(), 150, 0, 0);
					HH = false;
				}
			}
			if (Three)
			{
				Timer3++;
				Timer++;
				if (Timer3 >= 720)
				{
					Three = false;
					Timer3 = 0;
				}
				if ((RR >= 24 && RR <= 25) || (RR >= 31 && RR <= 32))
				{
					Vector2 vector4 = Vector2.Subtract(player.Center - new Vector2(0, 0f), npc.Center);
					float A = 20f;
					vector4.Normalize();
					vector4 *= A;
					npc.velocity = (npc.velocity * 8 + vector4) / 10;
				}
				if (RR == 27 && HH)
				{
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, ModContent.ProjectileType<抡锤>(), 150, 0, 0);
					HH = false;
				}
			}
			if(S2)
            {
				Timer3++;
				if (Timer3 >= 600)
				{
					S2 = false;
					Timer3 = 0;
				}
				Vector2 vector4 = Vector2.Subtract(player.Center - new Vector2(0, 300f), npc.Center);
				float A = 20f;
				vector4.Normalize();
				vector4 *= A;
				npc.velocity = (npc.velocity * 8 + vector4) / 10;
				if (Timer3 == 1)
				{
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, ModContent.ProjectileType<史莱姆亡冠>(), 80, 1, 0);
				}
				Timer2++;
				if (Timer2 >= 100)
				{
					Timer2 = 0;
					Projectile.NewProjectile(player.position.X - 1000, player.position.Y - Main.rand.Next(-500, 500), Main.rand.Next(2, 4), 0, ModContent.ProjectileType<佝偻头>(), 9999, 1, 0);
					Projectile.NewProjectile(player.position.X - Main.rand.Next(-500, 500), player.position.Y - 1000, 0, Main.rand.Next(2, 4), ModContent.ProjectileType<佝偻头>(), 9999, 1, 0);
					Projectile.NewProjectile(player.position.X + 1000, player.position.Y - Main.rand.Next(-500, 500), Main.rand.Next(-4, -2), 0, ModContent.ProjectileType<佝偻头>(), 9999, 1, 0);
					Projectile.NewProjectile(player.position.X - Main.rand.Next(-500, 500), player.position.Y + 1000, 0, Main.rand.Next(-4, -2), ModContent.ProjectileType<佝偻头>(), 9999, 1, 0);
				}
			}
		}
		public void HS()
		{
			Player player = Main.player[npc.target];
			Timer4++;
			if (Timer4 == 1800)
			{
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y - 10, mod.NPCType("星星炮"), 0, 0);
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y - 10, mod.NPCType("星星炮"), 0, 1);
				Timer4 = 0;
			}
			npc.dontTakeDamage = false;
			if (!One && !Two && !Three)
			{
				int A = new Random().Next(1, 4);
				{
					if (A == 1)
					{
						One = true;
					}
					if (A == 2)
					{
						Two = true;
					}
					if (A == 3)
					{
						Three = true;
					}
				}
			}
			if (One)
			{
				Timer3++;
				if (Timer3 >= 600)
				{
					One = false;
					Timer3 = 0;
				}
				Vector2 vector4 = Vector2.Subtract(player.Center - new Vector2(-500, 0f), npc.Center);
				float A = 20f;
				vector4.Normalize();
				vector4 *= A;
				npc.velocity = (npc.velocity * 8 + vector4) / 10;
				if (RR == 9 && HH)
				{
					Vector2 velocity = Main.player[npc.target].Center - npc.Center;
					velocity.Normalize();
					velocity *= 20;
					Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<雷击>(), 150, 0, 0);
					HH = false;
				}
			}
			if (Two)
			{
				Timer3++;
				if (Timer3 >= 600)
				{
					Two = false;
					Timer3 = 0;
				}
				Vector2 vector4 = Vector2.Subtract(player.Center - new Vector2(-500, 0f), npc.Center);
				float A = 10f;
				vector4.Normalize();
				vector4 *= A;
				npc.velocity = (npc.velocity * 8 + vector4) / 10;
				if (RR == 19 && HH)
				{
					Vector2 velocity = Main.player[npc.target].Center - npc.Center;
					velocity.Normalize();
					velocity *= 20;
					Projectile.NewProjectile(npc.Center, velocity, ModContent.ProjectileType<飞锤>(), 150, 0, 0);
					HH = false;
				}
			}
			if (Three)
			{
				Timer3++;
				Timer++;
				if (Timer3 >= 720)
				{
					Three = false;
					Timer3 = 0;
				}
				if ((RR >= 24 && RR <= 25) || (RR >= 31 && RR <= 32))
				{
					Vector2 vector4 = Vector2.Subtract(player.Center - new Vector2(0, 0f), npc.Center);
					float A = 20f;
					vector4.Normalize();
					vector4 *= A;
					npc.velocity = (npc.velocity * 8 + vector4) / 10;
				}
				if (RR == 27 && HH)
				{
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, ModContent.ProjectileType<抡锤>(), 150, 0, 0);
					HH = false;
				}
			}
		}
		public override void HitEffect(int hitDirection, double damage)
        {
			if (npc.life <= 0)
			{
				CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), new Color(255, 255, 255), Language.GetTextValue(GameCulture.Chinese.IsActive ? "亡了亡了,你一定作弊了" : "Dead dead, you must have cheated"), true, false);
			}
		}
	}
}