using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ModLoader;

namespace Watermod
{
	// Token: 0x02000027 RID: 39
	public class WSky : CustomSky
	{
		// Token: 0x06000100 RID: 256 RVA: 0x0000DEC0 File Offset: 0x0000C0C0
		public override void Update(GameTime gameTime)
		{
			if (this.isActive && this.intensity < 1f)
			{
				this.intensity += 0.01f;
				return;
			}
			if (!this.isActive && this.intensity > 0f)
			{
				this.intensity -= 0.01f;
			}
		}

		public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
		{
			if (maxDepth >= 9 && minDepth < 9)
			{
				spriteBatch.Draw(ModContent.GetTexture("Watermod/NPCs/Ezfic/背景光效"), new Rectangle(0, Math.Max(0, (int)(Main.worldSurface * 0.01)), Main.screenWidth, Main.screenHeight), Main.DiscoColor);
			}
			if (maxDepth >= 10 && minDepth < 10)
            {
				for (int E = 0; E < 20; E++)
				{
					for (int J = 0; J < 20; J++)
					{
						float A = 100 * E;
						float C = 100 * J;
						spriteBatch.Draw(ModContent.GetTexture("Watermod/NPCs/Ezfic/星星炮"), new Vector2(A, C), new Rectangle(0, Math.Max(0, (int)(Main.worldSurface * 0.01)), 56, 22), Main.DiscoColor, G, new Vector2((float)(ModContent.GetTexture("Watermod/NPCs/Ezfic/星星炮").Width >> 1), (float)(ModContent.GetTexture("Watermod/NPCs/Ezfic/星星炮").Height >> 1)), 1, 0, 0);
					}
				}
			if (maxDepth >= 9 && minDepth < 9)
			{
				G += 0.1f;
				for (int E = 0; E < 20; E++)
				{
					for (int J = 0; J < 20; J++)
					{
						float A = 200 * E;
						float C = 200 * J;
						spriteBatch.Draw(ModContent.GetTexture("Watermod/NPCs/Ezfic/星星炮"), new Vector2(A, C), new Rectangle(0, Math.Max(0, (int)(Main.worldSurface * 0.01)), 56, 22), Main.DiscoColor, G , new Vector2((float)(ModContent.GetTexture("Watermod/NPCs/Ezfic/星星炮").Width >> 1), (float)(ModContent.GetTexture("Watermod/NPCs/Ezfic/星星炮").Height >> 1)), 2, 0, 0);
					}
				}
			}
			}
		}

		public override float GetCloudAlpha()
		{
			return 0f;
		}

		public override void Activate(Vector2 position, params object[] args)
		{
			this.isActive = true;
		}
		public override void Deactivate(params object[] args)
		{
			this.isActive = false;
		}
		public override void Reset()
		{
			this.isActive = false;
		}
		public override bool IsActive()
		{
			return this.isActive || this.intensity > 0f;
		}
		private bool isActive;
		private float intensity;
		private float G;
	}
}
