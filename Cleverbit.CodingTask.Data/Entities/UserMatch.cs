using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cleverbit.CodingTask.Data.Entities
{
    public class UserMatch
    {
        [Key]
        public int Id { get; set; }
        public int FirstUserId { get; set; }
        public int SecondUserId { get; set; }
        public int MatchExpireSecond { get; set; }
        public bool FirstUserAccepted { get; set; }
        public bool SecondUserAccepted { get; set; }
        public int FirstUserPoint { get; set; }
        public int SecondUserPoint { get; set; }
        public int WinnerUserId { get; set; }
        public DateTime MatchEndDate { get; set; }
        [ForeignKey("FirstUserId") ]
        public User FirstUser { get; set; }
        [ForeignKey("SecondUserId")]
        public User SecondUser { get; set; }

    }
}
