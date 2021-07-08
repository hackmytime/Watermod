using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Watermod.Items
{
    public class 诅咒 : ModPrefix
    {
        private float damage = 0;
        private float speed = 0;
        private byte crit = 0;
        private float size = 0;
        private float knockback = 0;
        private float mana = 0;
        private float shootSpeed = 0;

        public override PrefixCategory Category { get { return PrefixCategory.AnyWeapon; } }
        public 诅咒()
        {
        }
        public 诅咒(float damage, float speed, byte crit, float size, float knockback, float mana, float shootSpeed)
        {
            this.damage = damage;
            this.speed = speed;
            this.crit = crit;
            this.size = size;
            this.knockback = knockback;
            this.mana = mana;
            this.shootSpeed = shootSpeed;
        }
        public override bool Autoload(ref string name)
        {
            if (base.Autoload(ref name))
            {
                //1.伤害 2.速度 3.暴击 4.大小 5.击退
                mod.AddPrefix((GameCulture.Chinese.IsActive ? "诅咒." : "Cursed"), new 诅咒(1.3f, 1.2f, 20, 1.1f, 1.2f, 0.8f , 2f));
            }
            return false;
        }

        public override float RollChance(Item item)
        {
            return 0f;
        }

        public override bool CanRoll(Item item)
        {
            if (speed < 1f && (item.pick > 0 || item.hammer > 0 || item.axe > 0))
            {
                return false;
            }
            return (item.damage > 1 || damage >= 1f) && (item.useTime > 4 || speed < 1f);
        }
        public override void Apply(Item item)
        {
            item.damage = (int)(item.damage * damage);
            item.useTime = (int)(item.useTime * (1 / speed));
            item.useAnimation = (int)(item.useAnimation * (1 / speed));
            item.reuseDelay = (int)(item.reuseDelay * (1 / speed));
            item.crit += crit;
            item.scale *= size;
            item.knockBack *= knockback;
            item.mana = (int)(item.mana * mana);
            item.shootSpeed *= shootSpeed;
        }

        public override void ModifyValue(ref float valueMult)
        {
            valueMult = damage * speed * (1 + crit * 0.01f) * knockback * (1 + mana * 0.1f);
        }
    }
}