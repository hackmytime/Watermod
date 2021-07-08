using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace Watermod.NPCs.诅咒邪锤
{
	public class 诅咒激光 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("诅咒激光");
		}
		public override void SetDefaults()
		{
			projectile.width = 36;
			projectile.height = 36;
			projectile.aiStyle = -1;
			projectile.hostile = true;
			projectile.friendly = false;
			projectile.scale = 1;
			projectile.penetrate = -1;
			projectile.alpha = 0;
			projectile.timeLeft = 3600;
			projectile.tileCollide = false;
		}
		public float LaserLength
		{
			get
			{
				return projectile.localAI[1];
			}
			set
			{
				projectile.localAI[1] = value;
			}
		}
		public override bool ShouldUpdatePosition()
		{
			return false;
		}
		public override void AI()
		{
			Player player = Main.player[projectile.owner];

			if (multiplier == 1f)
			{
				projectile.ai[1] += 15f * multiplier;
			}
			else
			{
				projectile.ai[1] += 2f * multiplier;
			}
			if (projectile.ai[1] >= 200f && multiplier == 1f)
			{
				multiplier = -0.5f;
			}
			if (multiplier < 0f && projectile.ai[1] <= 0f)
			{
				projectile.Kill();
			}
			projectile.gfxOffY = player.gfxOffY;
			projectile.rotation = Utils.ToRotation(projectile.velocity) - 1.5707964f;
			projectile.velocity = Vector2.Normalize(projectile.velocity);
			float[] array = new float[2];
			Collision.LaserScan(projectile.Center, projectile.velocity, 0f, 5000f, array);
			float num = 0f;
			for (int i = 0; i < array.Length; i++)
			{
				num += array[i];
			}
			num /= array.Length;
			float num2 = 0.75f;
			LaserLength = MathHelper.Lerp(LaserLength, 20000, num2);
			projectile.ai[0] += 1f;
		}
		public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
		{
			float num = 0f;
			return new bool?(Collision.CheckAABBvLineCollision(Utils.TopLeft(targetHitbox), Utils.Size(targetHitbox), base.projectile.Center, projectile.Center + (projectile.velocity * LaserLength), projHitbox.Width, ref num));
		}
		public override bool? CanCutTiles()
		{
			DelegateMethods.tilecut_0 = (Terraria.Enums.TileCuttingContext)2;
			Utils.PlotTileLine(projectile.Center, projectile.Center + projectile.velocity * LaserLength, projectile.width * projectile.scale * 2f, new Utils.PerLinePoint(CutTilesAndBreakWalls));
			return new bool?(true);
		}
		private bool CutTilesAndBreakWalls(int x, int y)
		{
			return DelegateMethods.CutTiles(x, y);
		}
		public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
		{
		}
		public override bool CanHitPlayer(Player target)
		{
			return base.projectile.ai[1] >= 100f && base.CanHitPlayer(target);
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			if (projectile.velocity == Vector2.Zero)
			{
				return false;
			}
			Texture2D texture = base.mod.GetTexture("NPCs/诅咒邪锤/诅咒激光头");
			Texture2D texture2D = Main.projectileTexture[projectile.type];
			Texture2D texture2 = base.mod.GetTexture("NPCs/诅咒邪锤/诅咒激光尾");
			float num = this.LaserLength;
			Color color = Color.White * 1.2f * ((base.projectile.ai[1] >= 100f) ? 1f : 0.4f);
			Vector2 vector = base.projectile.Center + new Vector2(0f, base.projectile.gfxOffY) - Main.screenPosition;
			spriteBatch.Draw(texture, vector, null, color, base.projectile.rotation, Utils.Size(texture) / 2f, new Vector2(Math.Min(base.projectile.ai[1], 100f) / 100f, 1f), 0, 0f);
			num -= (float)(texture.Height / 2 + texture2.Height) * base.projectile.scale;
			Vector2 vector2 = base.projectile.Center + new Vector2(0f, base.projectile.gfxOffY);
			vector2 += base.projectile.velocity * base.projectile.scale * (float)texture.Height / 2f;
			if (num > 0f)
			{
				float num2 = 0f;
				Rectangle rectangle = new Rectangle(0, 16 * (base.projectile.timeLeft / 3 % 5), texture2D.Width, 16);
				while (num2 + 1f < num)
				{
					if (num - num2 < (float)rectangle.Height)
					{
						rectangle.Height = (int)(num - num2);
					}
					Main.spriteBatch.Draw(texture2D, vector2 - Main.screenPosition, new Rectangle?(rectangle), color, base.projectile.rotation, new Vector2((float)(rectangle.Width / 2), 0f), new Vector2(Math.Min(base.projectile.ai[1], 100f) / 100f, 1f), 0, 0f);
					num2 += (float)rectangle.Height * base.projectile.scale;
					vector2 += base.projectile.velocity * (float)rectangle.Height * base.projectile.scale;
					rectangle.Y += 16;
					if (rectangle.Y + rectangle.Height > texture2D.Height)
					{
						rectangle.Y = 0;
					}
				}
			}
			Main.spriteBatch.Draw(texture2, vector2 - Main.screenPosition, null, color, base.projectile.rotation, Utils.Top(Utils.Frame(texture2, 1, 1, 0, 0)), new Vector2(Math.Min(base.projectile.ai[1], 100f) / 100f, 1f), 0, 0f);
			return false;
		}
		internal const float charge = 100f;
		public const float LaserLengthMax = 5000f;
		private float multiplier = 1f;
		private int t;
	}
}
