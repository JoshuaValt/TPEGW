using System;
using System.Collections.Generic;
using System.Text;

namespace TPEGW
{
    public class OffensiveItemModifier: ItemModifier
    {
        private float speed;
        private float damage;
        private float range;
        private float accuracy;
        private string bonusDamage;


        public float Speed { get => speed; set => speed = value; }
        public float Damage { get => damage; set => damage = value; }
        public float Range { get => range; set => range = value; }
        public float Accuracy { get => accuracy; set => accuracy = value; }
        public string BonusDamage { get => bonusDamage; set => bonusDamage = value; }

        public OffensiveItemModifier()
        {
            speed = 0;
            damage = 0;
            range = 0;
            accuracy = 0;
            bonusDamage = "";
        }



    }
}
