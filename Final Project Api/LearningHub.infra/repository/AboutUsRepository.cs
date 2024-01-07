using Dapper;
using LearningHub.core.Common;
using LearningHub.Core.Data;
using LearningHub.Core.repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Infra.repository
{
    public class AboutUsRepository: IAboutUsRepository
    {
        //instance from IDbcontext interface 
        private readonly IDbContext _dbContext;

        // assgin value in const. 
        public AboutUsRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Aboutu> GetAllAboutUs()
        {
            IEnumerable<Aboutu> result = _dbContext.Connection.Query<Aboutu>("AboutUs_Package.GetAllAboutUs",
             commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool CreateAboutUs(Aboutu aboutu)
        {
            var p = new DynamicParameters();
            p.Add("aimgA", aboutu.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("aimgB", aboutu.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("atextA", aboutu.Text1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("atextB", aboutu.Text2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("atextC", aboutu.Text3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("atextD", aboutu.Text4, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("AboutUs_Package.CreateAboutUs", p,
                commandType: CommandType.StoredProcedure);

            return result > 0;
        }


        public bool UpdateAboutUs(Aboutu aboutu)
        {
            var p = new DynamicParameters();

            p.Add("Aid", aboutu.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("aimgA", aboutu.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("aimgB", aboutu.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("atextA", aboutu.Text1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("atextB", aboutu.Text2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("atextC", aboutu.Text3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("atextD", aboutu.Text4, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("AboutUs_Package.UpdateAboutUs", p,
                commandType: CommandType.StoredProcedure);

            return result > 0;
        }


        public bool DeleteAboutUs(int id)
        {

            var p = new DynamicParameters();

            p.Add("Aid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("AboutUs_Package.DeleteAboutUs", p,
                commandType: CommandType.StoredProcedure);
            return result > 0;

        }

        public Aboutu GETAboutUsBYID(int id)
        {
            
            var p = new DynamicParameters();
            p.Add("AID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Aboutu>("AboutUs_Package.GETAboutUsBYID", p,
                commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }


    }
}
