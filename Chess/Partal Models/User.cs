using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models
{
    public partial class User : ICloneable
    {
        public object Clone()
        {
            return this.MemberwiseClone(); ;
        }
    }
}
