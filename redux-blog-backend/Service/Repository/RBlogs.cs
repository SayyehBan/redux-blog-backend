using Dapper;
using Microsoft.Data.SqlClient;
using redux_blog_backend.Infrastructure.Contexts;

/// <summary>
/// repository وبلاگ
/// </summary>
public class RBlogs : IBlogs
{
    /// <summary>
    /// حذف وبلاگ
    /// </summary>
    /// <param name="BlogID"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<int> BlogsDeleteAsync(int BlogID)
    {
        using (var connection = new SqlConnection(SqlServer.ConnectionString()))
        {
            var sql = "dbo.BlogsDelete";
            var parameters = new
            {
                BlogID = BlogID
            };
            var result = await connection.QuerySingleAsync<int>(sql, parameters, commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }
    }
    /// <summary>
    /// یافتن وبلاگ بر اساس شناسه
    /// </summary>
    /// <param name="BlogID"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<VM_Blogs> BlogsFindIDAsync(int BlogID)
    {
        using (var connection = new SqlConnection(SqlServer.ConnectionString()))
        {
            var sql = "dbo.BlogsFindID";
            var parameters = new
            {
                BlogID = BlogID
            };
            var result = await connection.QuerySingleAsync<VM_Blogs>(sql, parameters, commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }
    }
    /// <summary>
    /// دریافت لیست وبلاگ ها
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<IEnumerable<VM_Blogs>> BlogsGetAllAsync()
    {
        using (var connection = new SqlConnection(SqlServer.ConnectionString()))
        {
            var sql = "dbo.BlogsGetAll";
            var result = await connection.QueryAsync<VM_Blogs>(sql, commandType: System.Data.CommandType.StoredProcedure);
            return result.ToList();
        }
    }
    /// <summary>
    /// درج وبلاگ
    /// </summary>
    /// <param name="blog"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<VM_Blogs> BlogsInsertAsync(VM_Blogs_Insert blog)
    {
        using (var connection = new SqlConnection(SqlServer.ConnectionString()))
        {
            var sql = "dbo.BlogsInsert";
            var parameters = new
            {
                Title =
                blog.Title,
                Contents =
                blog.Contents,
                AuthorID =
                blog.AuthorID
            };
            var result = await connection.QuerySingleAsync<VM_Blogs>(sql, parameters, commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }

    }
    /// <summary>
    /// جستجو وبلاگ بر اساس عنوان
    /// </summary>
    /// <param name="Title"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<IEnumerable<VM_Blogs>> BlogsSearchAsync(string Title)
    {
        using (var connection = new SqlConnection(SqlServer.ConnectionString()))
        {
            var sql = "dbo.BlogsSearch";
            var parameters = new
            {
                Title = Title
            };
            var result = await connection.QueryAsync<VM_Blogs>(sql, parameters, commandType: System.Data.CommandType.StoredProcedure);
            return result.ToList();
        }
    }
    /// <summary>
    /// ویرایش وبلاگ
    /// </summary>
    /// <param name="blog"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<VM_Blogs> BlogsUpdateAsync(VM_Blogs_Update blog)
    {
        using (var connection = new SqlConnection(SqlServer.ConnectionString()))
        {
            var sql = "dbo.BlogsUpdate";
            var parameters = new
            {
                BlogID = blog.BlogID,
                Title = blog.Title,
                Contents = blog.Contents,
            };
            var result = await connection.QuerySingleAsync<VM_Blogs>(sql, parameters, commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }
    }
}