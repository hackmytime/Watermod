using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Watermod.Items;

namespace Watermod.NPCs.诅咒邪锤
{
    [AutoloadBossHead]
    public class 诅咒邪锤 : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Evil Hammer");
			DisplayName.AddTranslation(GameCulture.Chinese, "诅咒邪锤");
            Main.npcFrameCount[npc.type] = 6;
        }
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.15000000596046448;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
        }
        public override void SetDefaults()
		{
            npc.aiStyle = -1;
            npc.lifeMax = 20000;
            npc.damage = 150;
            npc.defense = 30;
            npc.knockBackResist = 0f;
            npc.width = 82;
            npc.height = 82;
            npc.npcSlots = 3;
            npc.value = Item.buyPrice(0, 1, 0, 0);
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            //music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/花岗岩核心");
            npc.HitSound = SoundID.Item2;
            npc.DeathSound = SoundID.NPCDeath6;
            npc.buffImmune[24] = true;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.66f * bossLifeScale);
        }
        public override void BossHeadRotation(ref float rotation)
        {
            rotation = npc.rotation + 0.785f;
        }
        public override void NPCLoot()
        {
        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            name = "被诅咒的锤子";
        }
        
        private int Timer;
        private int Timer2;
        private int Timer3;
        private int Timer4;
        private double Da;
        private int JJ;
        public int[] I;
        private bool D;
        public float E;
        public bool Bool;
        public bool Bool2;
        public bool One = true;
        public bool Two =false;
        public bool Three =false;
        public bool Four =false;
        public bool Fives = false;
        public bool Six = false;
        public bool Seven = false;
        public override bool StrikeNPC(ref double damage, int defense, ref float knockback, int hitDirection, ref bool crit)
        {
            if(damage >= Da)
            {
                damage = Da;
            }
            Da -= damage;
            return true;
        }
        public override void AI()
        {
            npc.TargetClosest(true);
            npc.timeLeft = 500;
            if (Da <= 1000)
            {
                Da += 18;
            }
            if (Main.player[npc.target].dead)
            {
                npc.active = false;
            }
            Timer2++;
            Timer3++;
            if (One)
            {
                one();
            }
            if (Two)
            {
                music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/诅咒");
                Main.player[npc.target].wingTime++;
                two();
            }
            if (Three)
            {
                three();
                Main.player[npc.target].wingTime++;
            }
            if (Four)
            {
                four();
                Main.player[npc.target].wingTime++;
            }
            if (Fives)
            {
                fives();
                Main.player[npc.target].wingTime++;
            }
            if (Six)
            {
                six();
                Main.player[npc.target].wingTime++;
            }
            if (Seven)
            {
                seven();
                Main.player[npc.target].wingTime++;
            }
            if(Bool)
            {
                Si();
            }
        }
        public void seven()
        {
            Timer++;
            Player player = Main.player[npc.target];
            int H = Utils.SelectRandom(Main.rand, new int[]
            {
                Main.rand.Next(200,400),
                Main.rand.Next(-400,-200)
            });
            if (Timer < 60)
            {
                E += 0.6f;
                npc.rotation = E;
                npc.velocity *= 0;
            }
            if (Timer == 60)
            {
                Vector2 vector = player.Center - npc.Center;
                vector.Normalize();
                npc.velocity = vector * 15;
                npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X) + 0.785f);
            }
            if (Timer == 119)
            {
                for (int A = 0; A < 50; A++)
                {
                    Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 173, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);
                }
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 8, 0, ModContent.ProjectileType<诅咒锤>(), 100, 1, 0, 0, 2);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 8, ModContent.ProjectileType<诅咒锤>(), 100, 1, 0, 0, 2);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -8, 0, ModContent.ProjectileType<诅咒锤>(), 100, 1, 0, 0, 2);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, -8, ModContent.ProjectileType<诅咒锤>(), 100, 1, 0, 0, 2);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 8, 8, ModContent.ProjectileType<诅咒锤>(), 100, 1, 0, 0, 2);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -8, -8, ModContent.ProjectileType<诅咒锤>(), 100, 1, 0, 0, 2);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -8, 8, ModContent.ProjectileType<诅咒锤>(), 100, 1, 0, 0, 2);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 8, -8, ModContent.ProjectileType<诅咒锤>(), 100, 1, 0, 0, 2);
                npc.position.X = player.Center.X + H;
                npc.position.Y = player.Center.Y + H;
            }
            if (Timer == 120)
            {
                Vector2 vector = player.Center - npc.Center;
                vector.Normalize();
                npc.velocity = vector * 15;
                npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X) + 0.785f);
            }
            if (Timer == 179)
            {
                for (int A = 0; A < 50; A++)
                {
                    Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 173, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);
                }
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 8, 0, ModContent.ProjectileType<诅咒锤>(), 100, 1, 0, 0, 2);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 8, ModContent.ProjectileType<诅咒锤>(), 100, 1, 0, 0, 2);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -8, 0, ModContent.ProjectileType<诅咒锤>(), 100, 1, 0, 0, 2);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, -8, ModContent.ProjectileType<诅咒锤>(), 100, 1, 0, 0, 2);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 8, 8, ModContent.ProjectileType<诅咒锤>(), 100, 1, 0, 0, 2);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -8, -8, ModContent.ProjectileType<诅咒锤>(), 100, 1, 0, 0, 2);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -8, 8, ModContent.ProjectileType<诅咒锤>(), 100, 1, 0, 0, 2);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 8, -8, ModContent.ProjectileType<诅咒锤>(), 100, 1, 0, 0, 2);
                npc.position.X = player.Center.X + H;
                npc.position.Y = player.Center.Y + H;
            }
            if (Timer == 180)
            {
                Vector2 vector = player.Center - npc.Center;
                vector.Normalize();
                npc.velocity = vector * 15;
                npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X) + 0.785f);
            }
            if (Timer == 239)
            {
                for (int A = 0; A < 50; A++)
                {
                    Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 173, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);
                }
                float P = 0.783f;
                double O = Math.Atan2(Main.rand.Next(-15, 15), Main.rand.Next(-15, 15)) - P / 2f;
                double U = P / 8f;
                float B = 5;
                for (int i = 0; i < 5; i++)
                {
                    double M = O + U * (i + i * i) / 2.0 + 32f * i;
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)(Math.Sin(M) * B), (float)(Math.Cos(M) * B), ModContent.ProjectileType<诅咒锤>(), 100, 1f, 0, 0, 2);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)(-(float)Math.Sin(M) * B), (float)(-(float)Math.Cos(M) * B), ModContent.ProjectileType<诅咒锤>(), 100, 1f, 0, 0, 2);
                }
            }
            if (Timer == 240)
            {
                Vector2 vector = player.Center - npc.Center;
                vector.Normalize();
                npc.velocity = vector * 15;
                npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X) + 0.785f);
            }
            if (Timer == 299)
            {
                for (int A = 0; A < 50; A++)
                {
                    Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 173, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);
                }
                float P = 0.783f;
                double O = Math.Atan2(Main.rand.Next(-15, 15), Main.rand.Next(-15, 15)) - P / 2f;
                double U = P / 8f;
                float B = 5;
                for (int i = 0; i < 5; i++)
                {
                    double M = O + U * (i + i * i) / 2.0 + 32f * i;
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)(Math.Sin(M) * B), (float)(Math.Cos(M) * B), ModContent.ProjectileType<诅咒锤>(), 100, 1f, 0, 0, 2);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)(-(float)Math.Sin(M) * B), (float)(-(float)Math.Cos(M) * B), ModContent.ProjectileType<诅咒锤>(), 100, 1f, 0, 0, 2);
                }
                npc.position.X = player.Center.X + H;
                npc.position.Y = player.Center.Y + H;
            }
            if(Timer < 300)
            {
                Timer4++;
                if (Timer4 >= 5)
                {
                    Timer4 = 0;
                    float P = 0.783f;
                    double O = Math.Atan2(Main.rand.Next(-15, 15), Main.rand.Next(-15, 15)) - P / 2f;
                    double U = P / 8f;
                    float B = 5;
                    double M = O + U * (3 + 3 * 3) / 2.0 + 32f * 3;
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)(Math.Sin(M) * B), (float)(Math.Cos(M) * B), ModContent.ProjectileType<诅咒锤>(), 100, 1f, 0, 0, 2);
                }
            }
            if (Timer > 300 && Timer < 800)
            {
                E += 0.6f;
                npc.rotation = E;
                npc.velocity *= 0;
                if (Timer2 >= 30)
                {
                    Timer2 = 0;
                    float P = 0.783f;
                    double O = Math.Atan2(Main.rand.Next(-15, 15), Main.rand.Next(-15, 15)) - P / 2f;
                    double U = P / 8f;
                    float B = 5;
                    for (int i = 0; i < 5; i++)
                    {
                        double M = O + U * (i + i * i) / 2.0 + 32f * i;
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)(Math.Sin(M) * B), (float)(Math.Cos(M) * B), ModContent.ProjectileType<诅咒锤>(), 100, 1f, 0, 0, 2);
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)(-(float)Math.Sin(M) * B), (float)(-(float)Math.Cos(M) * B), ModContent.ProjectileType<诅咒锤>(), 100, 1f, 0, 0, 2);
                    }
                    npc.position.X = player.Center.X + H;
                    npc.position.Y = player.Center.Y + H;
                }
            }
            if (Timer == 800)
            {
                D = true;
                Timer2 = 0;
            }
            if (D)
            {
                E += 3f;
                npc.rotation = E;
                if (Timer2 >= 5)
                {
                    Timer2 = 0;
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)(Math.Cos(npc.rotation - 0.785) * 7), (float)(Math.Sin(npc.rotation - 0.785) * 7), ModContent.ProjectileType<诅咒锤>(), 100, 1f, 0, 0, 2);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)(Math.Cos(npc.rotation - 1.516) * 7), (float)(Math.Sin(npc.rotation - 1.516) * 7), ModContent.ProjectileType<诅咒锤>(), 100, 1f, 0, 0, 2);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)(Math.Cos(npc.rotation - 2.355) * 7), (float)(Math.Sin(npc.rotation - 2.355) * 7), ModContent.ProjectileType<诅咒锤>(), 100, 1f, 0, 0, 2);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)(Math.Cos(npc.rotation - 3.032) * 7), (float)(Math.Sin(npc.rotation - 3.032) * 7), ModContent.ProjectileType<诅咒锤>(), 100, 1f, 0, 0, 2);
                }
            }
            if (Timer == 1401)
            {
                D = false;
                Timer = 0;
            }
        }
        public void six()
        {
            Timer++;
            Color color = new Color(208, 86, 201);
            if (Timer == 1)
            {
                npc.dontTakeDamage = true;
                npc.velocity *= 0;
                npc.rotation = 0;
                D = false;
            }
            if (Timer == 60)
            {
                CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), color, GameCulture.Chinese.IsActive ? "等一等,这个前缀不给力": "this prefix is freaking stupid", true, false);
            }
            if (Timer == 120)
            {
                CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), color, GameCulture.Chinese.IsActive ? "容我再重铸一下" : "Let me Reforge a few times", true, false);
            }
            if (Timer >= 172 && Timer <= 180)
            {
                E += 0.1f;
                npc.rotation = E;
            }
            if (Timer == 180 && JJ==0)
            {
                CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), new Color(55, 55, 55), (GameCulture.Chinese.IsActive ? "碎裂 " : "Broken ") + npc.FullName, true, false);
                npc.rotation = 0;
                npc.scale = 1;
                Timer = 160;
                JJ += 1;
            }
            if (Timer == 180 && JJ==1)
            {
                CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), new Color(55, 55, 55), (GameCulture.Chinese.IsActive ? "粗劣 " : "Shoddy ") + npc.FullName, true, false);
                npc.rotation = 0;
                Timer = 160;
                JJ += 1;
            }
            if (Timer == 180 && JJ==2)
            {
                CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), new Color(155, 155, 155), (GameCulture.Chinese.IsActive ? "小 " : "Small ") + npc.FullName, true, false);
                npc.rotation = 0;
                npc.scale = 0.5f;
                Timer = 160;
                JJ += 1;
            }
            if (Timer == 180 && JJ==3)
            {
                CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), color, (GameCulture.Chinese.IsActive ? "传奇 " : "Legendary ") + npc.FullName, true, false);
                npc.rotation = 0;
                npc.scale = 1.25f;
                JJ += 1;
            }
            if(Timer == 240)
            {
                CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), color, (GameCulture.Chinese.IsActive ? "总算出来了" : "Finally figured it out"), true, false);
            }
            if (Timer == 300)
            {
                CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), color, (GameCulture.Chinese.IsActive ? "那就来看看我的最强形态吧!" : "Then take a look at my strongest form!"), true, false);
                Seven = true;
                Six = false;
                Timer = 0;
                Timer2 = 0;
                Timer3 = 0;
                npc.dontTakeDamage = false;
            }
        }
        public void fives()
        {
            Player player = Main.player[npc.target];
            int H = Utils.SelectRandom(Main.rand, new int[]
            {
                Main.rand.Next(200,400),
                Main.rand.Next(-400,-200)
            });
            Timer++;
            if (Timer < 60)
            {
                E += 0.6f;
                npc.rotation = E;
                npc.velocity *= 0;
            }
            if (Timer == 60)
            {
                Vector2 vector = player.Center-npc.Center;
                vector.Normalize();
                npc.velocity = vector*15;
                npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X) + 0.785f);
            }
            if (Timer == 119)
            {
                for (int A = 0; A < 50; A++)
                {
                    Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 173, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);
                }
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 8, 0, ModContent.ProjectileType<诅咒锤>(), 100, 1, 0, 0, 1);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 8, ModContent.ProjectileType<诅咒锤>(), 100, 1, 0, 0, 1);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -8, 0, ModContent.ProjectileType<诅咒锤>(), 100, 1, 0, 0, 1);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, -8, ModContent.ProjectileType<诅咒锤>(), 100, 1, 0, 0, 1);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 8, 8, ModContent.ProjectileType<诅咒锤>(), 100, 1, 0, 0, 1);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -8, -8, ModContent.ProjectileType<诅咒锤>(), 100, 1, 0, 0, 1);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -8, 8, ModContent.ProjectileType<诅咒锤>(), 100, 1, 0, 0, 1);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 8, -8, ModContent.ProjectileType<诅咒锤>(), 100, 1, 0, 0, 1);
                npc.position.X = player.Center.X + H;
                npc.position.Y = player.Center.Y + H;
            }
            if (Timer == 120)
            {
                Vector2 vector = player.Center - npc.Center;
                vector.Normalize();
                npc.velocity = vector * 15;
                npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X) + 0.785f);
            }
            if (Timer == 179)
            {
                for (int A = 0; A < 50; A++)
                {
                    Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 173, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);
                }
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 8, 0, ModContent.ProjectileType<诅咒锤>(), 100, 1, 0, 0, 1);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 8, ModContent.ProjectileType<诅咒锤>(), 100, 1, 0, 0, 1);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -8, 0, ModContent.ProjectileType<诅咒锤>(), 100, 1, 0, 0, 1);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, -8, ModContent.ProjectileType<诅咒锤>(), 100, 1, 0, 0, 1);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 8, 8, ModContent.ProjectileType<诅咒锤>(), 100, 1, 0, 0, 1);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -8, -8, ModContent.ProjectileType<诅咒锤>(), 100, 1, 0, 0, 1);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -8, 8, ModContent.ProjectileType<诅咒锤>(), 100, 1, 0, 0, 1);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 8, -8, ModContent.ProjectileType<诅咒锤>(), 100, 1, 0, 0, 1);
                npc.position.X = player.Center.X + H;
                npc.position.Y = player.Center.Y + H;
            }
            if (Timer == 180)
            {
                Vector2 vector = player.Center - npc.Center;
                vector.Normalize();
                npc.velocity = vector * 15;
                npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X) + 0.785f);
            }
            if (Timer == 239)
            {
                for (int A = 0; A < 50; A++)
                {
                    Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 173, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);
                }
                float P = 0.783f;
                double O = Math.Atan2(Main.rand.Next(-15, 15), Main.rand.Next(-15, 15)) - P / 2f;
                double U = P / 8f;
                float B = 5;
                for (int i = 0; i < 5; i++)
                {
                    double M = O + U * (i + i * i) / 2.0 + 32f * i;
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)(Math.Sin(M) * B), (float)(Math.Cos(M) * B), ModContent.ProjectileType<诅咒锤>(), 100, 1f, 0, 0, 1);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)(-(float)Math.Sin(M) * B), (float)(-(float)Math.Cos(M) * B), ModContent.ProjectileType<诅咒锤>(), 100, 1f, 0, 0, 1);
                }
            }
            if (Timer == 240)
            {
                Vector2 vector = player.Center - npc.Center;
                vector.Normalize();
                npc.velocity = vector * 15;
                npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X) + 0.785f);
            }
            if (Timer == 299)
            {
                for (int A = 0; A < 50; A++)
                {
                    Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 173, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);
                }
                float P = 0.783f;
                double O = Math.Atan2(Main.rand.Next(-15, 15), Main.rand.Next(-15, 15)) - P / 2f;
                double U = P / 8f;
                float B = 5;
                for (int i = 0; i < 5; i++)
                {
                    double M = O + U * (i + i * i) / 2.0 + 32f * i;
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)(Math.Sin(M) * B), (float)(Math.Cos(M) * B), ModContent.ProjectileType<诅咒锤>(), 100, 1f, 0, 0, 1);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)(-(float)Math.Sin(M) * B), (float)(-(float)Math.Cos(M) * B), ModContent.ProjectileType<诅咒锤>(), 100, 1f, 0, 0, 1);
                }
                npc.position.X = player.Center.X + H;
                npc.position.Y = player.Center.Y + H;
            }
            if (Timer > 300 && Timer < 360)
            {
                E += 0.6f;
                npc.rotation = E;
                npc.velocity *= 0;
            }
            if(Timer == 360)
            {
                Vector2 vector = player.Center - npc.Center;
                vector.Normalize();
                vector += player.velocity / 22;
                npc.velocity = vector * 15;
                npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X) + 0.785f);
            }
            if (Timer == 400)
            {
                float P = 0.783f;
                double O = Math.Atan2(Main.rand.Next(-15, 15), Main.rand.Next(-15, 15)) - P / 2f;
                double U = P / 8f;
                float B = 5;
                for (int i = 0; i < 5; i++)
                {
                    double M = O + U * (i + i * i) / 2.0 + 32f * i;
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)(Math.Sin(M) * B), (float)(Math.Cos(M) * B), ModContent.ProjectileType<诅咒锤>(), 100, 1f, 0, 0, 1);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)(-(float)Math.Sin(M) * B), (float)(-(float)Math.Cos(M) * B), ModContent.ProjectileType<诅咒锤>(), 100, 1f, 0, 0, 1);
                }
                Vector2 vector = player.Center - npc.Center;
                vector.Normalize();
                npc.velocity = vector * 15;
                npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X) + 0.785f);
            }
            if (Timer == 460)
            {
                float P = 0.783f;
                double O = Math.Atan2(Main.rand.Next(-15, 15), Main.rand.Next(-15, 15)) - P / 2f;
                double U = P / 8f;
                float B = 5;
                for (int i = 0; i < 5; i++)
                {
                    double M = O + U * (i + i * i) / 2.0 + 32f * i;
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)(Math.Sin(M) * B), (float)(Math.Cos(M) * B), ModContent.ProjectileType<激光提示>(), 100, 1f, 0, 0, 0);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)(-(float)Math.Sin(M) * B), (float)(-(float)Math.Cos(M) * B), ModContent.ProjectileType<激光提示>(), 100, 1f, 0, 0, 0);
                }
                Vector2 vector = player.Center - npc.Center;
                vector.Normalize();
                npc.velocity = vector * 15;
                npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X) + 0.785f);
            }
            if (Timer == 520)
            {
                float P = 0.783f;
                double O = Math.Atan2(Main.rand.Next(-15, 15), Main.rand.Next(-15, 15)) - P / 2f;
                double U = P / 8f;
                float B = 5;
                for (int i = 0; i < 5; i++)
                {
                    double M = O + U * (i + i * i) / 2.0 + 32f * i;
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)(Math.Sin(M) * B), (float)(Math.Cos(M) * B), ModContent.ProjectileType<诅咒锤>(), 100, 1f, 0, 0, 1);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)(-(float)Math.Sin(M) * B), (float)(-(float)Math.Cos(M) * B), ModContent.ProjectileType<诅咒锤>(), 100, 1f, 0, 0, 1);
                }
                Vector2 vector = player.Center - npc.Center;
                vector.Normalize();
                npc.velocity = vector * 15;
                npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X) + 0.785f);
            }
            if (Timer == 580)
            {
                float P = 0.783f;
                double O = Math.Atan2(Main.rand.Next(-15, 15), Main.rand.Next(-15, 15)) - P / 2f;
                double U = P / 8f;
                float B = 5;
                for (int i = 0; i < 5; i++)
                {
                    double M = O + U * (i + i * i) / 2.0 + 32f * i;
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)(Math.Sin(M) * B), (float)(Math.Cos(M) * B), ModContent.ProjectileType<激光提示>(), 100, 1f, 0, 0, 0);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)(-(float)Math.Sin(M) * B), (float)(-(float)Math.Cos(M) * B), ModContent.ProjectileType<激光提示>(), 100, 1f, 0, 0, 0);
                }
            }
            if (Timer > 580 && Timer<660)
            {
                Vector2 direction = Main.player[npc.target].Center - npc.Center;
                npc.rotation = (float)Math.Atan2(direction.Y + 0.785, direction.X + 0.785);
                npc.velocity *= 0;
            }
            if (Timer == 720)
            {
                D = true;
                Timer2 = 0;
            }
            if (D)
            {
                Vector2 direction = Main.player[npc.target].Center-npc.Center;
                direction.Normalize();
                E = (float)Math.Atan2(direction.Y, direction.X);
                npc.rotation = npc.rotation+E;
                Timer2 ++;
                if (Timer2 % 30==1)
                {
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)Math.Cos(npc.rotation - 0.785), (float)Math.Sin(npc.rotation - 0.785), ModContent.ProjectileType<诅咒激光>(), 100, 1f, 0, 2);
                }
            }
            if (Timer == 1500)
            {
                D = false;
                Timer = 0;
            }
            if (npc.life < npc.lifeMax * 0.333)
            {
                Six = true;
                Fives = false;
                Timer = 0;
                Timer2 = 0;
                Timer3 = 0;
            }
        }
        public void four()
        {
            Timer++;
            Color color = new Color(208, 86, 201);
            if (Timer == 1)
            {
                D = false;
                npc.dontTakeDamage = true;
                npc.velocity *= 0;
                npc.rotation = 0;
            }
            if (Timer == 60)
            {
                CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), color, GameCulture.Chinese.IsActive ? "等等！": "Stop!", true, false);
            }
            if (Timer == 120)
            {
                CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), color, GameCulture.Chinese.IsActive ? "容我重铸一下" : "Let me recast", true, false);
            }
            if(Timer >= 172 && Timer<= 180)
            {
                E += 0.1f;
                npc.rotation = E;
            }
            if(Timer == 180)
            {
                CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), new Color(155, 155, 155), (GameCulture.Chinese.IsActive ? "微小 " : "Tiny ") + npc.FullName, true, false);
                npc.scale = 0.8f;
                npc.rotation = 0;
            }
            if(Timer == 240)
            {
                CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), color, GameCulture.Chinese.IsActive ? "呃,不对!" : "Uh, that's not right!", true, false);
            }
            if (Timer >= 292 && Timer <= 300)
            {
                E += 0.1f;
                npc.rotation = E;
            }
            if (Timer == 300)
            {
                CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), new Color(70, 70, 70), (GameCulture.Chinese.IsActive ? "破损 " : "Damaged ") + npc.FullName, true, false);
                npc.rotation = 0;
            }
            if(Timer == 360)
            {
                CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), color, GameCulture.Chinese.IsActive ? "啊,也不对！" : "Ah, not right!", true, false);
               
            }
            if (Timer >= 412 && Timer <= 420)
            {
                E += 0.1f;
                npc.rotation = E;
            }
            if (Timer == 420)
            {
                CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), color, (GameCulture.Chinese.IsActive ? "传奇 " : "Legendary ") + npc.FullName, true, false);
                npc.scale = 1.25f;
                npc.damage = (int)(npc.damage *1.2f);
                npc.rotation = 0;
            }
            if (Timer >= 472 && Timer <= 480)
            {
                E += 0.1f;
                npc.rotation = E;
            }
            if (Timer == 480)
            {
                CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), color, (GameCulture.Chinese.IsActive ? "巨大 " : "Massive ") + npc.FullName, true, false);
                npc.scale = 1.5f;
                npc.damage = (int)(npc.damage *1.2f);
                npc.rotation = 0;
            }
            if (Timer == 540)
            {
                CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), color, (GameCulture.Chinese.IsActive ? "呃啊啊啊,算了" : "Uh ah ah, Forget it!"), true, false);
            }
            if (Timer == 600)
            {
                CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), color, (GameCulture.Chinese.IsActive ? "来吧！" : "bring it on!"), true, false);
                Fives = true;
                Four = false;
                Timer = 0;
                Timer2 = 0;
                Timer3 = 0;
                npc.dontTakeDamage = false;
            }
        }
        public void three()
        {
            Player player = Main.player[npc.target];
            int H = Utils.SelectRandom(Main.rand, new int[]
            {
                Main.rand.Next(200,400),
                Main.rand.Next(-400,-200)
            });
            Timer++;
            if (Timer < 60)
            {
                E += 0.6f;
                npc.rotation = E;
                npc.velocity *= 0;
            }
            if (Timer == 60)
            {
                Vector2 vector = player.Center - npc.Center;
                vector.Normalize();
                npc.velocity = vector * 15;
                npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X) + 0.785f);
            }
            if (Timer == 119)
            {
                for (int A = 0; A < 50; A++)
                {
                    Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height,173, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);
                }
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 8, 0, ModContent.ProjectileType<诅咒锤>(), 100, 1, 0);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 8, ModContent.ProjectileType<诅咒锤>(), 100, 1, 0);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -8, 0, ModContent.ProjectileType<诅咒锤>(), 100, 1, 0);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, -8, ModContent.ProjectileType<诅咒锤>(), 100, 1, 0);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 8, 8, ModContent.ProjectileType<诅咒锤>(), 100, 1, 0);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -8, -8, ModContent.ProjectileType<诅咒锤>(), 100, 1, 0);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -8, 8, ModContent.ProjectileType<诅咒锤>(), 100, 1, 0);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 8, -8, ModContent.ProjectileType<诅咒锤>(), 100, 1, 0);
                npc.position.X = player.Center.X + H;
                npc.position.Y = player.Center.Y + H;
            }
            if (Timer == 120)
            {
                Vector2 vector = player.Center - npc.Center;
                vector.Normalize();
                npc.velocity = vector * 15;
                npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X) + 0.785f);
            }
            if (Timer == 179)
            {
                for (int A = 0; A < 50; A++)
                {
                    Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height,173, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);
                }
                float P = 0.783f;
                double O = Math.Atan2(Main.rand.Next(-15, 15), Main.rand.Next(-15, 15)) - P / 2f;
                double U = P / 8f;
                float B = 5;
                for (int i = 0; i < 5; i++)
                {
                    double M = O + U * (i + i * i) / 2.0 + 32f * i;
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)(Math.Sin(M) * B), (float)(Math.Cos(M) * B), ModContent.ProjectileType<诅咒锤>(), 100, 1f, 0);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)(-(float)Math.Sin(M) * B), (float)(-(float)Math.Cos(M) * B), ModContent.ProjectileType<诅咒锤>(), 100, 1f, 0);
                }
                npc.position.X = player.Center.X + H;
                npc.position.Y = player.Center.Y + H;
            }
            if (Timer == 180)
            {
                Vector2 vector = player.Center - npc.Center;
                vector.Normalize();
                npc.velocity = vector * 15;
                npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X) + 0.785f);
            }
            if (Timer > 180 && Timer < 600)
            {
                E += 0.6f;
                npc.rotation = E;
                npc.velocity *= 0;
                if(Timer2 >= 30)
                {
                    Timer2 = 0;
                    float P = 0.783f;
                    double O = Math.Atan2(Main.rand.Next(-15, 15), Main.rand.Next(-15, 15)) - P / 2f;
                    double U = P / 8f;
                    float B = 5;
                    for (int i = 0; i < 5; i++)
                    {
                        double M = O + U * (i + i * i) / 2.0 + 32f * i;
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)(Math.Sin(M) * B), (float)(Math.Cos(M) * B), ModContent.ProjectileType<诅咒锤>(), 100, 1f, 0);
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)(-(float)Math.Sin(M) * B), (float)(-(float)Math.Cos(M) * B), ModContent.ProjectileType<诅咒锤>(), 100, 1f, 0);
                    }
                }
            }
            if (Timer == 600)
            {
                D = true;
                Timer2 = 0;
            }
            if(D)
            {
                E += 0.3f;
                npc.rotation = E;
                if (player.Distance(npc.Center) > 1000)
                {
                    Vector2 VV = player.Center - npc.Center;
                    VV.Normalize();
                    VV *= -10;
                    player.velocity = VV;
                }
                if (Timer2 >= 5)
                {
                    Timer2 = 0;
                    for (int i = 1; i <= 1000; i++)
                    {
                        Vector2 position = npc.Center;
                        float r = i / 280f * MathHelper.Pi;
                        Vector2 Range = new Vector2(position.X + (float)Math.Cos(r) * 1000f, position.Y + (float)Math.Sin(r) * 1000f);
                        Dust dust = Dust.NewDustPerfect(Range, 173, new Vector2(0f, 0f), 0, default, 2.302632f);
                        dust.noGravity = true;
                    }
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)(Math.Cos(npc.rotation - 0.785) * 7), (float)(Math.Sin(npc.rotation - 0.785) * 7), ModContent.ProjectileType<诅咒锤>(), 100, 1f, 0);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)(Math.Cos(npc.rotation - 3.925) * 7), (float)(Math.Sin(npc.rotation - 3.925) * 7), ModContent.ProjectileType<诅咒锤>(), 100, 1f, 0);
                }
            }
            if(Timer == 1201)
            {
                D = false;
                Timer = 0;
            }
            if (npc.life < npc.lifeMax * 0.666)
            {
                Four = true;
                Three  = false;
                Timer = 0;
                Timer2 = 0;
                Timer3 = 0;
            }
        }
        public void two()
        {
            Player player = Main.player[npc.target];
            Timer++;
            npc.position.X = player.position.X;
            npc.position.Y = player.position.Y - 200;
            Color color = new Color(208, 86, 201);
            if (Timer == 60)
            {
                CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), color, GameCulture.Chinese.IsActive ? "泰拉人,我就在你头上" : "Terrarian, I'm on your head", true, false);
            }
            if (Timer == 120)
            {
                CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), color, GameCulture.Chinese.IsActive ? "放心,我不会突然撞你" : "Don't worry, I won't hit you suddenly", true, false);
            }
            if (Timer == 180)
            {
                CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), color, (GameCulture.Chinese.IsActive ? "这一形态很简单" : "This form is very simple"), true, false);
            }
            if (Timer == 240)
            {
                CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), color, (GameCulture.Chinese.IsActive ? "你只要坚持住我这一套技能一分钟,我就让你挑战我的最终形态" : "As long as you hold on to my set of skills for one minute, I will let you challenge my final form"), true, false);
            }
            if (Timer == 300)
            {
                CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), color, (GameCulture.Chinese.IsActive ? "那么开始吧!" : "So let's get started!"), true, false);
                Projectile.NewProjectile(npc.Center.X - 2500, npc.Center.Y+10000,0, -1, ModContent.ProjectileType<巨大诅咒激光>(), 100, 1, 0);
                Projectile.NewProjectile(npc.Center.X + 2500, npc.Center.Y+10000, 0, -1, ModContent.ProjectileType<巨大诅咒激光>(), 100, 1, 0);
            }
            npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X) - 0.785f);
            if (Timer >= 300 && Timer <= 900)
            {
                if (Timer2 >= 30)
                {
                    Timer2 = 0;
                    Projectile.NewProjectile(player.position.X - 1000, player.position.Y - Main.rand.Next(-500, 500), Main.rand.Next(3, 6), 0, ModContent.ProjectileType<诅咒锤>(), 100, 1, 0);
                    Projectile.NewProjectile(player.position.X - Main.rand.Next(-500, 500), player.position.Y - 1000, 0, Main.rand.Next(3, 6), ModContent.ProjectileType<诅咒锤>(), 100, 1, 0);
                    Projectile.NewProjectile(player.position.X + 1000, player.position.Y - Main.rand.Next(-500, 500), Main.rand.Next(-6, -3), 0, ModContent.ProjectileType<诅咒锤>(), 100, 1, 0);
                    Projectile.NewProjectile(player.position.X - Main.rand.Next(-500, 500), player.position.Y + 1000, 0, Main.rand.Next(-6, -3), ModContent.ProjectileType<诅咒锤>(), 100, 1, 0);
                }
            }
            if (Timer == 1000)
            {
                Timer2 = 0;
                CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), color, (GameCulture.Chinese.IsActive ? "不错,但是不要掉以轻心哦." : "Not bad, but don't take it lightly"), true, false);
            }
            if (Timer >= 1100 && Timer <= 2100)
            {
                if (Timer2 >= 90)
                {
                    Timer2 = 0;
                    float P = 0.783f;
                    double U = P / 8f;
                    float B = 5;
                    for (int i = 0; i < 5; i++)
                    {
                        double M = U * (i + i * i) / 2.0 + 32f * i;
                        Projectile.NewProjectile(player.position.X - 1000, player.position.Y - Main.rand.Next(-500, 500), Main.rand.Next(3, 6), (float)(Math.Cos(M) * B), ModContent.ProjectileType<诅咒锤>(), 100, 1f, 0);
                        Projectile.NewProjectile(player.position.X - Main.rand.Next(-500, 500), player.position.Y - 1000, (float)(Math.Sin(M) * B), Main.rand.Next(3, 6), ModContent.ProjectileType<诅咒锤>(), 100, 1f, 0);
                        Projectile.NewProjectile(player.position.X + 1000, player.position.Y - Main.rand.Next(-500, 500), Main.rand.Next(-6, -3), (float)(Math.Cos(M) * B), ModContent.ProjectileType<诅咒锤>(), 100, 1f, 0);
                        Projectile.NewProjectile(player.position.X - Main.rand.Next(-500, 500), player.position.Y + 1000, (float)(Math.Sin(M) * B), Main.rand.Next(-6, -3), ModContent.ProjectileType<诅咒锤>(), 100, 1f, 0);
                    }
                }
            }
            if (Timer == 2200)
            {
                Timer2 = 0;
                CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), color, (GameCulture.Chinese.IsActive ? "针布戳,还有最后一段,小心了!." : "well done，the epilogue is coming!"), true, false);
            }
            if (Timer >= 2300 && Timer <= 3900)
            {
                if (Timer2 >= 90)
                {
                    Timer2 = 0;
                    Projectile.NewProjectile(player.position.X - 1000, player.position.Y - Main.rand.Next(-500, 500), Main.rand.Next(3, 6), 0, ModContent.ProjectileType<诅咒锤>(), 100, 1, 0);
                    Projectile.NewProjectile(player.position.X - Main.rand.Next(-500, 500), player.position.Y - 1000, 0, Main.rand.Next(3, 6), ModContent.ProjectileType<诅咒锤>(), 100, 1, 0);
                    Projectile.NewProjectile(player.position.X + 1000, player.position.Y - Main.rand.Next(-500, 500), Main.rand.Next(-6, -3), 0, ModContent.ProjectileType<诅咒锤>(), 100, 1, 0);
                    Projectile.NewProjectile(player.position.X - Main.rand.Next(-500, 500), player.position.Y + 1000, 0, Main.rand.Next(-6, -3), ModContent.ProjectileType<诅咒锤>(), 100, 1, 0);
                }
                if (Timer3 >= 150)
                {
                    Timer3 = 0;
                    float P = 0.783f;
                    double U = P / 8f;
                    float B = 5;
                    for (int i = 0; i < 5; i++)
                    {
                        double M = U * (i + i * i) / 2.0 + 32f * i;
                        Projectile.NewProjectile(player.position.X - 1000, player.position.Y - Main.rand.Next(-500, 500), Main.rand.Next(3, 6), (float)(Math.Cos(M) * B), ModContent.ProjectileType<诅咒锤>(), 100, 1f, 0);
                        Projectile.NewProjectile(player.position.X - Main.rand.Next(-500, 500), player.position.Y - 1000, (float)(Math.Sin(M) * B), Main.rand.Next(3, 6), ModContent.ProjectileType<诅咒锤>(), 100, 1f, 0);
                        Projectile.NewProjectile(player.position.X + 1000, player.position.Y - Main.rand.Next(-500, 500), Main.rand.Next(-6, -3), (float)(Math.Cos(M) * B), ModContent.ProjectileType<诅咒锤>(), 100, 1f, 0);
                        Projectile.NewProjectile(player.position.X - Main.rand.Next(-500, 500), player.position.Y + 1000, (float)(Math.Sin(M) * B), Main.rand.Next(-6, -3), ModContent.ProjectileType<诅咒锤>(), 100, 1f, 0);
                    }
                }
            }
            if (Timer == 4000)
            {
                CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), color, (GameCulture.Chinese.IsActive ? "好!你有资格挑战我的最终形态." : "Good! You are qualified to challenge my final form"), true, false);
                npc.lifeMax *= 5;
            }
            if (Timer == 4001)
            {
                npc.life = npc.lifeMax;
                Two = false;
                Three = true;
                npc.dontTakeDamage = false;
                WaterWorld.恐惧2 = true;
                WaterWorld.恐惧 = true;
                Timer =0;
                Timer2 =0;
                Timer3 =0;
            }
        }
        public void one()
        {
            Player player = Main.player[npc.target];
            int H = Utils.SelectRandom(Main.rand, new int[]
            {
                Main.rand.Next(200,400),
                Main.rand.Next(-400,-200)
            });
            if (npc.life > npc.lifeMax / 2)
            {
                Timer++;
                if (Timer == 1)
                {
                    for (int A = 0; A < 50; A++)
                    {
                        Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 173, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);
                    }
                    npc.position.X = player.Center.X + H;
                    npc.position.Y = player.Center.Y + H;
                }
                if (Timer < 60)
                {
                    E += 0.6f;
                    npc.rotation = E;
                    npc.velocity *= 0;
                }
                if (Timer == 60)
                {
                    Vector2 FF = Main.player[npc.target].Center - npc.Center;
                    FF.Normalize();
                    FF += Main.player[npc.target].velocity / 22;
                    npc.velocity = FF*30;
                    npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X) + 0.785f);
                }
                if (Timer == 100||Timer == 160 || Timer == 220)
                {
                    Vector2 FF = Main.player[npc.target].Center - npc.Center;
                    FF.Normalize();
                    npc.velocity = FF * 15;
                    npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X) + 0.785f);
                }
                if (Timer ==280)
                {
                    Timer = 0;
                }
            }
            else
            {
                npc.ai[0]++;
                if (npc.ai[0] == 1)
                {
                    npc.dontTakeDamage = true;
                    npc.velocity *= 0;
                    npc.rotation = -0.285f; 
                    Watermod.ShowTitle(npc, 1);
                }
                if (npc.ai[0] == 240)
                {
                    Watermod.ShowTitle(npc, 2);
                }
                if (npc.ai[0] ==360)
                {
                    Watermod.ShowTitle(npc, 3);
                }

                if (npc.ai[0] == 500)
                {
                    int W = npc.lifeMax - npc.life;
                    CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), new Color(0, 255, 0), W, false, true);
                    npc.life += W;
                    WaterWorld.恐惧 = true;
                    Timer=0;
                    npc.ai[0] = 0;
                    Two = true;
                    One = false;
                }
            }
        }
        public void Si()
        {
            npc.ai[0]++;
            Color color = new Color(208, 86, 201);
            Player p = Main.player[npc.target];
            if (npc.ai[0] == 60)
            {
                CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), color, (GameCulture.Chinese.IsActive ? "呜,你真的挺强的." : "Uh, you are really strong"), true, false);
            }
            if (npc.ai[0] == 120)
            {
                CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), color, (GameCulture.Chinese.IsActive ? "但这还不够！！！." : "But that is just not enough!"), true, false);
                Projectile.NewProjectile(npc.Center.X - 2500, npc.Center.Y + 10000, 0, -1, ModContent.ProjectileType<巨大诅咒激光>(), 100, 1, 0);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y-250, 0, -1, ModContent.ProjectileType<巨大诅咒激光>(), 100, 1, 0);
                Projectile.NewProjectile(npc.Center.X + 2500, npc.Center.Y + 10000, 0, -1, ModContent.ProjectileType<巨大诅咒激光>(), 100, 1, 0);
            }
            if (npc.ai[0] == 180)
            {
                CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), color, (GameCulture.Chinese.IsActive ? "或许你还在庆幸战斗的结束." : "Maybe you are still celebrating the end of the battle"), true, false);
            } 
            if (npc.ai[0] == 240)
            {
                CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), color, (GameCulture.Chinese.IsActive ? "这才刚刚开始！." : "This is just the beginning"), true, false);
            }
            if (npc.ai[0] == 300)
            {
                Projectile.NewProjectile(npc.Center.X-250, Main.maxTilesY + 600, 0, 1, ModContent.ProjectileType<激光提示>(), 100, 1, 0);
                Projectile.NewProjectile(npc.Center.X+250, Main.maxTilesY + 600, 0, 1, ModContent.ProjectileType<激光提示>(), 100, 1, 0);
                Projectile.NewProjectile(npc.Center.X-500, Main.maxTilesY + 600, 0, 1, ModContent.ProjectileType<激光提示>(), 100, 1, 0);
                Projectile.NewProjectile(npc.Center.X+500, Main.maxTilesY + 600, 0, 1, ModContent.ProjectileType<激光提示>(), 100, 1, 0);
                Projectile.NewProjectile(npc.Center.X+500, Main.maxTilesY + 600, 0, 1, ModContent.ProjectileType<激光提示>(), 100, 1, 0);
                Projectile.NewProjectile(npc.Center.X-750, Main.maxTilesY + 600, 0, 1, ModContent.ProjectileType<激光提示>(), 100, 1, 0);
                Projectile.NewProjectile(npc.Center.X+750, Main.maxTilesY + 600, 0, 1, ModContent.ProjectileType<激光提示>(), 100, 1, 0);
                Projectile.NewProjectile(npc.Center.X-1000, Main.maxTilesY + 600, 0, 1, ModContent.ProjectileType<激光提示>(), 100, 1, 0);
                Projectile.NewProjectile(npc.Center.X+1000, Main.maxTilesY + 600, 0, 1, ModContent.ProjectileType<激光提示>(), 100, 1, 0);
                Projectile.NewProjectile(npc.Center.X-1250, Main.maxTilesY + 600, 0, 1, ModContent.ProjectileType<激光提示>(), 100, 1, 0);
                Projectile.NewProjectile(npc.Center.X+1250, Main.maxTilesY + 600, 0, 1, ModContent.ProjectileType<激光提示>(), 100, 1, 0);
                Projectile.NewProjectile(npc.Center.X-1500, Main.maxTilesY + 600, 0, 1, ModContent.ProjectileType<激光提示>(), 100, 1, 0);
                Projectile.NewProjectile(npc.Center.X+1500, Main.maxTilesY + 600, 0, 1, ModContent.ProjectileType<激光提示>(), 100, 1, 0);
                Projectile.NewProjectile(npc.Center.X-1750, Main.maxTilesY + 600, 0, 1, ModContent.ProjectileType<激光提示>(), 100, 1, 0);
                Projectile.NewProjectile(npc.Center.X+1750, Main.maxTilesY + 600, 0, 1, ModContent.ProjectileType<激光提示>(), 100, 1, 0);
                Projectile.NewProjectile(npc.Center.X-2000, Main.maxTilesY + 600, 0, 1, ModContent.ProjectileType<激光提示>(), 100, 1, 0);
                Projectile.NewProjectile(npc.Center.X+2000, Main.maxTilesY + 600, 0, 1, ModContent.ProjectileType<激光提示>(), 100, 1, 0);
                Projectile.NewProjectile(npc.Center.X-2250, Main.maxTilesY + 600, 0, 1, ModContent.ProjectileType<激光提示>(), 100, 1, 0);
                Projectile.NewProjectile(npc.Center.X+2250, Main.maxTilesY + 600, 0, 1, ModContent.ProjectileType<激光提示>(), 100, 1, 0);
                Projectile.NewProjectile(npc.Center.X-2500, Main.maxTilesY + 600, 0, 1, ModContent.ProjectileType<激光提示>(), 100, 1, 0);
                Projectile.NewProjectile(npc.Center.X+2500, Main.maxTilesY + 600, 0, 1, ModContent.ProjectileType<激光提示>(), 100, 1, 0);
            }
            if (npc.ai[0] > 400&&npc.ai[0]<1200)
            {
                npc.ai[1]++;
                if(npc.ai[1]%100==1)
                {
                    for(int K=0;K<20;K++)
                    {
                       Projectile.NewProjectile(npc.Center.X+Main.rand.Next(-2500, 2500), 10, 0, 1, ModContent.ProjectileType<激光提示>(), 100, 1, 0);
                    }
                }
            }
            if (npc.ai[0] == 1200)
            {
                npc.ai[1] = 0;
                CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), color, (GameCulture.Chinese.IsActive ? "还行,那就再来试试这个." : "Ok, then try this again"), true, false);
            }
            if(npc.ai[0]>=1300 && npc.ai[0] < 2000)
            {
                npc.ai[1]++;
                if (npc.ai[1] % 100 == 1)
                {
                    for (int K = 0; K < 15; K++)
                    {
                        Projectile.NewProjectile(npc.Center.X + Main.rand.Next(-2500, 2500), Main.maxTilesY + 600, 0, 1, ModContent.ProjectileType<激光提示>(), 100, 1, 0,0,1);
                        Projectile.NewProjectile(npc.Center.X + Main.rand.Next(-2500, 2500), Main.maxTilesY + 600, 0, 1, ModContent.ProjectileType<激光提示>(), 100, 1, 0,0,1);
                    }
                }
            }
            if (npc.ai[0] == 2000)
            {
                npc.ai[1] =0;
                CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), color, (GameCulture.Chinese.IsActive ? "呃.力量已经要耗尽了." : "My power is runnin out"), true, false);
            }
            if (npc.ai[0] == 2100)
            {
                CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), color, (GameCulture.Chinese.IsActive ? "还没结束小子." : "It's not over yet kid"), true, false);
            }

            if (npc.ai[0] >= 2200 && npc.ai[0] < 3000)
            {
                if (npc.ai[1] % 100 == 1)
                {
                    float P = 0.783f;
                    double U = P / 8f;
                    float B = 5;
                    for (int i = 0; i < 8; i++)
                    {
                        double M = U * (i + i * i) / 2.0 + 32f * i;
                        Projectile.NewProjectile(npc.Center.X - 2500, npc.Center.Y - Main.rand.Next(-2500, 2500), Main.rand.Next(3, 6), (float)(Math.Cos(M) * B), ModContent.ProjectileType<激光提示>(), 100, 1f, 0, 0, 1);
                        Projectile.NewProjectile(npc.Center.X - Main.rand.Next(-2500, 2500), npc.Center.X - 2500, (float)(Math.Sin(M) * B), Main.rand.Next(3, 6), ModContent.ProjectileType<激光提示>(), 100, 1f, 0, 0, 1);
                        Projectile.NewProjectile(npc.Center.X + 2500, npc.Center.Y - Main.rand.Next(-2500, 2500), Main.rand.Next(-6, -3), (float)(Math.Cos(M) * B), ModContent.ProjectileType<激光提示>(), 100, 1f, 0, 0, 1);
                        Projectile.NewProjectile(npc.Center.X - Main.rand.Next(-2500, 2500), npc.Center.X + 2500, (float)(Math.Sin(M) * B), Main.rand.Next(-6, -3), ModContent.ProjectileType<激光提示>(), 100, 1f, 0, 0, 1);
                    }
                }
            }
            if (npc.ai[0] == 3000)
            {
                CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), color, (GameCulture.Chinese.IsActive ? "呼." : "call"), true, false);
            }
            if (npc.ai[0] == 3100)
            {
                CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), color, (GameCulture.Chinese.IsActive ? "泰拉人，我承认你很强." : "Terrarian, I admit you are strong"), true, false);
            }
            if (npc.ai[0] == 3200)
            {
                CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), color, (GameCulture.Chinese.IsActive ? "来，给你点小小的奖励." : "Here, give you a small reward"), true, false);
            }
            if (npc.ai[0] == 3300)
            {
                CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), color, (GameCulture.Chinese.IsActive ? "手持一下你手中的武器." : "Hold the weapon in your hand"), true, false);
            }
            if (npc.ai[0] > 3400&&npc.ai[0]<3600)
            {
                for (int k = 0; k < 200; k++)
                {
                    Player player = Main.player[k];
                    if (player.HeldItem.damage > 0)
                    {
                        player.HeldItem.SetDefaults(player.HeldItem.type);
                        player.HeldItem.Prefix(ModContent.PrefixType<诅咒>());
                        player.HeldItem.position.X = player.position.X + (player.width / 2) - (player.HeldItem.width / 2);
                        player.HeldItem.position.Y = player.position.Y + (player.height / 2) - (player.HeldItem.height / 2);
                        ItemText.NewText(player.HeldItem, player.HeldItem.stack, true, false);
                    }
                }
            }
            if (npc.ai[0] == 3600)
            {
                for (int k = 0; k < 200; k++)
                {
                    Player player = Main.player[k];
                    if (player.HeldItem.damage > 0)
                    {
                        player.HeldItem.SetDefaults(player.HeldItem.type);
                        player.HeldItem.Prefix(ModContent.PrefixType<诅咒>());
                        player.HeldItem.position.X = player.position.X + (player.width / 2) - (player.HeldItem.width / 2);
                        player.HeldItem.position.Y = player.position.Y + (player.height / 2) - (player.HeldItem.height / 2);
                        ItemText.NewText(player.HeldItem, player.HeldItem.stack, true, false);
                    }
                }
            }
            if (npc.ai[0] == 3800)
            {
                CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), color, (GameCulture.Chinese.IsActive ? "有缘再会了,泰拉人." : "Goodbye，Terraria"), true, false);
            }
            if (npc.ai[0] == 4000)
            {
                npc.StrikeNPCNoInteraction(9999, 0f, 0, false, false, false);
            }
        }
        public override void OnHitPlayer(Player player, int damage, bool crit)
        {
            if (player.HeldItem.damage > 0)
            {
                player.HeldItem.SetDefaults(player.HeldItem.type);
                player.HeldItem.Prefix(-2);
                player.HeldItem.position.X = player.position.X + (player.width / 2) - (player.HeldItem.width / 2);
                player.HeldItem.position.Y = player.position.Y + (player.height / 2) - (player.HeldItem.height / 2);
                ItemText.NewText(player.HeldItem, player.HeldItem.stack, true, false);
            } 
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0 && !Bool2)
            {
                Bool = true;
                Seven = false;
                npc.life = 100;
                npc.dontTakeDamage = true;
                npc.velocity *= 0;
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            if ((One && Timer < 60) || Fives && Timer > 300 && Timer < 360)
            {
                Vector2 FF = Main.player[npc.target].Center - npc.Center;
                FF.Normalize();
                FF += Main.player[npc.target].velocity / 22;
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
                spriteBatch.Draw(laserTelegraph, npc.Center - Main.screenPosition, null, colorInner, Utils.ToRotation(FF), origin, scaleInner, 0, 0f);
                spriteBatch.Draw(laserTelegraph, npc.Center - Main.screenPosition, null, colorOuter, Utils.ToRotation(FF), origin, scaleOuter, 0, 0f);
            }
            return true;
        }
    }
}

