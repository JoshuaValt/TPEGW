using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TPEGW
{
    public class OffensiveItem : Item
    {
        private int speed;
        private string damage;
        private int range;
        private double accuracy;
       
        

        public int Speed { get => speed; set => speed = value; }
        public string Damage { get => damage; set => damage = value; }
        public int Range { get => range; set => range = value; }
        public double Accuracy { get => accuracy; set => accuracy = value; }

        public OffensiveItem()
        {
            speed = 25;
            damage = "";
            range = 5;
            accuracy = 35;
            
        }
    }
}
