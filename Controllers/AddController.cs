using db.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace db.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AddController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Add(DTO dto)
        {
            User us = new User
            {
                Name = dto.name,
                Email = dto.email,
            };
            _context.Users.Add(us);
            _context.SaveChanges();
            return Ok();
        }
        [HttpGet]
        public IActionResult Getall() 
        {
            var result = _context.Users.ToList();
            return Ok(result);                    
        }
        [HttpGet ("{name}")]
        public IActionResult Get(String name)
        {
            var result = _context.Users.SingleOrDefault(u => u.Name == name);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            var res=_context.Users.Remove(_context.Users.FirstOrDefault(u => u.Id == id));
            _context.SaveChanges();
            return Ok(res);
        
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, string name)
        {
            var res =_context.Users.SingleOrDefault(i=>i.Id == id);
            res.Name = name;
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult deleteall()
        {
            var res = _context.Users.ToList();
            _context.Users.RemoveRange(res);
            _context.SaveChanges();
            return Ok();
        
        }
    }
}
