using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using App.News.Models;
using App.News.Interfaces;
using App.News.Filters;

namespace App.News.Controllers
{
    [Route("api/news")]
    [ApiController]
   // [TypeFilter(typeof(NewsExceptionFilter), Arguments = new object[] { nameof(NewsController) })]
    public class NewsController: ControllerBase
    {
        private INewsManager newsManager;
        public NewsController(INewsManager newsManager)
        {
            this.newsManager = newsManager;
        }

        [Route("comments")]
        [HttpPost]
        public ActionResult AddComment([FromBody]CommentDTO commentDTO)
        {
            newsManager.AddComment(commentDTO);
            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<NewsDTO>> GetNews() {
            var news =  newsManager.GetAllNews().ToList();
            return Ok(news);
        }

        [Route("{id}/comments")]
        [HttpGet]
        public ActionResult<IEnumerable<CommentDTO>> GetNewsComments(int Id)
        {
            var comments = newsManager.GetNewsComments(Id).ToList();
            return Ok(comments);
        }
    }
}
