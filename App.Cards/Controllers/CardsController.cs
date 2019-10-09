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
            return null;
        }

        [HttpPut("{id}/limit/set")]
        public ActionResult SetCardLimit(int id, [FromQuery]decimal limit)
        {
            return null;
        }

        [HttpPut("{id}/limit/unset")]
        public ActionResult UnsetCardLimit(int id)
        {
            return null;
        }


        [HttpPut("{id}/block")]
        public ActionResult BlockCardById(int id, [FromQuery]decimal limit)
        {
            return null;
        }

    }
}
