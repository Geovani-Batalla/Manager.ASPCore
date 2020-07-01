using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.ASPCore
{
    public class Stats
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal TotalSales { get; set; }
        public int TotalOrders { get; set; }
        public int TotalProducts { get; set; }
        public decimal? TotalExpenses { get; set; }
    }
}
