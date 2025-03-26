using Dapper;
using Microsoft.Data.SqlClient;
using redux_blog_backend.Infrastructure.Contexts;

/// <summary>
/// ریپازیتوری لایک مقاله
/// </summary>
public class RPostReactions : IPostReactions
{
    /// <summary>
    /// دریافت واکنش مقاله بر اساس شناسه
    /// </summary>
    /// <param name="postReactions"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<int> PostReactionsUpdateAsync(VM_PostReactions postReactions)
    {
        using (var connection = new SqlConnection(SqlServer.ConnectionString()))
        {
            var sql = "dbo.PostReactionsUpdate";
            var parameters = new
            {
                PostReactionsID = postReactions.PostReactionsID,
                ThumbsUp = postReactions.ThumbsUp,
                Hooray = postReactions.Hooray,
                Heart = postReactions.Heart,
                Rocket = postReactions.Rocket,
                Eyes = postReactions.Eyes
            };
            var result = await connection.QuerySingleAsync<int>(sql, parameters, commandType: System.Data.CommandType.StoredProcedure);
            return result;

        }
    }
}