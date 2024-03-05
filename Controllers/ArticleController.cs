using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLiteTest.Data;

namespace SQLiteTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public ArticleController(DataContext context) 
        {
            _dataContext = context;
        }


        [HttpPost]
        public async Task<ActionResult<List<Article>>> AddArticle(Article article)
        {
            _dataContext.Articles.Add(article);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Articles.ToListAsync());
        }

        [HttpGet]
        public async Task<ActionResult<List<Article>>> GetAllArticles()
        {
            return Ok(await _dataContext.Articles.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Article>>> GetAllArticles(int id)
        {
            var article = await _dataContext.Articles.FindAsync(id);
            if (article == null)
            {
                return BadRequest("article not found.");
            }
            return Ok(article);
        }

    }
}
