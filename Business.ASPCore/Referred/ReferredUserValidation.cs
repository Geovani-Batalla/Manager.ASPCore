using Data.ASPCore;
using Entities.ASPCore;
using static Entities.ASPCore.Enums;

namespace Business.ASPCore.Referred
{
    public class ReferredUserValidation
    {
        internal static void ValidateAdd(ReferredUser referredUser, ref ReferredUserResult result)
        {
            UserDAO userDAO = new UserDAO();

            if (string.IsNullOrEmpty(referredUser.Name) ||
                   string.IsNullOrEmpty(referredUser.PhoneNumber) ||
                   string.IsNullOrEmpty(referredUser.Email))
            {
                result.Message = "Please enter all fields";
                result.IsValid = false;
                result.ResultType = ResultType.Info;
            }
            else if (userDAO.GetByPhoneNumber(referredUser.PhoneNumber) != null)
            {
                result.Message = "The user already has an account, please verify the data";
                result.IsValid = false;
                result.ResultType = ResultType.Error;
            }
        }

        internal static void ValidateGet(int UserId, ref ReferredUserResult result)
        {
            if (UserId <= 0)
            {
                result.Message = "Please enter the user id";
                result.IsValid = false;
                result.ResultType = ResultType.Info;
            }         
        }
    }
}
