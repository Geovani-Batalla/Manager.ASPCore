using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.ASPCore
{
    public class User_Stats
    {
        [Key, Column(Order = 1)]
        public int StatsId { get; set; }
        [Key, Column(Order = 2)]
        public int UserId { get; set; }
    }
}
