using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Mind.Domain.Models;
using Mind.Infrastructure.Session;
using Mind.Read.Interface;

namespace Mind.Read.Queries;

public class UserQuery : IUserQuery
{
    private readonly DbSession _dbSession;

    public UserQuery(DbSession dbSession)
    {
        _dbSession = dbSession;
    }
    public async Task<User> GetUserByEmail(string email)
    {
        try
        {
            StringBuilder query = new();
            query.Append("SELECT * FROM User WHERE Email = @email");

            var result = await _dbSession.Connection.QueryFirstOrDefaultAsync<User>(query.ToString(), new { email });
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        
        
    }
}