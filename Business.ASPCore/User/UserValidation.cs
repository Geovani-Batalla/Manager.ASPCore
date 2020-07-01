using static Entities.ASPCore.Enums;

namespace Business.ASPCore.UserProcess
{
    internal class UserValidation
    {
        internal static void ValidateGetByUserName(string userName, ref UserResult result)
        {
            if (string.IsNullOrEmpty(userName))
            {
                result.Message = "username is required";
                result.IsValid = false;
                result.ResultType = ResultType.Info;
            }
        }
    }
}
