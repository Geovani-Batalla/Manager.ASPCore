using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.ASPCore;
using static Entities.ASPCore.Enums;
using System.Threading.Tasks;

namespace Data.ASPCore
{
    public class FriendsDAO
    {
        public List<FriendRelashionship> GetFriends(int companyId)
        {
            List<FriendRelashionship> result = new List<FriendRelashionship>();
            try
            {
                using (Db_Context db = new Db_Context())
                {
                    result = (from FriendRelashionship in db.FriendRelashionship
                              join InvitedFriendData in db.InvitedFriendData on
                              FriendRelashionship.ReceiverInviteDataId equals InvitedFriendData.Id
                              where FriendRelashionship.SenderCompanyId == companyId
                              select new FriendRelashionship()
                              {
                                  Id = FriendRelashionship.Id,
                                  SenderCompanyId = FriendRelashionship.SenderCompanyId,
                                  ReceiverCompanyId = FriendRelashionship.ReceiverCompanyId,
                                  StatusName =
                                  FriendRelashionship.Status == (int)FriendsRelashionshipStatus.Sent ? "Enviada" :
                                  FriendRelashionship.Status == (int)FriendsRelashionshipStatus.Accepted ? "Aceptada" :
                                  FriendRelashionship.Status == (int)FriendsRelashionshipStatus.Rejected ? "Rechazada" : "",
                                  CompanyName = InvitedFriendData.Name,
                                  Phone = InvitedFriendData.PrimaryNumber,
                                  Email = InvitedFriendData.Email

                              }).ToList();
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return result;
        }

        async public Task<InvitedFriendData> AddInvitedFriendDataAsync(InvitedFriendData invitedFriendData)
        {
            try
            {
                using (Db_Context db = new Db_Context())
                {
                    db.InvitedFriendData.Add(invitedFriendData);
                    await db.SaveChangesAsync();
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return invitedFriendData;
        }

        async public Task<FriendRelashionship> AddFriendRelationshipAsync(FriendRelashionship friendRelashionship)
        {
            try
            {
                using (Db_Context db = new Db_Context())
                {
                    db.FriendRelashionship.Add(friendRelashionship);
                    await db.SaveChangesAsync();
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return friendRelashionship;
        }

        public FriendRelashionship ValidateExistingRelationship(string Phone_1, string Phone_2, string Email)
        {
            FriendRelashionship result = new FriendRelashionship();
            try
            {
                using (Db_Context db = new Db_Context())
                {

                    result = (from FriendRelashionship in db.FriendRelashionship
                              join InvitedFriendData in db.InvitedFriendData on
                              FriendRelashionship.ReceiverInviteDataId equals InvitedFriendData.Id
                              where InvitedFriendData.PrimaryNumber == Phone_1 || InvitedFriendData.SecondaryPhone == Phone_2 ||
                                     InvitedFriendData.Email == Email select FriendRelashionship).SingleOrDefault();
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
