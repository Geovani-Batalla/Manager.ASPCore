using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.ASPCore
{
    public class ReferredInvite
    {
        [Key]
        public int Id { get; set; }
        public int Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
