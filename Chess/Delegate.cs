using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Game
{
    delegate List<String> PossibleMove(Chessman chessman, String index);

    delegate bool AvoidChessman(String way, String enemyColor, int i, int j);
}
