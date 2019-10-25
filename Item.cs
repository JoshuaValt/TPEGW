using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TPEGW
{
    public class Item
    {
        private string name;
        private string id;
        private int damage;
        private float weight;
        private int size;
        private int durability;
        private int level;
        private Collection<ItemModifier> modifiers; 

        public string Name { get => name; set => name = value; }
        public int Size { get => size; set => size = value; }
        public int Durability { get => durability; set => durability = value; }
        public int Level { get => level; set => level = value; }
        public float Weight { get => weight; set => weight = value; }
        public string Id { get => id; set => id = value; }
        public Collection<ItemModifier> Modifiers { get => modifiers; set => modifiers = value; }

        public Item()
        {
            
            id = Guid.NewGuid().ToString();
            name = "";
            weight = 0;
            level = 1;
            durability = 100;
            size = 12;
            modifiers = new Collection<ItemModifier>();

        }
    }

}
