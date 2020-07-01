using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ASPCore
{
    public class Enums
    {
        public enum ResultType
        {
            Success = 1,
            Error = 2,
            Warning = 3,
            Info = 4
        }

        public enum InviteStatusIds
        {
            Sent = 1,
            UserRegistration = 2,
            UserFirstPayment = 3
        }

        public enum TransactionStatusId
        {
            NewOrder = 1,
            NewQuote = 2,
            FinishedOrder = 4,
            SendCustomerTinyUrl = 5
        }
        public enum FriendsRelashionshipStatus
        {
            Sent = 1,
            Accepted = 2,
            Rejected = 3,
            Deleted = 4
        }

        public enum FriendsRelashionshipOrderRequest
        {
            ReceiveOnly = 1,
            SendOnly = 2,
            Both = 3
        }
    }
}
