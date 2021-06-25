using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using Watermod.NPCs;
using Watermod.ScreenShader;

namespace Watermod
{
    public class Watermod : Mod
    {
        internal static object Instance2;

        public override void Load()
        {
            Filters.Scene["锤"] = new Filter(new 染色体("FilterMiniTower").UseColor(new Color(208, 86, 201)).UseOpacity(0.8f), EffectPriority.VeryHigh);
            SkyManager.Instance["锤"] = new 染色体全景();
            Filters.Scene["邪锤"] = new Filter(new 染色体("FilterMiniTower").UseColor(new Color(208, 86, 201)).UseOpacity(1.5f), EffectPriority.VeryHigh);
            SkyManager.Instance["邪锤"] = new 染色体全景();
            SkyManager.Instance["星星"] = new WSky();
            Filters.Scene["星星"] = new Filter(new WScreenShaderData("FilterMiniTower").UseColor(0, 0f, 0).UseOpacity(0.5f), (EffectPriority)2);
        }
        public static void ShowTitle(NPC npc, int ID)
        {
            Projectile.NewProjectile(npc.Center, Vector2.Zero, ModContent.ProjectileType<Title>(), 0, 0f, Main.myPlayer, ID, 0f);
        }
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            Titles modPlayer = Main.player[Main.myPlayer].GetModPlayer<Titles>();
            if (modPlayer.text)
            {
                int textLayer = layers.FindIndex((GameInterfaceLayer layer) => layer.Name.Equals("Vanilla: Inventory"));
                LegacyGameInterfaceLayer computerState = new LegacyGameInterfaceLayer("AAMod: UI", delegate ()
                {
                    this.BossTitle(modPlayer.BossID);
                    return true;
                }, InterfaceScaleType.UI);
                layers.Insert(textLayer, computerState);
            }
        }
        private void BossTitle(int BossID)
        {

            string BossName = "";
            Color titleColor = Color.White;
            switch (BossID)
            {
                case 1:
                    BossName = GameCulture.Chinese.IsActive ? "或许你还有点本事" : "You're stronger than I expected";
                    titleColor = new Color(208, 86, 201);
                    break;
                case 2:
                    BossName = GameCulture.Chinese.IsActive ? "但我认为你还是太弱了" : "But i think you are still too weak";
                    titleColor = new Color(208, 86, 201);
                    break;
                case 3:
                    BossName = GameCulture.Chinese.IsActive ? "我就稍微认真一点吧" : "Let me be a bit serious";
                    titleColor = new Color(208, 86, 201);
                    break;
            }
            Vector2 textSize5 = Main.fontDeathText.MeasureString(BossName) * 3;
            float textPositionLeft2 = (Main.screenWidth / 2) - textSize5.X / 3f;
            DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, Main.fontDeathText, BossName, new Vector2(textPositionLeft2, Main.screenHeight / 2 - 350), titleColor, 0f, Vector2.Zero, 1.2f, SpriteEffects.None, 0f);
        }
    }
}