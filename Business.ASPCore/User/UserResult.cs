using Entities.ASPCore;

namespace Business.ASPCore.UserProcess
{
    public class UserResult: Result
    {
        public UserResult()
        {
            User = new User(); 
        }
        public User User { get; set; }
    }
}
