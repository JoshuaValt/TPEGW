using System;
using System.Collections.Generic;
using System.Text;

namespace TPEGW
{
    public class ItemModifier
    {
        private string id;
        private string name;
        private float durability;
        private float health;
        private float strength;
        private float weight;
        private float size;
        private float agility;
        private float endurance;
        private float intellect;
        private float speed;




        public float Health { get => health + 1; set => health = value; }
        public float Strength { get => strength; set => strength = value; }
        public float Agility { get => agility; set => agility = value; }
        public float Endurance { get => endurance; set => endurance = value; }
        public float Intellect { get => intellect; set => intellect = value; }
        public float Speed { get => speed; set => speed = value; }
        public string Id { get => id; set => id = value; }
        public float Durability { get => durability; set => durability = value; }
        public float Weight { get => weight; set => weight = value; }
        public float Size { get => size; set => size = value; }
        public string Name { get => name; set => name = value; }

        public ItemModifier()
        {
            health = 0;
            strength = 0;
            agility = 0;
            endurance = 0;
            intellect = 0;
            speed = 0;
            durability = 0;
            size = 0;
            weight = 0;
            name = "";
            id = Guid.NewGuid().ToString();



        }


    }
}
