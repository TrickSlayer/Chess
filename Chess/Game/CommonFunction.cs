using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Game
{
    partial class GamePlay
    {

        #region Transferred string and int index
        public (int X_index, int Y_index) getIndexInt(String index)
        {
            char[] part = index.ToCharArray();
            int X_index = (int)(part[0] - 'A');
            int Y_index = (int)(part[1] - '1');
            return (X_index, Y_index);
        }

        private String X_String(int X_index)
        {
            return ((Char)((int)'A' + X_index)).ToString();
        }
        private String Y_String(int Y_index)
        {
            return ((Char)((int)'1' + Y_index)).ToString();
        }
        public String indexString(int X_index, int Y_index)
        {
            return X_String(X_index) + Y_String(Y_index);
        }
        #endregion


        public Chessman getChessman(String index)
        {
            (int X_index, int Y_index) = getIndexInt(index);
            return board[X_index, Y_index];
        }

        public Chessman getFirstSelectedChessman()
        {
            String index = FirstCellSelected;
            if (!index.Equals(""))
            {
                (int X_index, int Y_index) = getIndexInt(index);
                return board[X_index, Y_index];
            }
            return null;
        }
    }
}
