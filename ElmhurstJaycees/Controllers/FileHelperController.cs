using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace ElmhurstJaycees.Controllers
{
    public class FileHelperController : Controller
    {
        Models.ElmhurstJayceesEntities _db;
        public FileHelperController()
        {
            _db = new ElmhurstJaycees.Models.ElmhurstJayceesEntities();
        }

        public FileResult RenderFile(Int32 fileID)
        {
            Models.File file = _db.Files.Where<Models.File>(f => f.FileID == fileID).Single();
            if (User.Identity.IsAuthenticated || file.Public)
                return File(file.FileData, ContentType(file.Extension), file.FileName);
            else
                return null;
        }

        String ContentType(String FileExtension)
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            //'Images'
            d.Add(".bmp", "image/bmp");
            d.Add(".gif", "image/gif");
            d.Add(".jpeg", "image/jpeg");
            d.Add(".jpg", "image/jpeg");
            d.Add(".png", "image/png");
            d.Add(".tif", "image/tiff");
            d.Add(".tiff", "image/tiff");
            //'Documents'
            d.Add(".doc", "application/msword");
            d.Add(".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
            d.Add(".pdf", "application/pdf");
            //'Slideshows'
            d.Add(".ppt", "application/vnd.ms-powerpoint");
            d.Add(".pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation");
            //'Data'
            d.Add(".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            d.Add(".xls", "application/vnd.ms-excel");
            d.Add(".csv", "text/csv");
            d.Add(".xml", "text/xml");
            d.Add(".txt", "text/plain");
            // 'Compressed Folders'
            d.Add(".zip", "application/zip");
            //'Audio'
            d.Add(".ogg", "application/ogg");
            d.Add(".mp3", "audio/mpeg");
            d.Add(".wma", "audio/x-ms-wma");
            d.Add(".wav", "audio/x-wav");
            //'Video'
            d.Add(".wmv", "audio/x-ms-wmv");
            d.Add(".swf", "application/x-shockwave-flash");
            d.Add(".avi", "video/avi");
            d.Add(".mp4", "video/mp4");
            d.Add(".mpeg", "video/mpeg");
            d.Add(".mpg", "video/mpeg");
            d.Add(".qt", "video/quicktime");
            return d[FileExtension.TrimEnd()];
        }

    }
}
