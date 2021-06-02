using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;

namespace Watermod.ScreenShader
{
    public class SWorld : ModWorld
    {
		public static bool 大地 = true;
		public override void Initialize()
		{
			大地 = true;
		}

		public override void TileCountsAvailable(int[] tileCounts)
		{

		}

		public override TagCompound Save()
		{
			var downed = new List<string>();
			//var downed_ = new List<int>();
			if (大地) downed.Add("大地");

			return new TagCompound {
				{"downed", downed}
			};
		}

		public override void NetSend(BinaryWriter writer)
		{
			writer.Write(大地);
		}

		public override void NetReceive(BinaryReader reader)
		{
			BitsByte flags = reader.ReadByte();
			flags[0] = 大地;
		}

		int num;
		public override void Load(TagCompound tag)
		{
			var downed = tag.GetList<string>("downed");
			//CyberWrathPoints1 = downed.Contains("intWrath");
			大地 = downed.Contains("大地");
		}

		public override void LoadLegacy(BinaryReader reader)
		{
			int loadVersion = reader.ReadInt32();
			if (loadVersion == 0)
			{
				BitsByte flags = reader.ReadByte();
				大地 = flags[0];
			}
			else
			{
				BitsByte flags = reader.ReadByte();
				大地 = flags[0];
			}
		}
    }
}
