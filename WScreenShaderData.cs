using System;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader;

namespace Watermod
{
	// Token: 0x02000025 RID: 37
	public class WScreenShaderData : ScreenShaderData
	{
		// Token: 0x060000FA RID: 250 RVA: 0x0000DD37 File Offset: 0x0000BF37
		public WScreenShaderData(string passName) : base(passName)
		{
		}

		// Token: 0x060000FB RID: 251 RVA: 0x0000DD40 File Offset: 0x0000BF40
		private void UpdateSpiritIndex()
		{
			int SpiritType = ModLoader.GetMod("Watermod").NPCType("Ezfic");
			if (this.SpiritIndex >= 0 && Main.npc[this.SpiritIndex].active && Main.npc[this.SpiritIndex].type == SpiritType)
			{
				return;
			}
			this.SpiritIndex = -1;
			for (int i = 0; i < Main.npc.Length; i++)
			{
				if (Main.npc[i].active && Main.npc[i].type == SpiritType)
				{
					this.SpiritIndex = i;
					return;
				}
			}
		}

		// Token: 0x060000FC RID: 252 RVA: 0x0000DDD1 File Offset: 0x0000BFD1
		public override void Apply()
		{
			this.UpdateSpiritIndex();
			if (this.SpiritIndex != -1)
			{
				base.UseTargetPosition(Main.npc[this.SpiritIndex].Center);
			}
			base.Apply();
		}

		// Token: 0x04000148 RID: 328
		private int SpiritIndex;
	}
}
