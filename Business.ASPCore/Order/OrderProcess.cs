using System;
using static Entities.ASPCore.Enums;
using Data.ASPCore;

namespace Business.ASPCore.Order
{
    public class OrderProcess
    {
        public OrderResult Get_Orders(int UserId)
        {

            OrderResult result = new OrderResult()
            {
                IsValid = true,
                Title = "",
                Message = "Sucess",
                ResultType = ResultType.Success,
            };
            try
            {
                OrderDAO orderDAO = new OrderDAO();
                result.Orders = orderDAO.Get_Orders(UserId);
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
