﻿using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await rAuthors.AuthorsGetAllAsync();
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
        /// نمایش یک نویسنده
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> SearchAsync([FromQuery] VM_Authors_Insert_Search search)
        {
            try
            {
                if (search == null)
                {
                    return BadRequest("اطلاعات جستجو نامعتبر است."); // Changed from NotFound to BadRequest
                }
                var result = await rAuthors.AuthorsSearchAsync(search);
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
        /// اضافه کردن نویسنده
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromForm] VM_Authors_Insert_Search author)
        {
            try
            {
                if (author == null)
                {
                    return BadRequest("اطلاعات نویسنده نامعتبر است."); // Changed from NotFound to BadRequest
                }
                var result = await rAuthors.AuthorsInsertAsync(author);
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
        /// ویرایش نویسنده
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromForm] VM_Authors_Update author)
        {
            try
            {
                if (author == null)
                {
                    return BadRequest("اطلاعات نویسنده نامعتبر است."); // Changed from NotFound to BadRequest
                }
                var result = await rAuthors.AuthorsUpdateAsync(author);
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
        /// حذف نویسنده
        /// </summary>
        /// <param name="AuthorID"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromQuery] int AuthorID)
        {
            try
            {
                if (AuthorID == 0)
                {
                    return BadRequest("شناسه نویسنده نامعتبر است."); // Changed from NotFound to BadRequest
                }
                var result = await rAuthors.AuthorsDeleteAsync(AuthorID);
                if (result == 1)
                {
                    return Ok(result); // Return 200 OK with success message
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
    }
}
