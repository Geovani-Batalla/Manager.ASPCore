using System.Collections.Generic;
using System.Linq;
using Entities.ASPCore;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Data.ASPCore
{
    public class UserDAO
    {
        public async Task<User> AddAsync(User user)
        {
            try
            {
                using (Db_Context db = new Db_Context())
                {
                    db.User.Add(user);
                    await db.SaveChangesAsync();
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return user;
        }

        public async Task<User> UpdateAsync(User User)
        {
            try
            {
                using (Db_Context db = new Db_Context())
                {
                    db.User.Add(User);
                    db.Entry(User).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return User;
        }

        public void Delete(int UserId)
        {
            try
            {
                using (Db_Context db = new Db_Context())
                {
                    User User = db.User.Where(x => x.Id == UserId).FirstOrDefault();
                    db.User.Remove(User);
                    db.SaveChanges();
                }
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
            return;
        }

        public User GetByPhoneNumber(string PhoneNumber)
        {
            User result = new User();
            try
            {
                using (Db_Context db = new Db_Context())
                {
                    result = (from User in db.User
                              where User.PhoneNumber == PhoneNumber
                              select User).FirstOrDefault();
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
