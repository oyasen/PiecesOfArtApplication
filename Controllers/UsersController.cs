using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PiecesOfArt_Application_Assignment.Dto;
using PiecesOfArt_Application_Assignment.Models;
using PiecesOfArt_Application_Assignment.Repos;

namespace PiecesOfArt_Application_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo _userRepo;
        public UsersController(IUserRepo userRepo) 
        { 
            _userRepo = userRepo;
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _userRepo.Get(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);

        }
        [HttpGet]
        public IActionResult Get()
        {
            var user = _userRepo.GetAll();
            return Ok(user);
        }
        [HttpPost]
        public IActionResult Post(User_Dto user)
        {
            try
            {
                _userRepo.Add(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(user);
        }
        [HttpPut]
        public IActionResult Put(User_Dto user,int id)
        {
            try
            {
                _userRepo.Update(user, id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(user);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _userRepo.Delete(id);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
