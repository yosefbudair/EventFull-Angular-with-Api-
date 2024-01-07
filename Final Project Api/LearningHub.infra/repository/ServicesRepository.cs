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
    public class ServicesRepository:IServicesRepository
    {
        private readonly IDbContext _dbContext;

        // assgin value in const. 
        public ServicesRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public List<Service> GetAllServices()
        {
            IEnumerable<Service> result = _dbContext.Connection.Query<Service>("Services_Package.GetAllServices",
          commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public bool CreateServices(Service service)
        {
            var p = new DynamicParameters();
            p.Add("simg", service.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("stextp",service.Textp, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("stextt",service.Textt, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("stextd",service.Textd, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("Services_Package.CreateServices", p,
                commandType: CommandType.StoredProcedure);

            return result > 0;
        }
        public bool UpdateServices(Service service)
        {

            var p = new DynamicParameters();
            p.Add("Sid", service.Servicesid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("simg", service.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("stextp", service.Textp, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("stextt", service.Textt, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("stextd", service.Textd, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("Services_Package.UpdateServices", p,
                commandType: CommandType.StoredProcedure);

            return result > 0;
        }
        public bool DeleteServices(int id)
        {
            var p = new DynamicParameters();

            p.Add("sid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("Services_Package.DeleteServices", p,
                commandType: CommandType.StoredProcedure);
            return result > 0;
        }

   

        public Service GETServicesBYID(int id)
        {
            var p = new DynamicParameters();
            p.Add("SID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Service>("Services_Package.GETServicesBYID", p,
                commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

       
    }
}
