using Entities.ASPCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ASPCore.Order
{
    public class OrderResult : Result
    {
        public OrderResult()
        {
            List<Entities.ASPCore.Order> Orders = new List<Entities.ASPCore.Order>();
        }
        public List<Entities.ASPCore.Order> Orders { get; set; }
    }
    
}
