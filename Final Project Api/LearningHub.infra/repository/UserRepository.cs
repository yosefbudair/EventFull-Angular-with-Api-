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
    public class UserRepository : IUserRepository
    {

        private readonly IDbContext _dbContext;

        public UserRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public List<User> GetAllUsers()
        {

            IEnumerable<User> result = _dbContext.Connection.Query<User>("Users_Package.GetAllUsers", commandType: CommandType.StoredProcedure);

            return result.ToList();

        }

        public bool CreateUser(User user)
        {

            var create = new DynamicParameters();
            create.Add("FName", user.Fullname, dbType: DbType.String, direction: ParameterDirection.Input);
            create.Add("Em", user.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            create.Add("UName", user.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            create.Add("Pass", user.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            create.Add("Ph", user.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            create.Add("Im", user.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            create.Add("Gen", user.Gender, dbType: DbType.String, direction: ParameterDirection.Input);
            create.Add("RID", user.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            


            var result = _dbContext.Connection.Execute("Users_Package.CREATEUser", create, commandType: CommandType.StoredProcedure);

            return result > 0;
        }

        public bool UpdateUser(User user)
        {

            var update = new DynamicParameters();
            update.Add("UID", user.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            update.Add("FName", user.Fullname, dbType: DbType.String, direction: ParameterDirection.Input);
            update.Add("Em", user.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            update.Add("UName", user.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            update.Add("Pass", user.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            update.Add("Ph", user.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            update.Add("Im", user.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            update.Add("Gen", user.Gender, dbType: DbType.String, direction: ParameterDirection.Input);
            update.Add("RID", user.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("Users_Package.UPDATEUser", update, commandType: CommandType.StoredProcedure);


            return result > 0;
        }


        public bool DeleteUser(int id)
        {

            var delete = new DynamicParameters();
            delete.Add("UId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("Users_Package.DeleteUser", delete, commandType: CommandType.StoredProcedure);


            return result > 0;
        }

        public User GetUserById(int id)
        {

            var get = new DynamicParameters();
            get.Add("UId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<User>("Users_Package.GetUserById", get, commandType: CommandType.StoredProcedure);


            return result.FirstOrDefault()!;
        }


    }
}
