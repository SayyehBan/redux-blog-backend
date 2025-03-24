using Microsoft.Data.SqlClient;
using Dapper;
using redux_blog_backend.Infrastructure.Contexts;
using SayyehBanTools.Converter;

/// <summary>
/// نویسنده
/// </summary>
public class RAuthors : IAuthors
{
    /// <summary>
    /// حذف نویسنده
    /// </summary>
    /// <param name="AuthorID"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<int> AuthorsDeleteAsync(int AuthorID)
    {
        using (var connection = new SqlConnection(SqlServer.ConnectionString()))
        {
            var sql = "dbo.AuthorsDelete";
            var parameters = new
            {
                AuthorID = AuthorID
            };
            var result = await connection.QuerySingleAsync<int>(sql, parameters, commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }
    }
    /// <summary>
    /// نمایش لیست نویسنده ها
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<IEnumerable<VM_Authors>> AuthorsGetAllAsync()
    {
        using (var connection = new SqlConnection(SqlServer.ConnectionString()))
        {
            var sql = "dbo.AuthorsGetAll";
            var result = await connection.QueryAsync<VM_Authors>(sql, commandType: System.Data.CommandType.StoredProcedure);
            return result.ToList();
        }

    }
    /// <summary>
    /// ثبت نویسنده جدید در دیتابیس
    /// </summary>
    /// <param name="author"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<VM_Authors> AuthorsInsertAsync(VM_Authors_Insert_Search author)
    {
        using (var connection = new SqlConnection(SqlServer.ConnectionString()))
        {
            var sql = "dbo.AuthorsInsert";
            await connection.OpenAsync();
            var parameters = new
            {
                FirstName = StringExtensions.CleanString(author.FirstName ?? ""),
                LastName = StringExtensions.CleanString(author.LastName ?? ""),
            };
            var result = await connection.QuerySingleAsync<VM_Authors>(sql, parameters, commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }
    }
    /// <summary>
    /// جستجو بر اساس نام و نام خانوادگی نویسنده
    /// </summary>
    /// <param name="author"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<IEnumerable<VM_Authors>> AuthorsSearchAsync(VM_Authors_Insert_Search author)
    {
        using (var connection = new SqlConnection(SqlServer.ConnectionString()))
        {
            var sql = "dbo.AuthorsSearch";
            var parameters = new
            {
                FirstName = StringExtensions.CleanString(author.FirstName ?? ""),
                LastName = StringExtensions.CleanString(author.LastName ?? ""),
            };
            var result = await connection.QueryAsync<VM_Authors>(sql, parameters, commandType: System.Data.CommandType.StoredProcedure);
            return result.ToList();
        }
    }
    /// <summary>
    /// ویرایش نویسنده
    /// </summary>
    /// <param name="author"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<VM_Authors> AuthorsUpdateAsync(VM_Authors_Update author)
    {
        using (var connection = new SqlConnection(SqlServer.ConnectionString()))
        {
            var sql = "dbo.AuthorsUpdate";
            var parameters = new
            {
                AuthorID = author.AuthorID,
                FirstName = StringExtensions.CleanString(author.FirstName ?? ""),
                LastName = StringExtensions.CleanString(author.LastName ?? ""),
            };
            var result = await connection.QuerySingleOrDefaultAsync<VM_Authors>(sql, parameters, commandType: System.Data.CommandType.StoredProcedure);
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new Exception("نویسنده یافت نشد");
            }
        }

    }
}