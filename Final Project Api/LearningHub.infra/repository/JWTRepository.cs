using Dapper;
using LearningHub.core.Common;
using LearningHub.Core.Data;
using LearningHub.Core.DTO;
using LearningHub.Core.repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Infra.repository
{
    public class JWTRepository : IJWTRepository
    {
        private readonly IDbContext _dbContext;

        public JWTRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User UserLogin(User login)
        {
            var p = new DynamicParameters();
            
            if( login.Email != null  && (login.Email.Contains(".com") && login.Email.Contains("@"))) 
            p.Add("em", login.Email, dbType: DbType.String, direction: ParameterDirection.Input); 
            else
            p.Add("User_NAME", login.Username, dbType: DbType.String, direction: ParameterDirection.Input);

            p.Add("PASS", login.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<User> result = _dbContext.Connection.Query<User>("Users_Package.User_Login", 
                p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault()!;
        }

    }
}
