/// <summary>
/// وبلاگ   
/// </summary>
public interface IBlogs
{
    /// <summary>
    /// حذف وبلاگ
    /// </summary>
    /// <param name="BlogID"></param>
    /// <returns></returns>
    Task<int> BlogsDeleteAsync(int BlogID);
    /// <summary>
    /// یافتن وبلاگ بر اساس شناسه
    /// </summary>
    /// <param name="BlogID"></param>
    /// <returns></returns>
    Task<VM_Blogs> BlogsFindIDAsync(int BlogID);
    /// <summary>
    /// دریافت لیست وبلاگ ها
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<VM_Blogs>> BlogsGetAllAsync();
    /// <summary>
    /// درج وبلاگ
    /// </summary>
    /// <param name="blog"></param>
    /// <returns></returns>
    Task<VM_Blogs> BlogsInsertAsync(VM_Blogs_Insert blog);
    /// <summary>
    /// جستجو وبلاگ بر اساس عنوان
    /// </summary>
    /// <param name="Title"></param>
    /// <returns></returns>
    Task<IEnumerable<VM_Blogs>> BlogsSearchAsync(string Title);
    /// <summary>
    /// ویرایش وبلاگ
    /// </summary>
    /// <param name="blog"></param>
    /// <returns></returns>
    Task<VM_Blogs> BlogsUpdateAsync(VM_Blogs_Update blog);
}