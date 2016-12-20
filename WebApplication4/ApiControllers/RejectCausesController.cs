using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Models;

namespace WebApplication4.ApiControllers
{
    public class RejectCausesController: ApiController
    {
        private readonly ApplicationDbContext _context;

        public RejectCausesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IHttpActionResult Get()
        {
            return Ok(_context.RejectCauses.Select(b => new { b.Id, b.Text }));
        }
    }
}