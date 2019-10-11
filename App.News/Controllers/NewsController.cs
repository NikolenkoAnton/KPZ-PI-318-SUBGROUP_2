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
    public class NewsController:Controller
    {
        INewsManager newsManager;

        public NewsController(INewsManager newsManager)
        {
            this.newsManager = newsManager;
        }
        [HttpPost]
        public ActionResult AddComment([FromBody]CommentDTO commentDTO)
        {
            var actionResult = newsManager.AddComment(commentDTO);
            if (actionResult != "ok")
            {
                return new BadRequestResult();
            }
            return new OkResult();
        }
        [Route("api/news/allNews")]
        [HttpGet]
        public ActionResult<IEnumerable<NewsDTO>> GetNews() {
            var news =  newsManager.GetAllNews().ToList();
            return new OkObjectResult(news);
        }
        [Route("api/news/{id}/newsComments/")]
        [HttpGet]
        public ActionResult<IEnumerable<CommentDTO>> GetNewsComments(int newsId)
        {
            var comments = newsManager.GetNewsComments(newsId).ToList();
            return new OkObjectResult(comments);
        }


    }
}
