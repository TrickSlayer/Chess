using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models
{
    public partial class Achievement
    {
        public String Player1Name { get { return Player1 == null ? "Guess" : "Player " + Player1.Username; } }

        public String Player2Name { get { return Player2 == null ? "Guess" : "Player " + Player2.Username; } }
    }
}
