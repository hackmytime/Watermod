using System;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.Utilities;
using Terraria.GameContent.UI;
using Terraria.Localization;
using Terraria.Graphics.Shaders;

namespace Watermod.ScreenShader
{
	public class 染色体 : ScreenShaderData
	{
		private int CalIndex;

		public 染色体(string passName)
			: base(passName)
		{
		}

		private void UpdateCalIndex()
		{
			bool CalType = SWorld.大地;
			if (CalIndex >= 0 && Main.npc[CalIndex].active && CalType)
			{
				return;
			}
			CalIndex = -1;
			for (int i = 0; i < Main.npc.Length; i++)
			{
				if (Main.npc[i].active && CalType)
				{
					CalIndex = i;
					break;
				}
			}
		}

		public override void Apply()
		{
			UpdateCalIndex();
			if (CalIndex != -1)
			{
				UseTargetPosition(Main.npc[CalIndex].Center);
			}
			base.Apply();
		}
	}
}
