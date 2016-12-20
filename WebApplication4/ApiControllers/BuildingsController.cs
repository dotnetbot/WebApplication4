using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Models;

namespace WebApplication4.ApiControllers
{
    public class BuildingsController: ApiController
    {
        private readonly ApplicationDbContext _context;

        public BuildingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IHttpActionResult Get() {
            return Ok(_context.Buildings.Select(b => new { b.Id, b.Title }));
        }

    }
}