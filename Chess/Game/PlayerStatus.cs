using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Game
{
    partial class GamePlay
    {
        public int countOnlyKing = 0;

        #region Checkmate
        public bool checkmate(String color)
        {
            (String index, Chessman chessman) = getKing(color);
            List<String> way = King(chessman, index);
            bool output = way.Where(x => x.Equals(index)).ToList().Count == 0;
            return output;
        }

        public (bool draw, bool lose) checkPlayerStatus(String color)
        {
            bool onlyKing = true;
            bool noWay = true;
            bool kingCantmove = false;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i,j]!=null && board[i, j].Color.Equals(color))
                    {
                        String index = indexString(i, j);
                        List<String> way = getPossibleMove(index);
                        if (way.Count() == 0) kingCantmove =true;
                        if (way.Count() > 1 || 
                            (way.Where(x => x.Equals(indexString(i,j))).ToList().Count == 0 && way.Count() == 1 )) noWay = false;
                        Chessman chessman = board[i,j];
                        if (!chessman.Name.Equals("King"))
                        {
                            onlyKing = false;
                        }
                    }
                }
            }
            //thua vì vua bị chiếu hết nước đi
            if (noWay && kingCantmove) return (false, true);
            if (onlyKing)
            {
                countOnlyKing++;
            }

            // hoà do không còn khả năng thắng / không muốn thắng
            if (countOnlyKing == 16) return (true, false);

            // hoà do không còn nước đi nhưng không bị chiếu tướng
            if (noWay) return (true, false);
            return (false, false);
        }

        private (String index, Chessman chessman) getKing(String color)
        {
            String index = color.Equals("Black") ? BlackKingIndex : WhiteKingIndex;
            (int x, int y) = getIndexInt(index);
            return (index, board[x,y]);
        }
        #endregion
    }
}
