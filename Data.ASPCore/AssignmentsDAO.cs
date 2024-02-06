using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wupzi.Entities.ASPCore.Assignments;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Entities.ASPCore;
using Entities.ASPCore.Estimates_Models;

namespace Data.ASPCore
{
    public class AssignmentsDAO
    {
        public async Task<Entities.ASPCore.Assignments.Assignments> Add(Assignments assignments)
        {
            Assignments result = new Assignments();
            try
            {
                using (DbContext db = new DbContext())
                {
                    db.Assignments.Add(assignments);
                    await db.SaveChangesAsync();
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return assignments;
        }

       public async Task<Entities.ASPCore.Assignments.Assignments> Get_Assignments(string Guid, int Company_Id)
        {
            Entities.ASPCore.Assignments.Assignments result = new Assignments();
            try
            {
                using (DbContext db = new DbContext())
                {
                    result = await (from Assignments in db.Assignments
                                    join Assigments_Type in db.Assigments_Type on Assignments.Assigment_Type_Id equals Assigments_Type.Id
                                    join User in db.User on Assignments.CreationUser equals User.Id
                                    where Assignments.Assignments_Guid == Guid
                                    select new Assignments
                                    {
                                        Id = Assignments.Id,
                                        Company_Id = Assignments.Company_Id,
                                        Assigment_Type_Id = Assignments.Assigment_Type_Id,
                                        Status = Assignments.Status,
                                        Name = Assignments.Name.ToLower().Substring(0, 64),
                                        CreationDate = Assignments.CreationDate,
                                        CreationUser = Assignments.CreationUser,
                                        DueDate = Assignments.DueDate,
                                        Priority = Assignments.Priority,
                                        DueDateString = Assignments.DueDate.ToString("dd/MM/yyyy hh:mm tt"),
                                        CreationDateString = Assignments.CreationDate.ToString("dd/MM/yyyy hh:mm tt"),
                                        CreationUserName = User.Name,
                                        Assignments_Guid = Assignments.Assignments_Guid,
                                        Type_Name = Assigments_Type.Name,
                                        Customer_Name = Assignments.Customer_Name,
                                        Departments = Get_Departments_By_Assignment(Assignments.Id, Company_Id),
                                        Description = Assignments.Description,
                                        Customer_Id = Assignments.Customer_Id

                                    }).FirstOrDefaultAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        } 
    }
}
