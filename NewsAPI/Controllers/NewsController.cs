using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsAPI.Data;
using NewsAPI.Model;
using NewsAPI.Repositories;
using NewsAPI.Utilities;

namespace NewsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsRepository _repository;

        public NewsController(INewsRepository repository)
        {
            _repository = repository;
        }

        // GET: api/News
        [HttpGet]
        public ActionResult<IEnumerable<News>> GetNews()
        {
            try
            {
                var news = _repository.GetAll();
                return Ok(news);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }
            
        }

        // GET: api/News/5
        [HttpGet("{id}")]
        public ActionResult<News> GetNews(int id)
        {
            try
            {
                var news = _repository.Get(x => x.Id == id);
                return Ok(news);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        // PUT: api/News/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public ActionResult<News> PutNews([FromQuery] News modifiedNews)
        {
            try
            {
                News news = _repository.Get(x => x.Id == modifiedNews.Id);
                if (news == null)
                {
                    return NotFound();
                }
                news.Title = modifiedNews.Title;
                news.Body = modifiedNews.Body;
                news.ImageUrl = modifiedNews.ImageUrl;
                _repository.Update(news);
                return Ok(news);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST: api/News
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<News> PostNews([FromQuery] News news, IFormFile? file)
        {
            try
            {
                if (file != null && file.ContentType != "image/jpeg" && file.ContentType != "image/jpg" &&
                    file.ContentType != "image/png")
                {
                    return BadRequest();
                }
                var newNews = _repository.Add(news, file);
                if (newNews != null) 
                {
                    return CreatedAtAction("GetNews", new { id = news.Id }, news);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return StatusCode(500, "Error creating news");
        }

        // DELETE: api/News/5
        [HttpDelete("{id}")]
        public IActionResult DeleteNews(int id)
        {
            try
            {
                News news = _repository.Get(x => x.Id == id);
                if (news == null)
                {
                    return NotFound();
                }
                _repository.Delete(news);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
