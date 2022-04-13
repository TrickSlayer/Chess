using System;
using System.Collections.Generic;

#nullable disable

namespace Chess.Models
{
    public partial class Achievement
    {
        public int Id { get; set; }
        public int? Player1Id { get; set; }
        public int? Player2Id { get; set; }
        public string Status { get; set; }
        public DateTime? Time { get; set; }

        public virtual User Player1 { get; set; }
        public virtual User Player2 { get; set; }
    }
}
