/// <summary>
/// نویسنده
/// </summary>
public class VM_Authors
{
    /// <summary>
    /// شناسه نویسنده
    /// </summary>
    public int AuthorID { get; set; }
    /// <summary>
    /// نام نویسنده
    /// </summary>
    public string? FirstName { get; set; }
    /// <summary>
    /// نام خانوادگی نویسنده
    /// </summary>
    public string? LastName { get; set; }
    /// <summary>
    /// تاریخ ثبت نویسنده
    /// </summary>
    public DateTime? CreatedDate { get; set; }
}
/// <summary>
/// جستجو و ثبت نویسنده
/// </summary>
public class VM_Authors_Insert_Search
{
    /// <summary>
    /// نام نویسنده
    /// </summary>
    public string? FirstName { get; set; }
    /// <summary>
    /// نام خانوادگی نویسنده
    /// </summary>
    public string? LastName { get; set; }
}
/// <summary>
/// ویرایش نویسنده
/// </summary>
public class VM_Authors_Update
{
    /// <summary>
    /// شناسه نویسنده
    /// </summary>
    public int AuthorID { get; set; }
    /// <summary>
    /// نام نویسنده
    /// </summary>
    public string? FirstName { get; set; }
    /// <summary>
    /// نام خانوادگی نویسنده
    /// </summary>
    public string? LastName { get; set; }
}