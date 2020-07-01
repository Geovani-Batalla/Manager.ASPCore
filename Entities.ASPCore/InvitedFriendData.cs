using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.ASPCore
{
    public class InvitedFriendData
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string PrimaryNumber { get; set; }
        public string SecondaryPhone { get; set; }
        public string Email { get; set; }

    }
}
