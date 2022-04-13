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
    public partial class frmAchievement : Form
    {
        String userName { get; set; }
        List<Achievement> achievements { get; set; }
        public frmAchievement(String userName)
        {
            this.userName = userName;
            InitializeComponent();
        }

        private void frmAchievement_Load(object sender, EventArgs e)
        {
            DesignDgvAchievement();
            using (var context = new ChessContext())
            {
                User user = context.Users.FirstOrDefault(x => x.Username.Equals(userName));
                if (user == null)
                {
                    return;
                }
                List<Achievement> achievements = context.Achievements.ToList();
                List<Achievement> ListPlayer1 = achievements.Where(x => x.Player1Id == user.Id).ToList();
                List<Achievement> ListPlayer2 = achievements.Where(x => x.Player2Id == user.Id).ToList();
                foreach (Achievement achievement in ListPlayer2)
                {
                    int? id = achievement.Player1Id;
                    achievement.Player1Id = achievement.Player2Id;
                    achievement.Player2Id = id;
                    User? player = achievement.Player1 == null ? null :(User) achievement.Player1.Clone();
                    achievement.Player1 = achievement.Player2 == null ? null : (User) achievement.Player2.Clone();
                    achievement.Player2 = player;
                    if (!achievement.Status.Equals("D"))
                    {
                        achievement.Status = achievement.Status.Equals("W") ? "L" : "W";
                    }
                    ListPlayer1.Add(achievement);
                }
                this.achievements = ListPlayer1;
                dgvAchievement.DataSource = ListPlayer1;
            }
        }

        private void DesignDgvAchievement()
        {
            dgvAchievement.AutoGenerateColumns = false;
            dgvAchievement.Columns.Add("player1", "Player");
            dgvAchievement.Columns["player1"].DataPropertyName = "Player1Name";
            dgvAchievement.Columns.Add("status", "Status");
            dgvAchievement.Columns["status"].DataPropertyName = "Status";
            dgvAchievement.Columns.Add("player2", "Player");
            dgvAchievement.Columns["player2"].DataPropertyName = "Player2Name";
            dgvAchievement.Columns.Add("time", "Time");
            dgvAchievement.Columns["time"].DataPropertyName = "Time";
        }

        private bool statusSort { get; set; } = false;
        private bool player2Sort { get; set; } = false;
        private bool timeSort { get; set; } = false;

        private void dgvAchievement_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                switch (e.ColumnIndex)
                {
                    case 1:
                        if (!statusSort)
                        {
                            statusSort = true;
                            achievements = achievements.OrderBy(a => a.Status).ToList();
                        } else
                        {
                            statusSort = false;
                            achievements = achievements.OrderByDescending(a => a.Status).ToList();
                        }
                        break;
                    case 2:
                        if (!player2Sort)
                        {
                            player2Sort = true;
                            achievements = achievements.OrderBy(a => a.Player2Name).ToList();
                        }
                        else
                        {
                            player2Sort = false;
                            achievements = achievements.OrderByDescending(a => a.Player2Name).ToList();
                        }
                        break;
                    case 3:
                        if (!timeSort)
                        {
                            timeSort = true;
                            achievements = achievements.OrderBy(a => a.Time).ToList();
                        }
                        else
                        {
                            timeSort = false;
                            achievements = achievements.OrderByDescending(a => a.Time).ToList();
                        }
                        break;
                }
            }
            dgvAchievement.DataSource = achievements;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dgvAchievement.DataSource = (achievements == null ? null : achievements.Where(x => x.Player2Name.Contains(tbName2.Text)).ToList());
        }
    }
}
