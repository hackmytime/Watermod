using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using Terraria.Localization;

namespace Watermod.NPCs
{
	public class slimeGlobalProjectile : GlobalProjectile
	{
		public static bool AnyProjectiles(int type)
		{
			for (int i = 0; i < 1000; i++)
			{
				if (Main.projectile[i].active && Main.projectile[i].type == type)
				{
					return true;
				}
			}
			return false;
		}
	}
}