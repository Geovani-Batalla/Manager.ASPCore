using Entities.ASPCore;
using static Entities.ASPCore.Enums;

namespace Business.ASPCore.Friends
{
    public class FriendsValidation
    {
        internal static void ValidateAdd(FriendRelashionship friendsRelashionship, ref FriendsResult result)
        {
            if (friendsRelashionship.SenderCompanyId <= 0 || friendsRelashionship.ReceiverInviteDataId <= 0 ||
                friendsRelashionship.Status <= 0 || friendsRelashionship.OrderRequest <= 0)
            {
                result.Message = "Please enter all fields";
                result.IsValid = false;
                result.ResultType = ResultType.Info;
            }
        }

        internal static void ValidatePath(string FilePath, ref FriendsResult result)
        {
            if (string.IsNullOrEmpty(FilePath))
            {
                result.IsValid = false;
                result.Message = "The file path is empty";
                result.ResultType = ResultType.Error;
            }
        }

        internal static void ValidateId(int Id, ref FriendsResult result)
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
