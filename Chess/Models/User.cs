using System;
using System.Collections.Generic;

#nullable disable

namespace Chess.Models
{
    public partial class User
    {
        public User()
        {
            AchievementPlayer1s = new HashSet<Achievement>();
            AchievementPlayer2s = new HashSet<Achievement>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Achievement> AchievementPlayer1s { get; set; }
        public virtual ICollection<Achievement> AchievementPlayer2s { get; set; }
    }
}
