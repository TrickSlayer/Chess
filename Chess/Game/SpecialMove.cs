using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Game
{
    partial class GamePlay
    {

        bool specialMove(String First, String Second)
        {
            (int X_indexFirst, int Y_indexFirst) = getIndexInt(First);
            (int X_indexSecond, int Y_indexSecond) = getIndexInt(Second);

            //enPassant
            Chessman From = board[X_indexFirst, Y_indexFirst];
            Chessman To = board[X_indexSecond, Y_indexSecond];
            if ((Y_indexFirst == 3 && From.Color.Equals("White") 
                || Y_indexFirst == 4 && From.Color.Equals("Black") ) 
                && To == null && X_indexFirst != X_indexSecond && From.Name.Equals("Pawn"))
            {
                board[X_indexSecond, Y_indexSecond] = (Chessman)board[X_indexFirst, Y_indexFirst].Clone();
                board[X_indexFirst, Y_indexFirst] = null;
                Chessman eat = board[X_indexSecond, Y_indexFirst];
                specialLog = $"{eat.Name}.{indexString(X_indexSecond, Y_indexFirst)}.F.{eat.Color}";
                board[X_indexSecond, Y_indexFirst] = null;
                return true;
            }

            //Update
            if ((Y_indexSecond == 0 || Y_indexSecond == 7) && From.Name.Equals("Pawn"))
            {
                board[X_indexSecond, Y_indexSecond] = (Chessman)board[X_indexFirst, Y_indexFirst].Clone();
                board[X_indexFirst, Y_indexFirst] = null;
                specialLog = $"{From.Name}*{indexString(X_indexSecond, Y_indexSecond)}";
                return true;
            }

            //Castling
            if (Math.Abs(X_indexFirst - X_indexSecond) == 2 && From.Name.Equals("King"))
            {
                board[X_indexSecond, Y_indexSecond] = (Chessman)board[X_indexFirst, Y_indexFirst].Clone();
                board[X_indexFirst, Y_indexFirst] = null;

                int x = X_indexFirst - X_indexSecond > 0 ? 0 : 7;
                board[X_indexSecond + (x == 0 ? 1 : -1), Y_indexSecond] = (Chessman)board[x, Y_indexSecond].Clone();
                board[x, Y_indexSecond] = null;
                specialLog = $"{indexString(x, Y_indexSecond)}=>{indexString(X_indexSecond + (x == 0 ? 1 : -1), Y_indexSecond)}";
                return true;
            }

            return false;
        }

        //Bắt tốt qua đường
        List<String> enPassant(Chessman chessman, String index)
        {
            List<String> list = new List<String>();
            if (chessman.Color.Equals("Black") && index.Contains("5"))
            {
                (int x, int y) = getIndexInt(index);
                if (x - 1 >= 0)
                {
                    Chessman chessman1 = board[x - 1, y];
                    if (chessman1 != null && checkEnPassantCondition(chessman, chessman1))
                    {
                        list.Add(indexString(x - 1, y + 1));
                    }
                } 
                if (x + 1 <= 7)
                {
                    Chessman chessman2 = board[x + 1, y];
                    if (chessman2 != null && checkEnPassantCondition(chessman, chessman2))
                    {
                        list.Add(indexString(x + 1, y + 1));
                    }
                } 
            } else
            if (chessman.Color.Equals("White") && index.Contains("4"))
            {
                (int x, int y) = getIndexInt(index);
                if (x - 1 >= 0)
                {
                    Chessman chessman1 = board[x - 1, y];
                    if (chessman1 != null && checkEnPassantCondition(chessman, chessman1))
                    {
                        list.Add(indexString(x - 1, y - 1));
                    }
                } 
                if (x + 1 <= 7)
                {
                    Chessman chessman2 = board[x + 1, y];
                    if (chessman2 != null && checkEnPassantCondition(chessman, chessman2))
                    {
                        list.Add(indexString(x + 1, y - 1));
                    }
                } 
            }
            return list;
        }

        bool checkEnPassantCondition(Chessman chessman, Chessman enemy)
        {
            bool output = true;
            output = output && enemy.Name.Equals("Pawn");
            output = output && !enemy.Color.Equals(chessman.Color);
            output = output && !enemy.status;
            return output;
        }

        //Phong hậu
        public Chessman UpdatePawn(String index, String newName)
        {
            Chessman chessman = getChessman(index);
            chessman.Name = newName;
            return chessman;
        }

        //Nhập thành
        List<String> Castling (Chessman chessman, String index, List<String> ways)
        {
            if (chessman.status && ways.Where(x => x.Equals(index)).ToList().Count > 0)
            {
                (int x,int y) = getIndexInt(index);
                Chessman leftCastle = board[0, y];
                Chessman rightCastle = board[7, y];

                if (leftCastle != null && leftCastle.status 
                    && ways.Where(way => way.Equals(indexString( x - 1 , y))).ToList().Count > 0
                    && emptyWay(0,x,y))
                {
                    ways.Add(indexString(x - 2 , y));
                }

                if (rightCastle != null && rightCastle.status
                    && ways.Where(way => way.Equals(indexString(x + 1, y))).ToList().Count > 0
                    && emptyWay(x, 7, y))
                {
                    ways.Add(indexString(x + 2, y));
                }
            }
            return ways;
        }

        private bool emptyWay(int from,int to, int y)
        {
            for (int x = from + 1; x< to; x++)
            {
                if (board[x,y] != null)
                {
                    return false;
                }
            }
            return true;
        } 
    }
}
