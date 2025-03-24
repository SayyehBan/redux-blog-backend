/// <summary>
/// نویسنده
/// </summary>
public interface IAuthors
{
    /// <summary>
    /// دریافت لیست نویسنده ها
    /// </summary>
    Task<IEnumerable<VM_Authors>> AuthorsGetAllAsync();
    /// <summary>
    /// جستجو بر اساس نام و نام خانوادگی نویسنده
    /// </summary>
    /// <param name="author"></param>
    /// <returns></returns>
    Task<IEnumerable<VM_Authors>> AuthorsSearchAsync(VM_Authors_Insert_Search author);
    /// <summary>
    /// ذخیره نویسنده جدید در دیتابیس
    /// </summary>
    /// <param name="author"></param>
    /// <returns></returns>
    Task<VM_Authors> AuthorsInsertAsync(VM_Authors_Insert_Search author);
    /// <summary>
    /// ویرایش نویسنده
    /// </summary>
    /// <param name="author"></param>
    /// <returns></returns>
    Task<VM_Authors> AuthorsUpdateAsync(VM_Authors_Update author);
    /// <summary>
    /// حذف نویسنده
    /// </summary>
    /// <param name="AuthorID"></param>
    /// <returns></returns>
    Task<int> AuthorsDeleteAsync(int AuthorID);
}