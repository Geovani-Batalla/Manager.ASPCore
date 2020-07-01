using Entities.ASPCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using static Entities.ASPCore.Enums;

namespace Data.ASPCore
{
    public class ReferredDAO
    {
        //ADDS-----
        public async Task<ReferredInvite> Add(ReferredInvite referredInvite)
        {
            try
            {
                using (Db_Context db = new Db_Context())
                {
                    db.ReferredInvite.Add(referredInvite);
                    await db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return referredInvite;
        }

        //GETS-----
        public List<ReferredUser> GetAllByUser(int userId)
        {
            List<ReferredUser> result = new List<ReferredUser>();

            try
            {
                using (Db_Context db = new Db_Context())
                {

                    result = (from referredUser in db.ReferredUser
                              join referredInvite in db.ReferredInvite on referredUser.InviteId equals referredInvite.Id
                              where referredUser.ReferredBy == userId
                              select new ReferredUser()
                              {
                                  CreationDateInvite = referredInvite.CreationDate,
                                  Email = referredUser.Email,
                                  Id = referredUser.Id,
                                  InviteId = referredInvite.Id,
                                  Name = referredUser.Name,
                                  PhoneNumber = referredUser.PhoneNumber,
                                  ReferredBy = referredUser.ReferredBy,
                                  FirstPaymentId = referredUser.FirstPaymentId,
                                  StatusInviteName =
                                    referredInvite.Status == (int)InviteStatusIds.Sent ? "Enviada" :
                                    referredInvite.Status == (int)InviteStatusIds.UserRegistration ? "Usuario registrado" :
                                    referredInvite.Status == (int)InviteStatusIds.UserFirstPayment ? "Usuario pagado" : "",
                                  Amount = (from payment in db.UserAccountPayments
                                            where referredUser.FirstPaymentId == payment.Id
                                                && payment.Status == 3
                                            select payment.Amount).FirstOrDefault()
                              }).ToList();
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
