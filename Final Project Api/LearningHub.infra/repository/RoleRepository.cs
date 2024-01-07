using Dapper;
using LearningHub.core.Common;
using LearningHub.Core.Data;
using LearningHub.Core.repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Infra.repository
{
    public class RoleRepository: IRoleRepository
    {
        //instance from IDbcontext interface 
        private readonly IDbContext _dbContext;

        // assgin value in const. 
        public RoleRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Role> GetAllRole()
        {

            IEnumerable<Role> result = _dbContext.Connection.Query<Role>("Role_Package.GetAllRole",
                commandType: CommandType.StoredProcedure);
            return result.ToList();

        }

        public Role GETroleBYID(int id)
        {
            var p = new DynamicParameters();
            p.Add("rlID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Role>("Role_Package.GETroleBYID", p,
                commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
