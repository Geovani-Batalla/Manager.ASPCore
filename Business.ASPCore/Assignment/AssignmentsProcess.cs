using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.ASPCore;
using Entities.ASPCore;
using System.Linq;
using Entities.ASPCore.Assignments;
using Business.ASPCore.Friends;
using static Dropbox.Api.Files.ListRevisionsMode;
using System.Globalization;
using Dropbox.Api.Files;

namespace Business.ASPCore.Assignments
{
    public class AssignmentsProcess
    {
        public async Task<AssignmentsResult> Get_All(int Company_Id, bool pendiente, bool enproceso, bool demorada, bool cerrada, string Type)
        {
            AssignmentsResult result = new AssignmentsResult()
            {
                IsValid = true,
                Title = "",
                Message = "",
                ResultType = ResultType.Success,
            };
            try
            {
                result.Assignments = await new AssignmentsDAO().Get_All(Company_Id, pendiente, enproceso, demorada, cerrada, Type);
                foreach (var assignment in result.Assignments)
                {
                    assignment.Is_Load_Images = assignment.IsImageLoad;
                }
            }
            catch (Exception ex)
            {
                result.IsValid = false;
                result.Message = ex.Message;
                result.ResultType = ResultType.Error;
            }
            return result;
        }

        public async Task<AssignmentsResult> Create(int company_Id, string Guid)
        {
            AssignmentsResult result = new AssignmentsResult()
            {
                IsValid = true,
                Title = "",
                Message = "",
                ResultType = ResultType.Success,
            };
            try
            {
                result.Assigments_Types = await new AssignmentsDAO().Get_Assigments_Types();
                result.Users = new UserDAO().GetUsers_For_Assigments(company_Id);
                result.Departments = await new AssignmentsDAO().Get_Departments(company_Id);
                if (Guid != null)
                {
                    result.Customer = new CustomerDAO().Get(Guid);
                    result.Quotes = await new QuoteDAO().Get_ByCustomer(result.Customer.Id);
                }
            }
            catch (Exception ex)
            {
                result.IsValid = false;
                result.Message = ex.Message;
                result.ResultType = ResultType.Error;
            }
            return result;
        }
      
        public string Get_Color(string Status)
        {
            string color = "#FF3333";
            switch (Status)
            {
                case "Pendiente":
                    color = "#FF3333";
                    break;
                case "En proceso":
                    color = "#3399CC";
                    break;
                case "Demorada":
                    color = "#FF6633";
                    break;
                case "Cerrada":
                    color = "#CC3399";
                    break;
            }
            return color;
        }

        public async Task<AssignmentsResult> Load_Details(int Assignment_Id, int company_Id)
        {
            AssignmentsResult result = new AssignmentsResult()
            {
                IsValid = true,
                Title = "",
                Message = "",
                ResultType = ResultType.Success,
            };
            try
            {
                result.Orders_Assignments = await new AssignmentsDAO().Get_Orders_Assignments(Assignment_Id);
                result.Users_Assignments = await new AssignmentsDAO().Get_Users_Assignments(Assignment_Id);
                result.IsCloseResponsible = result.Users_Assignments.Where(X => X.Type == 1).Count() >= 1;
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
