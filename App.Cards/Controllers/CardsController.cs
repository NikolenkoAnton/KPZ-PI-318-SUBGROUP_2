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

        // GET api/example/values
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
        public ActionResult SetCardLimit(int id, [FromQuery]decimal limit)
        {
            var actionStatus = cardsManager.SetCardLimit(id, limit);

            if(actionStatus != "Successfull")
            {
                return BadRequest(actionStatus);
            }

            return Ok(actionStatus);
        }

        [HttpPut("{id}/limit/unset")]
        public ActionResult UnsetCardLimit(int id)
        {
            var actionStatus = cardsManager.UnsetCardLimit(id);

            if (actionStatus != "Successfull")
            {
                return BadRequest(actionStatus);
            }

            return Ok(actionStatus);
        }


        [HttpPut("{id}/block")]
        public ActionResult BlockCardById(int id)
        {
            var actionStatus = cardsManager.BlockCard(id);

            if (actionStatus != "Successfull")
            {
                return BadRequest(actionStatus);
            }

            return Ok(actionStatus);
        }

    }
}
