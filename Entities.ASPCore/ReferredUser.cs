using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.ASPCore
{
    public class ReferredUser
    {
        [Key]
        public int Id { get; set; }
        public int ReferredBy { get; set; }
        public int InviteId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int? FirstPaymentId { get; set; }
        [NotMapped]
        public string StatusInviteName { get; set; }
        [NotMapped]
        public DateTime CreationDateInvite { get; set; }
        [NotMapped]
        public decimal Amount { get; set; }

    }
}
