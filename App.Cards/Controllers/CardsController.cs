using App.Cards.Models;
using App.Example.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Cards.Controllers
{
    [Route("api/cards")]
    [ApiController]
    [TypeFilter(typeof(CardsExceptionFilter), Arguments = new object[] { nameof(CardsController) })]

    public class CardsController : ControllerBase
    {
        readonly ICardsManager cardsManager;
        readonly ILogger<CardsController> logger;
        public CardsController(
          ICardsManager cardsManager,
          ILogger<CardsController> logger)
        {
            this.cardsManager = cardsManager;
            this.logger = logger;
        }

        [HttpGet("{id}")]
        public ActionResult<Card> GetCardById(int id)
        {
            logger.LogDebug("call GetCardByID method");

            var card = cardsManager.GetCardById(id);

            if (card == null)
            {
                return BadRequest("Card doesn't exist!");
            }

            return card;
        }

        [HttpPut("{id}/limit/set")]
        public ActionResult SetCardLimit(int id, decimal limit)
        {
            logger.LogDebug("call SetCardLimit method");

            cardsManager.SetCardLimit(id, limit);

            return Ok();
        }

        [HttpPut("{id}/limit/unset")]
        public ActionResult UnsetCardLimit(int id)
        {
            logger.LogDebug("call UnsetCardLimit method");

            cardsManager.UnsetCardLimit(id);

            return Ok();
        }


        [HttpPut("{id}/block")]
        public ActionResult BlockCardById(int id)
        {
            logger.LogDebug("call BlockCardById method");

            cardsManager.BlockCard(id);

            return Ok();
        }

    }
}
