using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ASPCore
{
    public class JsonResponse
    {
        public int Code { get; set; }
        public int ObjectId { get; set; }
        public string Message { get; set; }
        public Object Result { get; set; }
    }
}
