using Chess.Game;
using Chess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class frmGameView : Form
    {
        public List<PictureBox> Cells { get; set; }
        public GamePlay game { get; set; }

        private bool endGame { get; set; } = false;
        public String chosenColor { get; set; }

        List<String> Log = new List<string>();

        int PlayerId1 { get; set; }
        int PlayerId2 { get; set; }
        String result { get; set; }

        public frmGameView(String Color, int id1, int id2)
        {
            Cells = new List<PictureBox>();
            chosenColor = Color;
            PlayerId1 = id1;
            PlayerId2 = id2;
            game = new GamePlay(chosenColor);
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Load_Index();
            Load_ChessBoard();
            LoadChessmanBegin();
            lbName1.Text = getNamePlayer(PlayerId1);
            lbName2.Text = getNamePlayer(PlayerId2);
            lbColor1.Text = chosenColor;
            lbColor2.Text = chosenColor.Equals("Black") ? "White" : "Black";
        }

        private String getNamePlayer(int id)
        {
            
            using (var context = new ChessContext())
            {
                List<User> users = context.Users.ToList();
                User player = users.FirstOrDefault(x => x.Id == id);
                return player != null ? "Player " + player.Username : "Guess";
            }
        }

        #region Load board chess at begin
        private void Load_Index()
        {
            int x = 43;
            for (int i = 0; i < 8; i++)
            {
                addLabel(new Point(x, 0), new Size(64, 20), (Char)((int)'A' + i));
                addLabel(new Point(x, 532), new Size(64, 20), (Char)((int)'A' + i));
                x = x + 64;
            }
            x = 43;
            for (int i = 0; i < 8; i++)
            {
                addLabel(new Point(0, x), new Size(20, 64), (Char)((int)'8' - i));
                addLabel(new Point(532, x), new Size(20, 64), (Char)((int)'8' - i));
                x = x + 64;
            }
        }

        private void addLabel(Point point, Size size, Char text)
        {
            Label label = new Label();
            label.Text = text.ToString();
            label.Size = size;
            label.Location = point;
            pnGamePlay.Controls.Add(label);
        }

        private void Load_ChessBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    PictureBox pictureBox = new PictureBox();
                    Char Index_X = (Char)('A' + j);
                    pictureBox.Name = Index_X.ToString() + (8 - i);
                    if ((i + j) % 2 == 0)
                    {
                        pictureBox.BackColor = Color.FromArgb(181, 136, 99);
                    } else
                    {
                        pictureBox.BackColor = Color.FromArgb(241, 217, 181);
                    }
                    pictureBox.Size = new Size(64, 64);
                    pictureBox.Location = new Point(20 + j * 64, 20 + i * 64);
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox.Click += delegate (object sender, EventArgs e)
                    {
                        if (checkBeforeSelect(pictureBox.Name))
                            ExecuteAction(game.Select(pictureBox.Name));
                    };
                    Cells.Add(pictureBox);
                    pnGamePlay.Controls.Add(pictureBox);
                }
            }
        }

        private void LoadChessmanBegin()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    String Index_Y = ((Char)((int)'1' + i)).ToString();
                    String Index_X = ((Char)((int)'A' + j)).ToString();
                    PictureBox cell = Cells.First(x => x.Name.Equals(Index_X + Index_Y));
                    if (game.board[j, i] != null)
                    {
                        cell.ImageLocation = game.board[j, i].path;
                    } else
                    {
                        cell.ImageLocation = "";
                    }
                }
            }
        }

        #endregion

        #region Execute and check

        private void ExecuteAction((String way, String log) select)
        {
            CheckAndShowPossibleWay(select.way);
            if (select.way.Contains("=>"))
            {
                MoveChessman(select.way);
                game.color = game.color.Equals("Black") ? "White" : "Black";
                ExecuteLog(select.log);
                CheckAfterMove();
            }
        }

        private void ExecuteLog(String log)
        {
            if (log.Contains("."))
            {
                Kill(log);
            }
            if (log.Contains("*"))
            {
                Update(log);
            }
            if (log.Contains("=>"))
            {
                MoveChessman(log);
            }
        }

        private void Kill(String log)
        {
            String[] part = log.Split(".");
            if (part[2].Equals("F"))
            {
                PictureBox eat = Cells.First(x => x.Name.Equals(part[1]));
                eat.ImageLocation = "";
            }
            Log.Insert(0, $"{part[3]} {part[0]} at {part[1]} was eaten");
        }

        private void Update(String log)
        {
            String[] part = log.Split("*");
            ShowUpdatePanel(part[1]);
        }

        private void MoveChessman(String log)
        {
            String[] part = log.Split("=>");
            PictureBox from = Cells.First(x => x.Name.Equals(part[0]));
            PictureBox to = Cells.First(x => x.Name.Equals(part[1]));
            to.ImageLocation = new string(from.ImageLocation);
            from.ImageLocation = "";
            Log.Insert(0, $"{part[0]} move to {part[1]}");
        }

        private bool checkBeforeSelect(String index)
        {
            bool output = true;
            output = output && checkUpdate();
            output = output && checkTurn(index);
            output = output && checkEndGame();
            return output;
        }

        private bool checkUpdate()
        {
            if (pnUpdate.Visible)
            {
                MessageBox.Show("Must Update First");
                return false;
            }
            return true;
        }

        private bool checkTurn(String index)
        {
            Chessman chessman = game.getChessman(index);
            if (chessman == null || !game.FirstCellSelected.Equals(""))
            {
                chessman = game.getFirstSelectedChessman();
            }
            if (chessman != null && !chessman.Color.Equals(game.color))
            {
                MessageBox.Show("Not your turn");
                return false;
            }
            return true;
        }

        private bool checkEndGame()
        {
            if (endGame)
            {
                
                MessageBox.Show("This game was end. Please restart");
                return false;
            } else
            {
                btnSave.Visible = false;
            }
            return true;
        }

        private void CheckAfterMove()
        {
            if (game.checkmate(game.color))
            {
                MessageBox.Show($"{game.color} King was checked");
            }
            (bool draw1, bool lose) = game.checkPlayerStatus(game.color);
            (bool draw2, bool _) = game.checkPlayerStatus(game.color.Equals("Black") ? "White" : "Black");
            if (draw1 || draw2)
            {
                endGame = true;
                result = "D";
                MessageBox.Show($"Draw");
                btnSave.Visible = true;
            }
            if (lose)
            {
                endGame = true;
                MessageBox.Show($"{game.color} team was lose");
                if (chosenColor.Equals(game.color))
                {
                    result = "L";
                } else
                {
                    result = "W";
                }
                btnSave.Visible = true;
            }
        }

        #endregion

        #region Show possible move function
        private void ShowPossibleWayByChessmanIndex(String index)
        {
            List<String> listPossibleMove = game.getPossibleMove(index);
            if (listPossibleMove.Count > 0)
            {
                foreach (String move in listPossibleMove)
                {
                    PictureBox pictureBox = Cells.First(x => x.Name.Equals(move));
                    pictureBox.BackColor = Color.LawnGreen;
                }
            } else
            {
                PictureBox pictureBox = Cells.First(x => x.Name.Equals(index));
                (int x, int y) = game.getIndexInt(index);
                if (game.board[x,y] != null)
                {
                    pictureBox.BackColor = Color.Red;
                }
            }
        }

        private void ResetPossibleWay()
        {
            List<PictureBox> possible = Cells.Where(x => x.BackColor == Color.LawnGreen).ToList();
            possible.AddRange(Cells.Where(x => x.BackColor == Color.Red).ToList());
            foreach (PictureBox possibleMove in possible)
            {
                String index = possibleMove.Name;
                (int X_index, int Y_index) = game.getIndexInt(index);
                if ((X_index + Y_index) % 2 == 0)
                {
                    possibleMove.BackColor = Color.FromArgb(241, 217, 181);
                }
                else
                {
                    possibleMove.BackColor = Color.FromArgb(181, 136, 99);
                }
            }
        }

        private void CheckAndShowPossibleWay(String index)
        {
            if (index.Length == 2)
            {
                ShowPossibleWayByChessmanIndex(index);
            }
            else
            {
                ResetPossibleWay();
            }
        }

        #endregion

        #region Update Pawn
        private void ShowUpdatePanel(String index)
        {
            pnUpdate.Visible = true;
            tbIndex.Text = index;
            List<String> list = new List<string>();
            list.Add("Queen");
            list.Add("Castle");
            list.Add("Knight");
            list.Add("Bishop");
            cbRole.DataSource = list;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            PictureBox cell = Cells.First(x => x.Name.Equals(tbIndex.Text));
            cell.ImageLocation = game.UpdatePawn(tbIndex.Text, cbRole.SelectedValue.ToString()).path;
            Log.Insert(0, $"Pawn at {tbIndex.Text} become {cbRole.SelectedValue}");
            pnUpdate.Visible = false;
        }
        #endregion

        private void btnShowLog_Click(object sender, EventArgs e)
        {
            frmLog newform = new frmLog(Log);
            newform.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Log = new List<string>();
            using (var context = new ChessContext()) { 
                Achievement achievement = new Achievement();
                if (PlayerId1 != 0)
                {
                    achievement.Player1Id = PlayerId1;
                }
                if (PlayerId2 != 0)
                {
                    achievement.Player2Id = PlayerId2;
                }
                achievement.Status = result;
                achievement.Time = DateTime.Now;
                if (PlayerId1 != 0 || PlayerId2 != 0) {
                    context.Achievements.Add(achievement);
                    context.SaveChanges();
                    MessageBox.Show("Achievement was save");
                }
            }
            game = new GamePlay(chosenColor);
            LoadChessmanBegin();
            endGame = false;
            btnSave.Visible = false;
        }

    }
}
