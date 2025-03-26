/// <summary>
/// واکنش مقاله
/// </summary>
public class VM_PostReactions
{
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