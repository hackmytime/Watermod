using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
 
namespace Watermod.Items
{
    public class 被诅咒的锤子 : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed hammer");
            DisplayName.AddTranslation(GameCulture.Chinese, "被诅咒的锤子");
            Tooltip.SetDefault("Summon a powerful hammer soul after use");
            Tooltip.AddTranslation(GameCulture.Chinese, "使用后召唤强大的锤子灵魂");
        }

        public override void SetDefaults()
        {
            item.width = (item.height = 16);
            item.rare = 9;
            item.maxStack = 99;
            item.useStyle = 4;
            item.useTime = (item.useAnimation = 20);
            item.noMelee = true;
            item.consumable = true;
            item.autoReuse = false;
            item.UseSound = SoundID.Item43;
        }
        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(mod.NPCType("诅咒邪锤"));
        }		
		
 		public override bool UseItem(Player player)
		{
            NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("诅咒邪锤"));
            Main.PlaySound(15, player.position, 0);
			return true;
		}
    }
    public class slimeGlobalItem : GlobalItem
    {
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }
        public override bool CloneNewInstances
        {
            get
            {
                return true;
            }
        }
        public override void SetDefaults(Item item)
        {
            if(item.maxStack>=30 && item.type<71&&item.type>74)
            {
                item.maxStack = 2147483647;
            }
        }
    }

}
