using Data.ASPCore;
using System;
using static Entities.ASPCore.Enums;

namespace Business.ASPCore.UserProcess
{
    public class UserProcess
    {
        public UserResult Get(string userName)
        {
            UserResult result = new UserResult()
            {
                IsValid = true,
                Title = "",
                Message = "",
                ResultType = ResultType.Success
            };
            try
            {
                UserValidation.ValidateGetByUserName(userName, ref result);
                if (!result.IsValid)
                {
                    return result;
                }
                UserDAO UserDAO = new UserDAO();
                result.User = UserDAO.Get(userName);
            }
            catch (Exception ex)
            {
                result.IsValid = false;
                result.Message = ex.Message;
                result.ResultType = ResultType.Error;
            }
            return result;
        }
    }
}
