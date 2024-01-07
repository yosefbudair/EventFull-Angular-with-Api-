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
    public class UserReviewEventRepository : IUserReviewEventRepository
    {
        private readonly IDbContext dbContext;
        public UserReviewEventRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool CreateUevent(UserREvent userREvent)
        {
            var create = new DynamicParameters();
            create.Add("eid", userREvent.Eventid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            create.Add("UID", userREvent.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("UEVENT_PACKAGE.CREATEUEVENT", create, commandType: CommandType.StoredProcedure);
            return result > 0;
        }
        public bool updateUevent(UserREvent userREvent)
        {
            var update = new DynamicParameters();
            update.Add("ueid", userREvent.Usereventid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            update.Add("eid", userREvent.Eventid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            update.Add("UID", userREvent.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("UEVENT_PACKAGE.UPDATEUEVENT", update, commandType: CommandType.StoredProcedure);
            return result > 0;
        }
        public bool DeleteUevent(int id)
        {
            var delete = new DynamicParameters();
            delete.Add("ueid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("UEVENT_PACKAGE.DELETEUEVENT", delete, commandType: CommandType.StoredProcedure);
            return result > 0;
        }
        public List<UserREvent> GetAllUevent()
        {
            IEnumerable<UserREvent> result = dbContext.Connection.Query<UserREvent>("UEVENT_PACKAGE.GETALLUEVENT", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public UserREvent getUeventById(int id)
        {
            var get = new DynamicParameters();
            get.Add("ueid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<UserREvent>("UEVENT_PACKAGE.GetUEVENTById", get, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault()!;
        }

        public List<Event> geteventsbyuser(int id)
        {
            var get = new DynamicParameters();
            get.Add("Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Event> result = dbContext.Connection.Query<Event>("GeteventsWhereUser", get , commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
