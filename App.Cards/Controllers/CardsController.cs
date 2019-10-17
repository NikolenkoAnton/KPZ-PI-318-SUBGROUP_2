using App.Cards.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Cards.Controllers
{
    [Route("api/cards")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        readonly ICardsManager cardsManager;
        public ValuesController(
          ICardsManager cardsManager)
        {
            this.cardsManager = cardsManager;
        }

        [HttpGet("{id}")]
        public ActionResult<Card> GetCardById(int id)
        {
            var card = cardsManager.GetCardById(id);
            
            if(card == null)
            {
                return BadRequest("Card doesn't exist!");
            }

            return card;
        }

        [HttpPut("{id}/limit/set")]
        public ActionResult SetCardLimit(int id, [FromBody]decimal limit)
        {
            cardsManager.SetCardLimit(id, limit);

            return Ok();
        }

        [HttpPut("{id}/limit/unset")]
        public ActionResult UnsetCardLimit(int id)
        {
            cardsManager.UnsetCardLimit(id);

            return Ok();
        }


        [HttpPut("{id}/block")]
        public ActionResult BlockCardById(int id)
        {
            cardsManager.BlockCard(id);

            return Ok();
        }

    }
}
