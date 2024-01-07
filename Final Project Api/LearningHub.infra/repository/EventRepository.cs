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
    public class EventRepository : IEventRepository
    {
        private readonly IDbContext _dbContext;

        public EventRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public List<Event> GetAllEvents()
        {

            IEnumerable<Event> result = _dbContext.Connection.Query<Event>("Event_Package.GetAllEvents", commandType: CommandType.StoredProcedure);

            return result.ToList();

        }

        public bool CreateEvent(Event events)
        {

            var create = new DynamicParameters();
            create.Add("EName", events.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            create.Add("Img", events.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            create.Add("SDate", events.Startdate, dbType: DbType.Date, direction: ParameterDirection.Input);
            create.Add("EDate", events.Enddate, dbType: DbType.Date, direction: ParameterDirection.Input);
            create.Add("LAT", events.Limitattend, dbType: DbType.Int32, direction: ParameterDirection.Input);
            create.Add("Accept", events.Isaccepted, dbType: DbType.Int32, direction: ParameterDirection.Input);
            create.Add("Pay", events.Ispayed, dbType: DbType.Int32, direction: ParameterDirection.Input);
            create.Add("Ph", events.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            create.Add("Ad", events.Address, dbType: DbType.String, direction: ParameterDirection.Input);
            create.Add("DES", events.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            create.Add("CATID", events.Categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            create.Add("UID", events.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = _dbContext.Connection.Execute("Event_Package.CREATEEvent", create, commandType: CommandType.StoredProcedure);

            return result > 0;
        }

        public bool UpdateEvent(Event events)
        {

            var update = new DynamicParameters();
            update.Add("EId", events.Eventid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            update.Add("EName", events.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            update.Add("Img", events.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            update.Add("SDate", events.Startdate, dbType: DbType.Date, direction: ParameterDirection.Input);
            update.Add("EDate", events.Enddate, dbType: DbType.Date, direction: ParameterDirection.Input);
            update.Add("LAT", events.Limitattend, dbType: DbType.Int32, direction: ParameterDirection.Input);
            update.Add("Accept", events.Isaccepted, dbType: DbType.Int32, direction: ParameterDirection.Input);
            update.Add("Pay", events.Ispayed, dbType: DbType.Int32, direction: ParameterDirection.Input);
            update.Add("Ph", events.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            update.Add("Ad", events.Address, dbType: DbType.String, direction: ParameterDirection.Input);
            update.Add("DES", events.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            update.Add("CATID", events.Categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            update.Add("UID", events.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("Event_Package.UPDATEEvent", update, commandType: CommandType.StoredProcedure);


            return result > 0;
        }


        public bool DeleteEvent(int id)
        {

            var delete = new DynamicParameters();
            delete.Add("EId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("Event_Package.DeleteEvent", delete, commandType: CommandType.StoredProcedure);


            return result > 0;
        }

        public Event GetEventById(int id)
        {

            var get = new DynamicParameters();
            get.Add("EId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<Event>("Event_Package.GetEventById", get, commandType: CommandType.StoredProcedure);


            return result.FirstOrDefault()!;
        }

        public List<Event> searchUserEvent(UserSearchEvents events)
        {

            var search = new DynamicParameters();
            search.Add("EName", events.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            search.Add("CatId", events.categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            search.Add("DateFrom", events.DateFrom, dbType: DbType.Date, direction: ParameterDirection.Input);
            search.Add("DateTo", events.DateTo, dbType: DbType.Date, direction: ParameterDirection.Input);
                      

            var result = _dbContext.Connection.Query<Event>("features_Package.UserSearchEvents", search, commandType: CommandType.StoredProcedure);


            return result.ToList();
        }
    }
}
