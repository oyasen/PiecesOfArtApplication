using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PiecesOfArt_Application_Assignment.Dto;
using PiecesOfArt_Application_Assignment.Models;
using PiecesOfArt_Application_Assignment.Repos;

namespace PiecesOfArt_Application_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorysController : ControllerBase
    {
        private readonly ICategoryRepo _CategoryRepo;
        public CategorysController(ICategoryRepo CategoryRepo) 
        { 
            _CategoryRepo = CategoryRepo;
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Category = _CategoryRepo.Get(id);
            if (Category == null)
            {
                return NotFound();
            }
            return Ok(Category);

        }
        [HttpGet]
        public IActionResult Get()
        {
            var Category = _CategoryRepo.GetAll();
            return Ok(Category);
        }
        [HttpPost]
        public IActionResult Post(Category_Dto Category)
        {
            try
            {
                _CategoryRepo.Add(Category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(Category);
        }
        [HttpPut]
        public IActionResult Put(Category_Dto Category,int id)
        {
            try
            {
                _CategoryRepo.Update(Category, id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(Category);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _CategoryRepo.Delete(id);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
