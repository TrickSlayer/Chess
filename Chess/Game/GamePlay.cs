using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Game
{
    public partial class GamePlay
    {
        public Chessman[,] board { get; set; }
        private bool moved { get; set; } = false;
        public String FirstCellSelected { get; set; } = "";
        public String? SecondCellSelected { get; set; }
        private String BlackKingIndex { get; set; } = "E1";
        private String WhiteKingIndex { get; set; } = "D8";
        public String color { get; set; } = "Black";
        private String specialLog { get; set; } = "";

        public GamePlay(String color)
        {
            this.color = color;
            LoadChessman();
        }

        public void LoadChessman()
        {
            board =  new Chessman[8, 8];
            for (int i = 0; i < 16; i++)
            {
                int x_index = (i < 8 ? i : i - 8);
                int y_index = (i < 8 ? 1 : 6);
                int protectedChessmanIndex = y_index + (i < 8 ? -1 : 1);
                String color = (i < 8 ? "Black" : "White");
                board[x_index, y_index] = new Chessman("Pawn", color);
                switch (Math.Abs(((double)x_index) - 3.5))
                {
                    case 3.5:
                        board[x_index, protectedChessmanIndex] = new Chessman("Castle", color);
                        break;
                    case 2.5:
                        board[x_index, protectedChessmanIndex] = new Chessman("Knight", color);
                        break;
                    case 1.5:
                        board[x_index, protectedChessmanIndex] = new Chessman("Bishop", color);
                        break;
                    case 0.5:
                        if (color.Equals("Black") ^ x_index == 4)
                        {
                            board[x_index, protectedChessmanIndex] = new Chessman("Queen", color);
                        }
                        else
                        {
                            board[x_index, protectedChessmanIndex] = new Chessman("King", color);
                        }
                        break;
                }
            }
        }

        public (String move,String log) Select(String cell)
        {
            if (FirstCellSelected.Equals(""))
            {
                setFirstCellSelected(cell);
                return (cell,specialLog);
            } else
            {
                if (FirstCellSelected.Equals(cell))
                {
                    FirstCellSelected = "";
                    return ("Unselected",specialLog);
                } else
                {
                    SecondCellSelected = cell;
                    if (Move(FirstCellSelected, SecondCellSelected))
                    {
                        moved = true;
                        (String output, String log) = (FirstCellSelected + "=>" + SecondCellSelected, specialLog);
                        ResetSelectIfMove();
                        specialLog = "";
                        return (output,log);
                    } else
                    {
                        return (FirstCellSelected, specialLog);
                    }
                }
            }
        }

        #region Function of Select()
        private void ResetSelectIfMove()
        {
            if (moved)
            {
                moved = false;
                FirstCellSelected = "";
            }
        }

        private void setFirstCellSelected(String cell)
        {
            (int X_index, int Y_index) = getIndexInt(cell);
            if (board[X_index, Y_index] != null)
            {
                FirstCellSelected = cell;
            }
        }
        #endregion

        private bool Move(String First, String Second)
        {
            (int X_indexFirst,int Y_indexFirst) = getIndexInt(First);
            (int X_indexSecond, int Y_indexSecond) = getIndexInt(Second);
            List<String> possibleMove = getPossibleMove(First);
            if (possibleMove.Where(x => x.Equals(Second)).ToList().Count > 0)
            {
                if (!specialMove(First, Second))
                {
                    if (board[X_indexSecond, Y_indexSecond] != null)
                    {
                        Chessman chessman = board[X_indexSecond, Y_indexSecond];
                        specialLog = $"{chessman.Name}.{indexString(X_indexSecond, Y_indexSecond)}.T.{chessman.Color}";
                    }
                    board[X_indexSecond, Y_indexSecond] = (Chessman)board[X_indexFirst, Y_indexFirst].Clone();
                    board[X_indexFirst, Y_indexFirst] = null;
                }
                setKingStatus(board[X_indexSecond, Y_indexSecond], Second);
                setCastleStatus(board[X_indexSecond, Y_indexSecond]);
                setPawnStatus(board[X_indexSecond, Y_indexSecond], First, Second);
                return true;
            }
            return false;
        }

        #region Set chessman status
        private void setKingStatus(Chessman chessman, String index)
        {
            if (chessman.Name.Equals("King"))
            {
                if (chessman.Color.Equals("Black"))
                {
                    BlackKingIndex = index;
                }
                else
                {
                    WhiteKingIndex = index;
                }
                chessman.status = false;
            }
        }

        private void setCastleStatus(Chessman chessman)
        {
            if (chessman.Name.Equals("Castle"))
            {
                chessman.status = false;
            }
        }

        private void setPawnStatus(Chessman chessman, String First, String Second)
        {
            resetPawnStatus(chessman.Color.Equals("Black") ? "White" : "Black");
            if (chessman.Name.Equals("Pawn"))
            {
                (int X_indexFirst, int Y_indexFirst) = getIndexInt(First);
                (int X_indexSecond, int Y_indexSecond) = getIndexInt(Second);
                if (X_indexFirst == X_indexSecond && Math.Abs(Y_indexFirst - Y_indexSecond) == 2)
                {
                    chessman.status = false;
                }
            }
        }

        private void resetPawnStatus(String color)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Chessman chessman = board[i, j];
                    if (chessman != null && chessman.Color.Equals(color) && chessman.Name.Equals("Pawn"))
                    {
                        chessman.status = true;
                    }
                }
            }
        }
        #endregion
    }
}
