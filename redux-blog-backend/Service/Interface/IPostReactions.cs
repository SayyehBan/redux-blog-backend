/// <summary>
/// اینترفیس ایجاد لایک برای وبلاگ
/// </summary>
public interface IPostReactions
{
    /// <summary>
    /// دریافت واکنش مقاله بر اساس شناسه
    /// </summary>
    /// <param name="postReactions"></param>
    /// <returns></returns>
    Task<int> PostReactionsUpdateAsync(VM_PostReactions postReactions);
}