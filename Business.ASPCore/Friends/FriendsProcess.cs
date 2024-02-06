using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Entities.ASPCore.Enums;
using Business.ASPCore.DropBox;
using Entities.ASPCore;
using Data.ASPCore;

namespace Business.ASPCore.Friends
{
    public class FriendsProcess
    {
        async public Task<FriendsResult> Add(string Name, string Phone_1, string Phone_2, string Email, int companyId,
         string Username, int countryId)
        {
            FriendsResult result = new FriendsResult()
            {
                IsValid = true,
                Title = "",
                Message = "",
                ResultType = ResultType.Success,
            };
            try
            {
                InvitedFriendData invitedFriendData = new InvitedFriendData()
                {
                    Id = 0,
                    Name = Name,
                    PrimaryNumber = Phone_1,
                    SecondaryPhone = Phone_2,
                    Email = Email
                };

                FriendsDAO friendsDAO = new FriendsDAO();
                result.InvitedFriendData = await friendsDAO.AddInvitedFriendDataAsync(invitedFriendData);
            
                FriendRelashionship friendRelashionshipSaved  = friendsDAO.ValidateExistingRelationship(Phone_1, Phone_2, Email);
                FriendRelashionship friendRelashionship = new FriendRelashionship()
                {
                    Id = 0,
                    SenderCompanyId = companyId,
                    ReceiverCompanyId = null,
                    ReceiverInviteDataId = result.InvitedFriendData.Id,
                    Status = (int)FriendsRelashionshipStatus.Sent,
                    OrderRequest = (int)FriendsRelashionshipOrderRequest.Both
                };
                if (friendRelashionshipSaved != null)
                {
                    friendRelashionship.ReceiverCompanyId = friendRelashionshipSaved.Id;
                }

                FriendsValidation.ValidateAdd(friendRelashionship, ref result);
                if (!result.IsValid)
                {
                    return result;
                }
               
                result.FriendRelashionship = await friendsDAO.AddFriendRelationshipAsync(friendRelashionship);
            }
            catch (Exception ex)
            {
                result.IsValid = false;
                result.Message = ex.Message;
                result.ResultType = ResultType.Error;
            }
            return result;
        }
        public async Task<FriendsResult> GetFiles(int UserLogedId)
        {
            FriendsResult result = new FriendsResult()
            {
                IsValid = true,
                Title = "",
                Message = "",
                ResultType = ResultType.Success,
            };
            try
            {
                FriendsValidation.ValidateId(UserLogedId, ref result);
                if (result.IsValid)
                {
                    return result;
                }
                result.DropBoxFiles = new DropBoxProcess().GetFiles(UserLogedId).Result.DropBoxFiles;
            }
            catch (Exception ex)
            {
                result.IsValid = false;
                result.Message = ex.Message;
                result.ResultType = ResultType.Error;
            }
            return result;
        }

        async public Task<FriendsResult> DownloadFile(string FilePath)
        {
            FriendsResult result = new FriendsResult()
            {
                IsValid = true,
                Title = "",
                Message = "",
                ResultType = ResultType.Success,
            };
            try
            {
                FriendsValidation.ValidatePath(FilePath, ref result);
                if (!result.IsValid)
                {
                    return result;
                }
                DropBoxResult dropBoxResult = await new DropBoxProcess().DownloadFile(FilePath);
                result.Image_Name = dropBoxResult.Image_Name;
                result.Image = dropBoxResult.Image;
            }
            catch (Exception ex)
            {
                result.IsValid = false;
                result.Message = ex.Message;
                result.ResultType = ResultType.Error;
            }
            return result;
        }

        public FriendsResult GetFriends(int companyId)
        {
            FriendsResult result = new FriendsResult()
            {
                IsValid = true,
                Title = "",
                Message = "",
                ResultType = ResultType.Success,
            };
            try
            {
                result.FriendRelashionships = new FriendsDAO().GetFriends(companyId);
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
