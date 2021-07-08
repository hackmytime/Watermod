using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace Watermod.NPCs
{
	public class WaterWorld : ModWorld
    {
		public static bool 恐惧 = false;
		public static bool 恐惧2 = false;
	}
    public class slimeGlobalNPC : GlobalNPC
    {
        public override void AI(NPC npc)
        {
			if (!NPC.AnyNPCs(ModContent.NPCType<诅咒邪锤.诅咒邪锤>()))
			{
				WaterWorld.恐惧 = false;
				WaterWorld.恐惧2 = false;
			}
		}
    }

	public class Titles : ModPlayer
	{
		public override void UpdateBiomeVisuals()
        {
			player.ManageSpecialBiomeVisuals("锤", WaterWorld.恐惧);
			player.ManageSpecialBiomeVisuals("邪锤", WaterWorld.恐惧2);
			//NPC spirit =Main.npc[NPC.FindFirstNPC(ModContent.NPCType<Ezfic.Ezfic>())];
			player.ManageSpecialBiomeVisuals("星星", NPC.AnyNPCs(ModContent.NPCType<Ezfic.Ezfic>())/* && spirit.ai[1] != 0f*/);
		}
		public override void ResetEffects()
		{
			text = false;
		}

		public override void PreUpdate()
		{
			if (!slimeGlobalProjectile.AnyProjectiles(ModContent.ProjectileType<Title>()) && !slimeGlobalProjectile.AnyProjectiles(ModContent.ProjectileType<SistersTitle>()))
			{
				alphaText = 255f;
				alphaText2 = 255f;
				alphaText3 = 255f;
			}
			if (!slimeGlobalProjectile.AnyProjectiles(ModContent.ProjectileType<SistersTitle>()))
			{
				alphaText4 = 255f;
			}
			player.meleeCrit +=  100;
			player.magicCrit +=  100;
			player.rangedCrit += 100;
		}

		public bool text;

		public float alphaText = 255f;

		public float alphaText2 = 255f;

		public float alphaText3 = 255f;

		public float alphaText4 = 255f;

		public int BossID;
	}
}
