using Microsoft.AspNetCore.Mvc;

namespace redux_blog_backend.Controllers
{
    /// <summary>
    /// کنترلر نویسنده
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        /// <summary>
        /// سرویس نویسنده
        /// </summary>
        private readonly RAuthors rAuthors;
        /// <summary>
        /// سازنده کنترلر نویسنده
        /// </summary>
        /// <param name="rAuthors"></param>
        public AuthorsController(RAuthors rAuthors)
        {
            this.rAuthors = rAuthors;
        }
        /// <summary>
        /// نمایش لیست نویسنده ها
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            var result = await rAuthors.GetAllAuthorsAsync();
            return new JsonResult(result);


        }
    }
}
