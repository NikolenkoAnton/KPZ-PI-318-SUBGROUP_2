using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using App.News.Models;
using App.News.Interfaces;

namespace App.News.Controllers
{
    [Route("api/news")]
    [ApiController]
    public class NewsController: ControllerBase
    {
        private INewsManager newsManager;
        public NewsController(INewsManager newsManager)
        {
            this.newsManager = newsManager;
        }

        [Route("api/news/addComment/")]
        [HttpPost]
        public ActionResult AddComment([FromBody]CommentDTO commentDTO)
        {
            var actionResult = newsManager.AddComment(commentDTO);
            if (actionResult != "ok")
            {
                return BadRequest("Something went wrong");
            }
            return Ok();
        }

        [Route("api/news/allNews")]
        [HttpGet]
        public ActionResult<IEnumerable<NewsDTO>> GetNews() {
            var news =  newsManager.GetAllNews().ToList();
            return Ok(news);
        }

        [Route("api/news/{id}/newsComments/")]
        [HttpGet]
        public ActionResult<IEnumerable<CommentDTO>> GetNewsComments(int Id)
        {
            var comments = newsManager.GetNewsComments(Id).ToList();
            return Ok(comments);
        }
    }
}
