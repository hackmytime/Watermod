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
	public class 抡锤 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Whip hammer");
			DisplayName.AddTranslation(GameCulture.Chinese, "抡锤");
			Main.projFrames[projectile.type] = 6;
		}
		public override void SetDefaults()
		{
			projectile.width = 338;
			projectile.height = 356;
			projectile.hostile = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
			projectile.extraUpdates = 1;
			projectile.timeLeft = 60;
			cooldownSlot = 1;
		}
		float G;
        public override void AI()
        {
			projectile.frameCounter++;
			if (projectile.frameCounter >= 10)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 6;
			}
			NPC N = Main.npc[NPC.FindFirstNPC(ModContent.NPCType<Ezfic>())];
			projectile.position.X = N.Center.X - projectile.width/2;
			projectile.position.Y = N.Center.Y - projectile.height/2;
		}
    }
}