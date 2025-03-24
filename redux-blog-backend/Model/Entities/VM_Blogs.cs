/// <summary>
/// وبلاگ
/// </summary>
public class VM_Blogs
{
    /// <summary>
    /// شناسه مقاله
    /// </summary>
    public int BlogID { get; set; }
    /// <summary>
    /// عنوان مقاله
    /// </summary>
    public string? Title { get; set; }
    /// <summary>
    /// توضیحات مقاله
    /// </summary>
    public string? Contents { get; set; }
    /// <summary>
    /// شناسه نویسنده
    /// </summary>
    public int AuthorID { get; set; }
    /// <summary>
    /// تاریخ ثبت مقاله
    /// </summary>
    public DateTime? CreatedDate { get; set; }
    /// <summary>
    /// شناسه واکنش مقاله
    /// </summary>
    public int PostReactionsID { get; set; }
    /// <summary>
    /// تعداد لایک ThumbsUp 
    /// </summary>
    public int ThumbsUp { get; set; }
    /// <summary>
    /// تعداد لایک Hooray 
    /// </summary>
    public int Hooray { get; set; }
    /// <summary>
    /// تعداد لایک Heart
    /// </summary>
    public int Heart { get; set; }
    /// <summary>
    /// تعداد لایک Rocket
    /// </summary>
    public int Rocket { get; set; }
    /// <summary>
    /// تعداد لایک Eyes
    /// </summary>
    public int Eyes { get; set; }
}
/// <summary>
/// درج وبلاگ
/// </summary>
public class VM_Blogs_Insert
{
    /// <summary>
    /// عنوان مقاله
    /// </summary>
    public string? Title { get; set; }
    /// <summary>
    /// توضیحات مقاله
    /// </summary>
    public string? Contents { get; set; }
    /// <summary>
    /// شناسه نویسنده
    /// </summary>
    public int AuthorID { get; set; }
}
/// <summary>
/// ویرایش وبلاگ
/// </summary>
public class VM_Blogs_Update
{
    /// <summary>
    /// شناسه مقاله
    /// </summary>
    public int BlogID { get; set; }
    /// <summary>
    /// عنوان مقاله
    /// </summary>
    public string? Title { get; set; }
    /// <summary>
    /// توضیحات مقاله
    /// </summary>
    public string? Contents { get; set; }
}