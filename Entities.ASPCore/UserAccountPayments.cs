using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.ASPCore
{
    public class UserAccountPayments
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CompanyPaymentMethodID { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Voucher { get; set; }
        public string Reference { get; set; }
    }
}
