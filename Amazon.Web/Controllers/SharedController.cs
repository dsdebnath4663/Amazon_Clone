using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amazon.Web.Controllers
{
    public class SharedController : Controller
    {
        public JsonResult UploadImage()
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            try
            {
                var file = Request.Files[0];
                var fileName =Guid.NewGuid() + Path.GetExtension(file.FileName);

                var path = Path.Combine(Server.MapPath("~/Content/images/uploaded/"), fileName);
                file.SaveAs(path);
                result.Data = new { Sucess = true, ImageUrl = string.Format("/Content/images/uploaded/{0}", fileName) };

            }
            catch (Exception ex)
            {
                result.Data = new { Sucess = false, Message = ex.Message };
            }

            return result;
        }
    }
}