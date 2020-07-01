using System;
using System.Threading.Tasks;
using static Entities.ASPCore.Enums;
using Entities.ASPCore;
using Data.ASPCore;

namespace Business.ASPCore.Referred
{
    public class ReferredUserProcess
    {
        async public Task<ReferredUserResult> Add(string Name, string PhoneNumber, string Email, int CompanySize,
            int WebPage, int UserSource, int Country, int UserId)
        {
            ReferredUserResult result = new ReferredUserResult()
            {
                IsValid = true,
                Title = "Invitation",
                Message = "Sucess",
                ResultType = ResultType.Success,
            };
            try
            {
                ReferredUser referredUser = new ReferredUser()
                {
                    Id = 0,
                    ReferredBy = UserId,
                    InviteId = UserId,
                    Name = Name,
                    PhoneNumber = PhoneNumber,
                    Email = Email
                };

                ReferredUserValidation.ValidateAdd(referredUser, ref result);
                if (!result.IsValid)
                {
                    return result;
                }

                //CREATE INVITATION
                ReferredDAO referredDAO = new ReferredDAO();
                ReferredInvite referredInvite = new ReferredInvite();
                referredInvite.CreationDate = DateTime.Now;
                referredInvite.ExpireDate = DateTime.Now.AddDays(21);
                referredInvite.Status = (int)InviteStatusIds.Sent;
                ReferredInvite inviteCreated = await referredDAO.Add(referredInvite);
            }
            catch (Exception ex)
            {
                result.IsValid = false;
                result.Message = ex.Message;
                result.ResultType = ResultType.Error;
            }
            return result;
        }


        public ReferredUserResult GetReferralsByUser(int userId)
        {
            ReferredDAO referredDAO = new ReferredDAO();

            ReferredUserResult result = new ReferredUserResult()
            {
                IsValid = true,
                Title = "Select referreds",
                Message = "Sucess",
                ResultType = ResultType.Success,
            };
            try
            {
                ReferredUserValidation.ValidateGet(userId, ref result);
                if (!result.IsValid)
                {
                    return result;
                }
                result.Referreds = referredDAO.GetAllByUser(userId);
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
