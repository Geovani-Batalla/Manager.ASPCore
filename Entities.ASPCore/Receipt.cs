using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.ASPCore
{
    public class Receipt
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
    }
}
