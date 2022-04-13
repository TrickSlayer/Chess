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
    public partial class frmHome : Form
    {
        String messConfirm { get; set; }
        String messError { get; set; }
        bool error { get; set; }
        public frmHome()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            List<String> list = new List<string>();
            list.Add("Black"); list.Add("White");
            cbColor.DataSource = list;
            panel2.Visible = false;
        }

        private void btnAchievement_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            ChessContext context = new ChessContext();
            List<User> users = context.Users.ToList();
            String NamePlayer1 = "Guess";
            String NamePlayer2 = "Guess";
            messConfirm = "";
            messError = "";
            error = false;
            NamePlayer1 = getPlayerName(tbUserName1.Text, tbPassword1.Text, 1);
            NamePlayer2 = getPlayerName(tbUserName2.Text, tbPassword2.Text, 2);
            if (error)
            {
                MessageBox.Show(messError);
            } else
            {
                if (NamePlayer1.Equals(NamePlayer2) && !NamePlayer1.Equals("Guess"))
                {
                    messConfirm = messConfirm + "Play with yoursefl will not be recorded";
                }
                if (messConfirm.Length > 0)
                {
                    DialogResult dlr = MessageBox.Show(messConfirm, "Notification", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (NamePlayer1.Equals(NamePlayer2))
                    {
                        NamePlayer1 = "Guess";
                        NamePlayer2 = "Guess";
                    }
                    if (dlr == DialogResult.OK)
                    {
                        frmGameView gameView = new frmGameView(cbColor.SelectedItem.ToString(), getPlayerIdByName(NamePlayer1), getPlayerIdByName(NamePlayer2));
                        gameView.Show();
                    }
                } else
                {
                    frmGameView gameView = new frmGameView(cbColor.SelectedItem.ToString(), getPlayerIdByName(NamePlayer1), getPlayerIdByName(NamePlayer2));
                    gameView.Show();
                }
            }
        }

        private String getPlayerName(String username, String password, int number)
        {
            ChessContext context = new ChessContext();
            List<User> users = context.Users.ToList();
            if (username.Equals(""))
            {
                messConfirm = messConfirm + $"Player {number} play as guess \n";
                return "Guess";
            }
            else
            {
                User player = users.FirstOrDefault(x => x.Username.Equals(username));
                if (player== null)
                {
                    return signUp(username, password, number);
                } else
                {
                    return login(player, password,number);
                }
            }
        }

        private String login(User player, String password,int number)
        {
            if (player.Password.Equals(password))
            {
                return player.Username;
            }
            else
            {
                messError = messError + $"Password of player {number} not correct\n";
                error = true;
                return "";
            }
        }

        private String signUp(String username, String pass, int number)
        {
            if (pass.Equals(""))
            {
                messError = messError + $"Player {number} must fill password\n";
                error = true;
                return "";
            } else
            {
                User user = new User();
                user.Username = username;
                user.Password = pass;
                using (var context = new ChessContext())
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                }
                messConfirm = messConfirm + $"Player {number} sign up successfully\n";
                return $"Player {user.Username}";
            }
        }

        private int getPlayerIdByName(String name)
        {
            ChessContext context = new ChessContext();
            List<User> users = context.Users.ToList();
            User player = users.FirstOrDefault(x => x.Username.Equals(name));
            return player != null ? player.Id : 0;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            frmAchievement newForm = new frmAchievement(tbUserNameAchievement.Text);
            newForm.Show();
        }
    }
}
