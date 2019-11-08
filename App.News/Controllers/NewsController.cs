using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using App.News.Exceptions;
using App.News.Models;
using App.News.Interfaces;
using App.News.Filters;

namespace App.News.Controllers
{
    [Route("api/news")]
    [ApiController]
    [TypeFilter(typeof(NewsExceptionFilter), Arguments = new object[] { nameof(NewsController) })]
    public class NewsController: ControllerBase
    {
        private readonly ILogger<NewsController> logger;
        private readonly INewsManager newsManager;
        public NewsController(INewsManager newsManager, ILogger<NewsController> logger)
        {
            this.newsManager = newsManager;
            this.logger = logger;
        }

        [Route("comments")]
        [HttpPost]
        public ActionResult AddComment([FromBody]CommentDTO commentDTO)
        {
            logger.LogDebug("AddComment method was called.");
            if (commentDTO.Owner.Length == 0)
                throw new ValidationException("Validation error: comment owner field is empty!");
            else if (commentDTO.Text.Length == 0)
                throw new ValidationException("Validation error: comment text is empty!");
            newsManager.AddComment(commentDTO);
            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<NewsDTO>> GetNews()
        {
            logger.LogDebug("GetNews method was called.");
            var news =  newsManager.GetAllNews().ToList();
            return Ok(news);
        }

        [Route("{id}/comments")]
        [HttpGet]
        public ActionResult<IEnumerable<CommentDTO>> GetNewsComments(int Id)
        {
            logger.LogDebug("GetNewsComments method was called.");
            var comments = newsManager.GetNewsComments(Id).ToList();
            return Ok(comments);
        }
    }
}
