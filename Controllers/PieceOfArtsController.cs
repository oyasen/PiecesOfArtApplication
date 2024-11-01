using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PiecesOfArt_Application_Assignment.Dto;
using PiecesOfArt_Application_Assignment.Models;
using PiecesOfArt_Application_Assignment.Repos;

namespace PiecesOfArt_Application_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PieceOfArtsController : ControllerBase
    {
        private readonly IPieceOfArtRepo _PieceOfArtRepo;
        public PieceOfArtsController(IPieceOfArtRepo PieceOfArtRepo) 
        { 
            _PieceOfArtRepo = PieceOfArtRepo;
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var PieceOfArt = _PieceOfArtRepo.Get(id);
            if (PieceOfArt == null)
            {
                return NotFound();
            }
            return Ok(PieceOfArt);

        }
        [HttpGet]
        public IActionResult Get()
        {
            var PieceOfArt = _PieceOfArtRepo.GetAll();
            return Ok(PieceOfArt);
        }
        [HttpPost]
        public IActionResult Post(PieceOfArt_Dto PieceOfArt)
        {
            try
            {
                _PieceOfArtRepo.Add(PieceOfArt);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(PieceOfArt);
        }
        [HttpPut]
        public IActionResult Put(PieceOfArt_Dto PieceOfArt,int id)
        {
            try
            {
                _PieceOfArtRepo.Update(PieceOfArt, id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(PieceOfArt);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _PieceOfArtRepo.Delete(id);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
