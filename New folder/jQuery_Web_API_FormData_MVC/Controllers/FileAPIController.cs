using System;
using System.Collections.Generic;
using System.Linq;

using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace jQuery_Web_API_FormData_MVC.Controllers
{
    public class FileAPIController : ApiController
    {
        [Route("api/FileAPI/UploadFiles")]
        [HttpPost]
        public HttpResponseMessage UploadFiles()
        {
            //Create the Directory.
            string path = HttpContext.Current.Server.MapPath("~/Uploads/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //Fetch the File.
            HttpPostedFile postedFile = HttpContext.Current.Request.Files[0];

            //Fetch the File Name.
            string fileName = HttpContext.Current.Request.Form["fileName"] + Path.GetExtension(postedFile.FileName);

            //Save the File.
            postedFile.SaveAs(path + fileName);

            //Send OK Response to Client.
            return Request.CreateResponse(HttpStatusCode.OK, fileName);
        }
    }
}
