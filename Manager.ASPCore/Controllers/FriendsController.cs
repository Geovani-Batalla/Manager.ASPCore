using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.ASPCore;
using Microsoft.AspNetCore.Mvc;
using Business.ASPCore.Friends;
using Microsoft.AspNetCore.Http;

namespace Manager.ASPCore.Controllers
{
    public class FriendsController : BaseController
    {
        public IActionResult Index()
        {
            FriendsResult result = new FriendsProcess().GetFriends(Userloged.Id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormCollection collection)
        {
            string FullName = collection["FullName"].ToString();
            string Email = collection["Email"].ToString();
            string Phone_1 = collection["Phone_1"].ToString();
            string Phone_2 = collection["Phone_2"].ToString();

            FriendsResult result = await new FriendsProcess().Add(FullName, Phone_1, Phone_2, Email, Userloged.Id, Userloged.Name, 12);
            if (!result.IsValid)
            {
                TempData["Message"] = result.Message;
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> GetFiles()
        {
            JsonResponse response = new JsonResponse();
            try
            {
                FriendsResult result = await new FriendsProcess().GetFiles(Userloged.Id);
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

        [HttpGet]
        public async virtual Task<ActionResult> Download(string file)
        {
            FriendsResult result = await new FriendsProcess().DownloadFile(file);
            return File(result.Image, System.Net.Mime.MediaTypeNames.Application.Octet, result.Image_Name);            
        }
    }
}
