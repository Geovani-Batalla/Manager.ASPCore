using System;
using System.Collections.Generic;
using System.Text;
using static Entities.ASPCore.Enums;

namespace Business.ASPCore.DropBox
{
    internal class DropBoxValidation
    {
        internal static void ValidateId(int Id, ref DropBoxResult result)
        {
            if (Id <= 0)
            {
                result.IsValid = false;
                result.Message = "The id is required";
                result.ResultType = ResultType.Error;
            }
        }
    }
}
