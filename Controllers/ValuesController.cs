using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetAngularAuth.Models;
using Microsoft.EntityFrameworkCore;
namespace AspNetAngularAuth.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase {
        public BookStoreContext _context { get; }
        public ValuesController (BookStoreContext context) {
            _context = context;

        }
        // GET api/values
        [HttpGet]
        public ActionResult Get () {
            var result = _context.Tbluser.ToList();
            return Ok(result);
        }

        // GET api/values/5
        [HttpGet ("{id}")]
        public IActionResult Get (int id) {
            
          var user =  _context.GetUsersByproc();
             return Ok(user);
        }

        // POST api/values
        [HttpPost]
        public void Post ([FromBody] string value) { }

        // PUT api/values/5
        [HttpPut ("{id}")]
        public void Put (int id, [FromBody] string value) { }

        // DELETE api/values/5
        [HttpDelete ("{id}")]
        public void Delete (int id) { }
    }
}