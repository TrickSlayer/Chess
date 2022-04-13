using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Game
{
    partial class GamePlay
    {

        private String kingIndex(String enemyColor)
        {
            String Kingindex;
            if (enemyColor.Equals("Black"))
            {
                Kingindex = WhiteKingIndex;
            }
            else
            {
                Kingindex = BlackKingIndex;
            }
            return Kingindex;
        }

        #region King Avoid Enemy Way
        List<String> AvoidEnemyWay(List<String> ways, String color)
        {
            String enemyColor = color.Equals("Black") ? "White" : "Black";
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j] != null && board[i, j].Color.Equals(enemyColor))
                    {
                        List<String> avoidWays = new List<string>(ways);
                        AvoidChessman avoidChessman = AvoidPawn;
                        foreach (string way in ways)
                        {
                            switch (board[i, j].Name)
                            {
                                case "Pawn":
                                    avoidChessman = AvoidPawn;
                                    break;
                                case "Castle":
                                    avoidChessman = AvoidCastle;
                                    break;
                                case "Knight":
                                    avoidChessman = AvoidKnight;
                                    break;
                                case "Bishop":
                                    avoidChessman = AvoidBishop;
                                    break;
                                case "Queen":
                                    avoidChessman = AvoidQueen;
                                    break;
                                case "King":
                                    avoidChessman = AvoidKing;
                                    break;
                            }
                            if (avoidChessman(way, enemyColor, i, j))
                            {
                                avoidWays.Remove(way);
                            }
                        }
                        ways = avoidWays;
                    }
                }
            }
            return ways;
        }

        bool AvoidPawn(String way, String enemyColor, int i, int j)
        {
            (int xK, int yK) = getIndexInt(way);
            int direction = enemyColor.Equals("Black") ? 1 : -1;
            if (Math.Abs(xK - i) == 1 && yK - j == direction)
            {
                return true;
            }
            return false;
        }

        bool AvoidCastle(String way, String enemyColor, int i, int j)
        {
            (int xK, int yK) = getIndexInt(way);
            (int xRK, int yRK) = getIndexInt(kingIndex(enemyColor));
            if (xK - i == 0 ^ yK - j == 0)
            {
                bool x_ray = xK == i;
                bool checkChessmanBetween = true;
                int k;
                int step = x_ray ? (yK - j > 0 ? 1 : -1) : (xK - i > 0 ? 1 : -1);
                for (k = (x_ray ? j : i) + step; checkChessmanBetween; k = k + step)
                {
                    if ((board[xK, k] != null && x_ray) || (board[k, yK] != null && !x_ray))
                    {
                        break;
                    }
                    checkChessmanBetween = (k != (x_ray ? yK : xK) - step) && k > 0 && k< 7;
                    if (k == (x_ray ? yK : xK)) { break; }
                }
                if ((!checkChessmanBetween) 
                    || (checkChessmanBetween && k == (x_ray ? yRK : xRK))
                    || (checkChessmanBetween && k == (x_ray ? yK : xK))
                    )
                {
                    return true;
                }
            }
            return false;
        }

        bool AvoidKnight(String way, String enemyColor, int i, int j)
        {
            (int xK, int yK) = getIndexInt(way);
            if ((Math.Abs(xK - i) == 2 || Math.Abs(xK - i) == 1)
                && (Math.Abs(yK - j) == 2 || Math.Abs(yK - j) == 1)
                && Math.Abs(yK - j) != Math.Abs(xK - i)
            )
            {
                return true;
            }
            return false;
        }

        bool AvoidBishop(String way, String enemyColor, int i, int j)
        {
            (int xK, int yK) = getIndexInt(way);
            (int xRK, int yRK) = getIndexInt(kingIndex(enemyColor));
            if (Math.Abs(xK - i) == Math.Abs(yK - j) && xK - i != 0)
            {
                int Xdirection = xK - i > 0 ? 1 : -1;
                int Ydirection = yK - j > 0 ? 1 : -1;
                bool check = false;
                int k;
                for (k = 1; k < Math.Abs(xK - i); k++)
                {
                    if (board[i + k * Xdirection, j + k * Ydirection] != null)
                    {
                        check = true;
                        break;
                    }
                }
                if ((!check) || (check && (i + k * Xdirection) == xRK ))
                {
                    return true;
                }
            }
            return false;
        }

        bool AvoidQueen(String way, String enemyColor, int i, int j)
        {
            return AvoidCastle(way, enemyColor, i, j) || AvoidBishop(way, enemyColor, i, j);
        }

        bool AvoidKing(String way, String enemyColor, int i, int j)
        {
            (int xK, int yK) = getIndexInt(way);
            if (Math.Abs(xK - i) <= 1 && Math.Abs(yK - j) <= 1)
            {
                return true;
            }
            return false;
        }

        #endregion

        #region Chessman orther King can't move if King will be attacked
        List<String> protectKingByMove(List<String> ways, String color, String index)
        {
            String enemyColor = color.Equals("Black") ? "White" : "Black";
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j] != null && board[i, j].Color.Equals(enemyColor))
                    {
                        List<String> avoidWays = new List<string>(ways);
                        AvoidChessman protectKing = protectFromPawn;
                        foreach (string way in ways)
                        {
                            bool rightKind = false;
                            switch (board[i, j].Name)
                            {
                                case "Pawn":
                                    if (needProtectFromPawn(index, i, j, enemyColor))
                                    {
                                        rightKind = true;
                                        protectKing = protectFromPawn;
                                    }
                                    break;
                                case "Castle":
                                    if (needProtectFromCaste(index, i, j, enemyColor))
                                    {
                                        rightKind = true;
                                        protectKing = protectFromCaste;
                                    }
                                    break;
                                case "Bishop":
                                    if (needProtectFromBishop(index, i, j, enemyColor))
                                    {
                                        rightKind = true;
                                        protectKing = protectFromBishop;
                                    }
                                    break;
                                case "Knight":
                                    if (needProtectFromKnight(index, i, j, enemyColor))
                                    {
                                        rightKind = true;
                                        protectKing = protectFromKnight;
                                    }
                                    break;
                                case "Queen":
                                    if (needProtectFromCaste(index, i, j, enemyColor))
                                    {
                                        rightKind = true;
                                        protectKing = protectFromCaste;
                                    }
                                    if (needProtectFromBishop(index, i, j, enemyColor))
                                    {
                                        rightKind = true;
                                        protectKing = protectFromBishop;
                                    }
                                    break;
                            }

                            if (rightKind && !protectKing(way,enemyColor,i,j))
                            {
                                if (!way.Equals(index))
                                {
                                    avoidWays.Remove(way);
                                }
                            }
                        }
                        ways = avoidWays;
                    }
                }
            }
            return ways;
        }

        bool needProtectFromPawn(String index, int i, int j, String enemyColor)
        {
            (int xRK, int yRK) = getIndexInt(kingIndex(enemyColor));
            int direction = enemyColor.Equals("Black") ? 1 : -1;
            if (Math.Abs(xRK - i) == 1 && yRK - j == direction)
            {
                return true;
            }
            return false;
        }

        bool protectFromPawn(String way, String enemyColor, int i, int j)
        {
            return eatToProtect(way,i,j);
        }

        bool needProtectFromCaste(String index, int i, int j, String enemyColor)
        {
            (int xRK, int yRK) = getIndexInt(kingIndex(enemyColor));
            (int xIndex, int yIndex) = getIndexInt(index);
            if (xRK == i ^ yRK == j)
            {
                bool x_ray = xRK == i;
                bool checkChessmanBetween = true;
                int step = x_ray ? (yRK - j > 0 ? 1 : -1) : (xRK - i > 0 ? 1 : -1);
                for (int k = (x_ray ? j : i) + step; checkChessmanBetween; k = k + step)
                {
                    int x = x_ray ? xRK : k;
                    int y = x_ray ? k : yRK;
                    if (board[x, y] != null)
                    {
                        Chessman chessman = board[x, y];
                        if (chessman.Color.Equals(enemyColor))
                        {
                            return false;
                        }
                        if (xRK == x && yRK == y)
                        {
                            return true;
                        }
                        if (xIndex != x || yIndex != y)
                        {
                            return false;
                        }
                    }
                    checkChessmanBetween = k != (x_ray ? yRK : xRK) - step;
                }
                return true;
            }
            return false;
        }

        bool protectFromCaste(String way, String enemyColor, int i, int j)
        {
            (int xIndex, int yIndex) = getIndexInt(way);
            (int xRK, int yRK) = getIndexInt(kingIndex(enemyColor));
            bool x_ray = xRK == i;
            bool checkChessmanBetween = true;
            int k;
            int step = x_ray ? (yRK - j > 0 ? 1 : -1) : (xRK - i > 0 ? 1 : -1);
            for (k = (x_ray ? j : i); checkChessmanBetween; k = k + step)
            {
                int x = x_ray ? xRK : k;
                int y = x_ray ? k : yRK;
                if (x == xIndex && y == yIndex)
                {
                    return true;
                }
                checkChessmanBetween = k != (x_ray ? yRK : xRK) - step;
            }
            return false;
        }

        bool needProtectFromBishop(String index, int i, int j, String enemyColor)
        {
            (int xIndex, int yIndex) = getIndexInt(index);
            (int xRK, int yRK) = getIndexInt(kingIndex(enemyColor));
            if (Math.Abs(xRK - i) == Math.Abs(yRK - j) && xRK - i != 0)
            {
                int Xdirection = xRK - i > 0 ? 1 : -1;
                int Ydirection = yRK - j > 0 ? 1 : -1;
                int k;
                for (k = 1; k < Math.Abs(xRK - i); k++)
                {
                    int x = i + k * Xdirection;
                    int y = j + k * Ydirection;
                    Chessman chessman = board[x, y];
                    if (chessman != null)
                    {
                        if (chessman.Color.Equals(enemyColor))
                        {
                            return false;
                        } else if (xIndex != x || yIndex != y)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            return false;
        }

        bool protectFromBishop(String way, String enemyColor, int i, int j)
        {
            (int xIndex, int yIndex) = getIndexInt(way);
            (int xRK, int yRK) = getIndexInt(kingIndex(enemyColor));
            if (Math.Abs(xRK - i) == Math.Abs(yRK - j) && xRK - i != 0)
            {
                int Xdirection = xRK - i > 0 ? 1 : -1;
                int Ydirection = yRK - j > 0 ? 1 : -1;
                int k;
                for (k = 0; k < Math.Abs(xRK - i); k++)
                {
                    if (i + k * Xdirection == xIndex && j + k * Ydirection == yIndex)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        bool needProtectFromKnight(String index, int i, int j, String enemyColor)
        {
            (int xRK, int yRK) = getIndexInt(kingIndex(enemyColor));
            if ((Math.Abs(xRK - i) == 2 || Math.Abs(xRK - i) == 1)
                && (Math.Abs(yRK - j) == 2 || Math.Abs(yRK - j) == 1)
                && Math.Abs(yRK - j) != Math.Abs(xRK - i))
            {
                return true;
            }
            return false;
        }

        bool protectFromKnight(String way, String enemyColor, int i, int j)
        {
            return eatToProtect(way, i, j);
        }

        private bool eatToProtect(String way,int i,int j)
        {
            (int x, int y) = getIndexInt(way);
            return x == i && y == j;
        }
        #endregion

    }
}
