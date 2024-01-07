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
    public class HomeRepository:IHomeRepository
    {
        //instance from IDbcontext interface 
        private readonly IDbContext _dbContext;

        // assgin value in const. 
        public HomeRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Home> GetAllHome()
        {
            IEnumerable<Home> result = _dbContext.Connection.Query<Home>("Home_Package.GetAllHome",
            commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool CreateHome(Home home)
        {
            var p = new DynamicParameters();
            p.Add("himg", home.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("htextd", home.Textd, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("htextt", home.Textt, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("htextp", home.Textp, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("htextA", home.Text4, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("htextB", home.Text5, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("htextC", home.Text6, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("Home_Package.CreateHome", p,
                commandType: CommandType.StoredProcedure);

            return result > 0;
        }

        public bool UpdateHome(Home home)
        {
            var p = new DynamicParameters();
            p.Add("Hid", home.Homeid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("himg", home.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("htextd", home.Textd, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("htextt", home.Textt, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("htextp", home.Textp, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("htextA", home.Text4, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("htextB", home.Text5, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("htextC", home.Text6, dbType: DbType.String, direction: ParameterDirection.Input);        
            var result = _dbContext.Connection.Execute("Home_Package.UpdateHome", p,
                commandType: CommandType.StoredProcedure);

            return result > 0;
        }
        public bool DeleteHome(int id)
        {

            var p = new DynamicParameters();

            p.Add("hid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("Home_Package.DeleteHome", p,
                commandType: CommandType.StoredProcedure);
            return result > 0;
        }


        public Home GETHomeBYID(int id)
        {
            var p = new DynamicParameters();
            p.Add("HID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Home>("Home_Package.GETHomeBYID", p,
                commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault()!;
        }

    }
}
