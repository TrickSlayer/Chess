using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Game
{
    public class Chessman : ICloneable
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public bool status { get; set; } = true;
        public string path { get { return $"Img\\{Color}{Name}.png"; } }
        public Chessman(string name, string color)
        {
            Name = name;
            Color = color;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
