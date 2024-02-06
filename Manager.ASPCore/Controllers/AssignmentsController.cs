using Dropbox.Api.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Threading;
using System.Threading.Tasks;
using Business.ASPCore;
using Business.ASPCore.Assignments;
using Business.ASPCore.Friends;
using Data.ASPCore;
using Entities.ASPCore;
using Entities.ASPCore.Assignments;
using static Dropbox.Api.Files.ListRevisionsMode;

namespace Manager.ASPCore.Controllers
{
    public class AssignmentsController : BaseController
    {
        public async Task<JsonResponse> Json_Index(bool pendiente, bool enproceso, bool demorada, bool cerrada, string type)
        {
            JsonResponse response = new JsonResponse();
            try
            {
                AssignmentsResult result = await new AssignmentsProcess().Get_All(Userloged.CompanyId, pendiente, enproceso, demorada, cerrada, type);
                response.Code = 400;
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Code = 401;
            }
            return response;
        }

        public async Task<IActionResult> Create(string Guid)
        {
            AssignmentsResult result = await new AssignmentsProcess().Create(Userloged.CompanyId, Guid);
            return View(result);
        }

        public async Task<IActionResult> Details(string Guid)
        {
            AssignmentsResult result = await new AssignmentsProcess().Details(Guid, Userloged.CompanyId, Userloged.RolId);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Details(IFormCollection collection, int Id)
        {
            string title = collection["assigment_title"].ToString();
            string priority = collection["assigment_priority"].ToString();
            string datetime = collection["Deadline"].ToString();
            int.TryParse(collection["assigment_type"].ToString(), out int type);

            Assignments assignments = new Assignments()
            {
                Id = Id,
                Name = title,
                Priority = priority,
                DueDate = Convert.ToDateTime(datetime),
                Assigment_Type_Id = type
            };
            AssignmentsResult result = await new AssignmentsProcess().Update(assignments, 0);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Load_Details(int Assignment_Id)
        {
            JsonResponse response = new JsonResponse();
            try
            {
                AssignmentsResult result = await new AssignmentsProcess().Load_Details(Assignment_Id, Userloged.CompanyId);
                response.Code = 400;
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Code = 401;
            }
            return Json(response);
        }
        
        public async Task<JsonResult> Add_User_Assigned(int User_Id, int Assignment_Id, int Type)
        {
            JsonResponse response = new JsonResponse();
            try
            {
                AssignmentsResult users_Assignments_saved = await new AssignmentsProcess().Validate_User(User_Id, Assignment_Id, Type);
                if (users_Assignments_saved.User_Assignment != null)
                {
                    response.Code = 401; return Json(response);
                }
                Users_Assignments users_Assignments = new Users_Assignments()
                {
                    Id = 0,
                    Assigment_Id = Assignment_Id,
                    User_Id = User_Id,
                    Type = Type
                };
                AssignmentsResult result = await new AssignmentsProcess().Add_User(users_Assignments);
                response.Code = 400;
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Code = 401;
            }
            return Json(response);
        }

        public async Task<JsonResult> Get_Comments(int Assignment_Id)
        {
            JsonResponse response = new JsonResponse();
            try
            {
                AssignmentsResult result = await new AssignmentsProcess().Get_Comments(Assignment_Id);
                response.Code = 400;
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Code = 401;
            }
            return Json(response);
        }

        [HttpPost]
        public async Task<IActionResult> Find(IFormCollection collection)
        {
            int.TryParse(collection["OrderNumber"].ToString(), out int Id);
            Assignments assignments = await new AssignmentsDAO().Get_Assignment(Id);
            if (assignments != null)
            {
                return RedirectToAction("Details", new { Guid = assignments.Assignments_Guid });
            }
            return RedirectToAction("Index");
        }

        public async Task<JsonResult> Load_Images(int Assigment_Id)
        {
            JsonResponse response = new JsonResponse();
            try
            {
                FriendsResult result = await new AssignmentsProcess().GetFiles(Userloged.CompanyId, Assigment_Id);
                if (!result.IsValid)
                {
                    response.Message = response.Message;
                    response.Code = 401;
                    return Json(response);
                }
                response.Code = 400;
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Code = 401;
            }
            return Json(response);
        }

        public async Task<JsonResult> Load_Departments()
        {
            JsonResponse response = new JsonResponse();
            try
            {
                AssignmentsResult result = await new AssignmentsProcess().Get_All_Departments(Userloged.CompanyId);
                if (!result.IsValid)
                {
                    response.Message = response.Message;
                    response.Code = 401;
                    return Json(response);
                }
                response.Code = 400;
                response.Result = result.Departments;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Code = 401;
            }
            return Json(response);
        }
    }
}
