using Microsoft.AspNetCore.Mvc;
namespace redux_blog_backend.Controllers
{
    /// <summary>
    /// کنترلر وبلاگ
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        /// <summary>
        /// سرویس وبلاگ
        /// </summary>
        private readonly RBlogs rBlogs;
        /// <summary>
        /// سازنده کنترلر وبلاگ
        /// </summary>
        /// <param name="rBlogs"></param>
        public BlogsController(RBlogs rBlogs)
        {
            this.rBlogs = rBlogs;
        }
        /// <summary>
        /// نمایش لیست وبلاگ ها
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await rBlogs.BlogsGetAllAsync();
                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    return new JsonResult(result);
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "خطایی رخ داده است.");
            }
        }
        /// <summary>
        /// نمایش یک وبلاگ بر اساس شناسه
        /// </summary>
        /// <param name="BlogID"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> FindIDAsync(int BlogID)
        {
            try
            {
                var result = await rBlogs.BlogsFindIDAsync(BlogID);
                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    return new JsonResult(result);
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "خطایی رخ داده است.");
            }
        }
        /// <summary>
        /// حذف وبلاگ بر اساس شناسه
        /// </summary>
        /// <param name="BlogID"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromQuery] int BlogID)
        {
            try
            {
                if (BlogID == 0)
                {
                    return BadRequest("شناسه وبلاگ نامعتبر است.");
                }
                var result = await rBlogs.BlogsDeleteAsync(BlogID);
                if (result == 1)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500, "خطایی رخ داده است.");
            }
        }
        /// <summary>
        /// ذخیره وبلاگ جدید
        /// </summary>
        /// <param name="insert"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromForm] VM_Blogs_Insert insert)
        {
            try
            {
                if (insert == null)
                {
                    return BadRequest("اطلاعات ورودی نامعتبر است.");
                }
                var result = await rBlogs.BlogsInsertAsync(insert);
                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    return new JsonResult(result);
                }
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500, "خطایی رخ داده است.");
            }
        }
        /// <summary>
        /// جستجو وبلاگ بر اساس عنوان
        /// </summary>
        /// <param name="Title"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> SearchAsync([FromQuery] string Title)
        {
            try
            {
                if (string.IsNullOrEmpty(Title))
                {
                    return BadRequest("عنوان وبلاگ نامعتبر است.");
                }
                var result = await rBlogs.BlogsSearchAsync(Title);
                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    return new JsonResult(result);
                }
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500, "خطایی رخ داده است.");
            }
        }
        /// <summary>
        /// ویرایش وبلاگ
        /// </summary>
        /// <param name="update"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromForm] VM_Blogs_Update update)
        {
            try
            {
                if (update == null)
                {
                    return BadRequest("اطلاعات ورودی نامعتبر است.");
                }
                var result = await rBlogs.BlogsUpdateAsync(update);
                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    return new JsonResult(result);
                }
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500, "خطایی رخ داده است.");
            }
        }
    }
}