using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PiecesOfArt_Application_Assignment.Dto;
using PiecesOfArt_Application_Assignment.Models;
using PiecesOfArt_Application_Assignment.Repos;

namespace PiecesOfArt_Application_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoyaltyCardsController : ControllerBase
    {
        private readonly ILoyaltyCardRepo _LoyaltyCardRepo;
        public LoyaltyCardsController(ILoyaltyCardRepo LoyaltyCardRepo) 
        { 
            _LoyaltyCardRepo = LoyaltyCardRepo;
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var LoyaltyCard = _LoyaltyCardRepo.Get(id);
            if (LoyaltyCard == null)
            {
                return NotFound();
            }
            return Ok(LoyaltyCard);

        }
        [HttpGet]
        public IActionResult Get()
        {
            var LoyaltyCard = _LoyaltyCardRepo.GetAll();
            return Ok(LoyaltyCard);
        }
        [HttpPost]
        public IActionResult Post(LoyaltyCard_Dto LoyaltyCard)
        {
            try
            {
                _LoyaltyCardRepo.Add(LoyaltyCard);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(LoyaltyCard);
        }
        [HttpPut]
        public IActionResult Put(LoyaltyCard_Dto LoyaltyCard,int id)
        {
            try
            {
                _LoyaltyCardRepo.Update(LoyaltyCard, id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(LoyaltyCard);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _LoyaltyCardRepo.Delete(id);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
