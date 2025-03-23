/// <summary>
/// کلاس خطا یافت نشد
/// </summary>
public class NotFoundException : Exception
{
    /// <summary>
    /// سازنده کلاس خطا یافت نشد
    /// </summary>
    /// <param name="message"></param>
    public NotFoundException(string message) : base(message)
    {
    }
}