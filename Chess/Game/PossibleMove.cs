using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Game
{
    partial class GamePlay
    {

        #region Check possible move

        public List<String> getPossibleMove(String index)
        {
            (int X_index, int Y_index) = getIndexInt(index);
            Chessman chessman = board[X_index, Y_index];
            if (chessman != null)
            {
                PossibleMove possibleMove = Pawn;
                switch (chessman.Name)
                {
                    case "Castle":
                        possibleMove = Castle;
                        break;
                    case "Knight":
                        possibleMove = Knight;
                        break;
                    case "Bishop":
                        possibleMove = Bishop;
                        break;
                    case "King":
                        possibleMove = King;
                        break;
                    case "Queen":
                        possibleMove = Queen;
                        break;
                }
                return possibleMove(chessman, index);
            }
            return new List<string>();
        }

        List<String> Pawn(Chessman chessman, String index)
        {
            List<String> list = new List<String>();
            int direction = chessman.Color.Equals("Black") ? 1 : -1;

            list.AddRange(PawnNormalMove(index, direction));

            list.AddRange(PawnAttackMove(chessman, index));

            list = protectKingByMove(list, chessman.Color, index);

            return list;
        }

        private List<String> PawnNormalMove(String index, int direction)
        {
            List<String> list = new List<String>();
            int step = 1;
            if (index.Contains("2") || index.Contains("7"))
            {
                step = 2;
            }
            (int X_index, int Y_index) = getIndexInt(index);
            for (int i = Y_index; direction * (i - Y_index - step * direction) <= 0; i = i + direction)
            {
                String possibleStep = indexString(X_index, i);
                if (i < 0 || i > 7 || (board[X_index, i] != null && i != Y_index))
                {
                    break;
                }
                list.Add(possibleStep);
            }
            return list;
        }

        private List<String> PawnAttackMove(Chessman chessman, String index)
        {
            int direction = chessman.Color.Equals("Black") ? 1 : -1;
            List<String> list = new List<String>();
            (int X_index, int Y_index) = getIndexInt(index);
            for (int i = -1; i <= 1; i = i + 2)
            {
                if (X_index + i >= 0 && X_index + i <= 7 && Y_index + direction >= 0 && Y_index + direction <= 7)
                {
                    Chessman enemy = board[X_index + i, Y_index + direction];
                    if (enemy != null && (!enemy.Color.Equals(chessman.Color)))
                    {
                        list.Add(indexString(X_index + i, Y_index + direction));
                    }
                }
            }
            list.AddRange(enPassant(chessman,index));
            return list;
        }

        private List<String> protectedChessmanContinuousMove(int i, int j, String index, String color)
        {
            List<String> list = new List<String>();
            (int x, int y) = getIndexInt(index);
            x = x + i; y = y + j;
            while (x >= 0 && x <= 7 && y >= 0 && y <= 7)
            {
                Chessman next = board[x, y];
                if (next == null)
                {
                    list.Add(indexString(x, y));
                }
                else
                {
                    if (next.Color.Equals(color))
                    {
                        break;
                    }
                    else
                    {
                        list.Add(indexString(x, y));
                        break;
                    }
                }
                x = x + i; y = y + j;
            }
            return list;
        }

        private String protectedChessmanDisontinuousMove(int i, int j, String index, String color)
        {
            (int x, int y) = getIndexInt(index);
            x = x + i; y = y + j;
            if (x >= 0 && x <= 7 && y >= 0 && y <= 7)
            {
                Chessman next = board[x, y];
                if (next == null)
                {
                    return indexString(x, y);
                }
                else
                {
                    if (next.Color.Equals(color))
                    {
                        return null;
                    }
                    else
                    {
                        return indexString(x, y);
                    }
                }
            }
            return null;
        }

        List<String> Castle(Chessman chessman, String index)
        {
            String color = chessman.Color;
            List<String> list = new List<String>();
            list.Add(index);
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if ((i + j) % 2 == 0) continue;
                    list.AddRange(protectedChessmanContinuousMove(i, j, index, color));
                }
            }
            list = protectKingByMove(list, chessman.Color, index);
            return list;
        }

        List<String> Knight(Chessman chessman, String index)
        {
            String color = chessman.Color;
            List<String> list = new List<String>();
            list.Add(index);
            for (int i = -2; i <= 2; i++)
            {
                for (int j = -2; j <= 2; j++)
                {
                    if (i == 0 || j == 0 || (i + j) % 2 == 0) continue;
                    String way = protectedChessmanDisontinuousMove(i, j, index, color);
                    if (way != null)
                    {
                        list.Add(way);
                    }
                }
            }
            list = protectKingByMove(list, chessman.Color, index);
            return list;
        }

        List<String> Bishop(Chessman chessman, String index)
        {
            String color = chessman.Color;
            List<String> list = new List<String>();
            list.Add(index);
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if ((i + j) % 2 != 0 || i == 0) continue;
                    list.AddRange(protectedChessmanContinuousMove(i, j, index, color));
                }
            }
            list = protectKingByMove(list, chessman.Color, index);
            return list;
        }

        List<String> Queen(Chessman chessman, String index)
        {
            String color = chessman.Color;
            List<String> list = new List<String>();
            list.Add(index);
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0) continue;
                    list.AddRange(protectedChessmanContinuousMove(i, j, index, color));
                }
            }
            list = protectKingByMove(list, chessman.Color, index);
            return list;
        }

        List<String> King(Chessman chessman, String index)
        {
            String color = chessman.Color;
            List<String> list = new List<String>();
            list.Add(index);
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0) continue;
                    String way = protectedChessmanDisontinuousMove(i, j, index, color);
                    if (way != null)
                    {
                        list.Add(way);
                    }
                }
            }
            list = AvoidEnemyWay(list, chessman.Color);
            list = Castling(chessman,index,list);
            list = AvoidEnemyWay(list, chessman.Color);
            return list;
        }

        #endregion

    }
}
