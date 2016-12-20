using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Models;
using WebApplication4.Providers;
using WebApplication4.Web.Infrastructure;

namespace WebApplication4.Web.ApiControllers
{
    public class ScansController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public ScansController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("api/scans/load/{claimId}")]
        public async Task<IHttpActionResult> LoadAsync(Guid claimId)
        {
            var serverUploadFolder = string.Format("{0}{1}\\", FileStorageProvider.GetCommonPathToScans(), claimId);
            if (!Directory.Exists(serverUploadFolder))
                Directory.CreateDirectory(serverUploadFolder);
            var streamProvider = new CustomMultipartFormDataStreamProvider(serverUploadFolder);

            await Request.Content.ReadAsMultipartAsync(streamProvider);

            var scan = new Scan() { Id = streamProvider.ScanId, ClaimId = claimId };
            scan.CreateDate = DateTime.Now;
            scan.OriginalName = streamProvider.FileData.First().Headers.ContentDisposition.FileName.Trim('"');

            _context.Scans.Add(scan);
            _context.SaveChanges();

            return Ok(scan.Id);
        }
    }
}