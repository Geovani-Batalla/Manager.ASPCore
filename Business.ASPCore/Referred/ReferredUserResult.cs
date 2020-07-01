using Entities.ASPCore;
using System;
using System.Collections.Generic;
using System.Text;
using Data.ASPCore;

namespace Business.ASPCore.Referred
{
    public class ReferredUserResult: Result
    {
        public ReferredUserResult()
        {
            List<ReferredUser> Referreds = new List<ReferredUser>();
        }
        public List<ReferredUser> Referreds { get; set; }

    }
}
