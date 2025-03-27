using Microsoft.AspNetCore.Mvc;
/// <summary>
/// کنترلر لایک مقاله
/// </summary>
[Route("api/[controller]/[action]")]
[ApiController]
public class PostReactionsController : ControllerBase
{
    private readonly RPostReactions rPostReactions;
    /// <summary>
    /// سازنده کنترلر لایک مقاله
    /// </summary>
    /// <param name="rPostReactions"></param>
    public PostReactionsController(RPostReactions rPostReactions)
    {
        this.rPostReactions = rPostReactions;
    }
    /// <summary>
    /// دریافت واکنش مقاله بر اساس شناسه
    /// </summary>
    /// <param name="postReactions"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromForm] VM_PostReactions postReactions)
    {
        try
        {
            if (postReactions.BlogID == 0)
            {
                return BadRequest("شناسه مقاله نامعتبر است.");
            }
            var result = await rPostReactions.PostReactionsUpdateAsync(postReactions);
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