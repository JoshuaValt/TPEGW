using System;
using System.Collections.Generic;
using System.Text;

namespace TPEGW
{
    public class DefensiveItem: Item
    {
        private string protection;

        public string Protection { get => protection; set => protection = value; }

        public DefensiveItem()
        {
            protection = "";

        }
    }
}
