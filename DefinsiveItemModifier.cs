using System;
using System.Collections.Generic;
using System.Text;

namespace TPEGW
{
    public class DefinsiveItemModifier: ItemModifier
    {
        private string resistanceType;
        private float resistance;
        private string bonusResistance;

        public string ResistanceType { get => resistanceType; set => resistanceType = value; }
        public float Resistance { get => resistance; set => resistance = value; }
        public string BonusResistance { get => bonusResistance; set => bonusResistance = value; }

        public DefinsiveItemModifier()
        {

            resistanceType = "";
            resistance = 0;
            bonusResistance = "";

        }
    }
}
