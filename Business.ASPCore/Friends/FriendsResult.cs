using Entities.ASPCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ASPCore.Friends
{
    public class FriendsResult: Result
    {
        public FriendsResult()
        {
            List<DropBoxFiles> DropBoxFiles = new List<DropBoxFiles>();
            FriendRelashionship FriendRelashionship = new FriendRelashionship();
            InvitedFriendData InvitedFriendData = new InvitedFriendData();
        }
        public List<FriendRelashionship> FriendRelashionships { get; set; }
        public FriendRelashionship FriendRelashionship { get; set; }
        public InvitedFriendData InvitedFriendData { get; set; }
        public List<DropBoxFiles> DropBoxFiles { get; set; }
        public List<byte[]> Images { get; set; }
        public int CountFiles { get; set; }
        public List<string> Files { get; set; }
        public byte[] Image { get; set; }
        public string Image_Name { get; set; }
    }
}
