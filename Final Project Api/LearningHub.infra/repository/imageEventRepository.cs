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
    public class imageEventRepository:IimageEventRepository
    {
        //instance from IDbcontext interface 
        private readonly IDbContext _dbContext;

        // assgin value in const. 
        public imageEventRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ImageEvent> GetAllimageEvent()
        {

            IEnumerable<ImageEvent> result = _dbContext.Connection.Query<ImageEvent>("imageEvent_Package.GetAllimageEvent",
                commandType: CommandType.StoredProcedure);
            return result.ToList();

        }

        public bool CreateimageEvent(ImageEvent imageEvent)
        {
            var p = new DynamicParameters();

            p.Add("Eimg", imageEvent.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Eid", imageEvent.Eventid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("imageEvent_Package.CreateimageEvent", p,
                commandType: CommandType.StoredProcedure);

            return result > 0;

        }

        public bool UpdateimageEvent(ImageEvent imageEvent)
        {
            var p = new DynamicParameters();

            p.Add("iEid", imageEvent.Imageeventid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Eimg", imageEvent.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Eid", imageEvent.Eventid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("imageEvent_Package.UpdateimageEvent", p,
                commandType: CommandType.StoredProcedure);


            return result > 0;
        }


        public bool DeleteimageEvent(int id)
        {

            var p = new DynamicParameters();

            p.Add("IEid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("imageEvent_Package.DeleteimageEvent", p,
                commandType: CommandType.StoredProcedure);
            return result > 0;
        }



        public ImageEvent GETimageEventBYID(int id)
        {
            var p = new DynamicParameters();
            p.Add("IEID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<ImageEvent>("imageEvent_Package.GETimageEventBYID", p,
                commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
