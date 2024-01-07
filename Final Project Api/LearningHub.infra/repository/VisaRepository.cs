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
    public class VisaRepository : IVisaRepository
    {
        private readonly IDbContext dBContext;

        public VisaRepository(IDbContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public List<Visa> GetAllVisa()
        {

            IEnumerable<Visa> result = dBContext.Connection.Query<Visa>("Visa_Package.GetAllVisa", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }

        public Visa GetByVisaId(int id)
        {
            var p = new DynamicParameters();
            p.Add("Vid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Visa> result = dBContext.Connection.Query<Visa>("Visa_Package.GetVisaById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault()!;
        }

        public bool updateVisa(Visa visa)
        {
            var update = new DynamicParameters();
            update.Add("vid", visa.Visaid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            update.Add("cnum", visa.Cardnumber, dbType: DbType.String, direction: ParameterDirection.Input);
            update.Add("email", visa.Owneremail, dbType: DbType.String, direction: ParameterDirection.Input);
            update.Add("vc", visa.Cvv, dbType: DbType.String, direction: ParameterDirection.Input);
            update.Add("bal", visa.Balance, dbType: DbType.Double, direction: ParameterDirection.Input);
            update.Add("vdate", visa.Visadate, dbType: DbType.Date, direction: ParameterDirection.Input);
            update.Add("cname", visa.Cardname, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dBContext.Connection.Execute("Visa_Package.UpdateVisa", update, commandType: CommandType.StoredProcedure);
            return result > 0;
        }
    }
}
