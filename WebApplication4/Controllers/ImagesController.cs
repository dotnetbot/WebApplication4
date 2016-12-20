using System;
using System.Configuration;
using System.Web.Mvc;
using Models;
using WebApplication4.Helpers;
using WebApplication4.Providers;
using System.IO;

namespace AIS.Proxy.Web.Controllers
{
    public class ImagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ImagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Get(Guid id)
        {
            var scan = _context.Scans.Find(id);
            if (scan == null)
            {
                return HttpNotFound();
            }

            var path = Path.Combine(FileStorageProvider.GetCommonPathToScans(), scan.ClaimId.ToString(), scan.LocalFileName);
            Response.AppendHeader("Content-Disposition", "inline; filename=" + scan.OriginalName);
            return File(path, MimeHelper.GetContentType(scan.ExtensionWithDot));
        }

        public ActionResult Preview(Guid id)
        {
            var registriesPath = ConfigurationManager.AppSettings["RegistriesDirectory"];
            var previewsPath = ConfigurationManager.AppSettings["PreviewsDirectory"];

            var scan = _context.Scans.Find(id);
            if (scan == null)
            {
                return HttpNotFound();
            }

            Response.AppendHeader("Content-Disposition", "inline; filename=" + scan.OriginalName);
            return File(GetScanPreviewFilePath(scan),
                        MimeHelper.GetContentType(scan.ExtensionWithDot));
        }

        #region helper methods
        private string GetScanPreviewFilePath(Scan scan)
        {
            if (!scan.ExtensionWithDot.Equals(".jpg", StringComparison.OrdinalIgnoreCase))
            {
                return string.Empty;
            }

            var previewsStoragePath = string.Format("{0}{1}", FileStorageProvider.GetCommonPathToScans(), "previews");
            if (!Directory.Exists(previewsStoragePath))
            {
                Directory.CreateDirectory(previewsStoragePath);
            }

            var previewPath = Path.Combine(previewsStoragePath, scan.LocalFileName);
            if (!System.IO.File.Exists(previewPath))
            {
                
                var fileByteStream = new FileStream(Path.Combine(FileStorageProvider.GetCommonPathToScans(), scan.ClaimId.ToString(), scan.LocalFileName), 
                    FileMode.Open, 
                    FileAccess.Read);
                var imagesHelper = new ImagesHelper();
                imagesHelper.GetFilePreview(fileByteStream, previewPath);
            }
            return previewPath;
        }
        #endregion
    }
}