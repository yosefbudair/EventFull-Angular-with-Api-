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
    public class ContactUsRepository: IContactUsRepository
    {
        //instance from IDbcontext interface 
        private readonly IDbContext _dbContext;

        // assgin value in const. 
        public ContactUsRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
     
        public List<Contactu> GetAllContact()
        {

            IEnumerable<Contactu> result = _dbContext.Connection.Query<Contactu>("ContactUs_Package.GetAllContact",
                commandType: CommandType.StoredProcedure);
            return result.ToList();

        }



        public bool CreateContact(Contactu contactu)
        {
            var p = new DynamicParameters();
            p.Add("clocat", contactu.Location, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("cphNum", contactu.Phonenumber, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ctextA", contactu.Text1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ctextB", contactu.Text2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("cEmail", contactu.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("cMass", contactu.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("ContactUs_Package.CreateContact", p,
                commandType: CommandType.StoredProcedure);

            return result > 0;

        }
        public bool UpdateContact(Contactu contactu)
        {
            var p = new DynamicParameters();

            p.Add("Cid", contactu.Contactusid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("clocat", contactu.Location, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("cphNum", contactu.Phonenumber, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ctextA", contactu.Text1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ctextB", contactu.Text2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("cEmail", contactu.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("cMass", contactu.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("ContactUs_Package.UpdateContact", p,
                commandType: CommandType.StoredProcedure);


            return result > 0;
        }


        public bool DeleteContact(int id)
        {

            var p = new DynamicParameters();

            p.Add("cid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("ContactUs_Package.DeleteContact", p,
                commandType: CommandType.StoredProcedure);
            return result > 0;
        }



        public Contactu GETContactBYID(int id)
        {
            var p = new DynamicParameters();
            p.Add("CID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Contactu>("ContactUs_Package.GETContactBYID", p,
                commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
