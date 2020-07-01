using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.ASPCore
{
    public class FriendRelashionship
    {
        [Key]
        public int Id { get; set; }
        public int SenderCompanyId { get; set; }
        public int? ReceiverCompanyId { get; set; }
        public int ReceiverInviteDataId { get; set; }
        public int Status { get; set; }
        public int OrderRequest { get; set; }

        [NotMapped]
        public string CompanyName { get; set; }
        [NotMapped]
        public string StatusName { get; set; }
        [NotMapped]
        public string Phone { get; set; }
        [NotMapped]
        public string Email { get; set; }
    }
}
