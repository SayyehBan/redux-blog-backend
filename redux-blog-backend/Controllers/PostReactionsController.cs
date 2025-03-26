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
            var result = await rPostReactions.PostReactionsUpdateAsync(postReactions);
            if (result == 0)
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