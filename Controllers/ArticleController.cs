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

        [HttpGet]
        public async Task<ActionResult<List<Article>>> GetAllArticles()
        {
            return Ok(await _dataContext.Articles.ToListAsync());
        }
    }
}
