using System.Net.Mime;
using generate_card.Entity;
using generate_card.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace generate_card.Controllers
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("/api/v1/[controller]")]
    public class CardController
    {
        private CardService _service;

        public CardController(CardService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public User CreatedCard(string email)
        {
            return _service.CreateCard(email);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
        
    }
}