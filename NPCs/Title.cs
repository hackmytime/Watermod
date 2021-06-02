using System;
using Terraria;
using Terraria.ModLoader;

namespace Watermod.NPCs
{
	public class Title : ModProjectile
	{

		public override void SetDefaults()
		{
			projectile.width = 1;
			projectile.height = 1;
			projectile.penetrate = -1;
			projectile.hostile = false;
			projectile.friendly = false;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.timeLeft = 240;
		}

		public override void AI()
		{
			Titles modPlayer = Main.player[projectile.owner].GetModPlayer<Titles>();
			modPlayer.text = true;
			modPlayer.BossID = (int)projectile.ai[0];
			projectile.velocity.X = 0f;
			projectile.velocity.Y = 0f;
			if (projectile.timeLeft <= 45)
			{
				if (modPlayer.alphaText < 255f)
				{
					modPlayer.alphaText += 10f;
					modPlayer.alphaText2 += 10f;
					modPlayer.alphaText3 += 10f;
					return;
				}
			}
			else
			{
				if (projectile.timeLeft <= 180)
				{
					modPlayer.alphaText -= 5f;
				}
				if (modPlayer.alphaText > 0f)
				{
					modPlayer.alphaText2 -= 5f;
				}
				if (modPlayer.alphaText2 > 0f)
				{
					modPlayer.alphaText3 -= 5f;
				}
			}
		}
	}
}
