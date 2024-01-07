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
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly IDbContext dBContext;

        public TestimonialRepository(IDbContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public List<Testimonial> GetAllTestimonial()
        {

            IEnumerable<Testimonial> result =dBContext.Connection.Query<Testimonial>("Testimonial_Package.GetAllTestimonial", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }
        public void CreateTestimonial(Testimonial testimonial)
        {
            var p = new DynamicParameters();
            p.Add("isAcceptedT", testimonial.Isaccepted, dbType: DbType.Int32, direction:ParameterDirection.Input);
            p.Add("MessageT", testimonial.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("UserIdT", testimonial.Userid, dbType:DbType.Int32, direction: ParameterDirection.Input);
            var result =dBContext.Connection.Execute("Testimonial_Package.CreateTestimonial", p, commandType: CommandType.StoredProcedure);
      }

        public void UpdateTestimonial(Testimonial testimonial)
        {
            var p = new DynamicParameters();
            p.Add("TesId", testimonial.Tid, dbType:DbType.Int32, direction: ParameterDirection.Input);
            p.Add("isAcceptedT", testimonial.Isaccepted, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("MessageT", testimonial.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("UserIdT", testimonial.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.Connection.Execute("Testimonial_Package.UpdateTestimonial", p, commandType: CommandType.StoredProcedure);
        }
        public void DeleteTestimonial(int id)
        {
            var p = new DynamicParameters();
            p.Add("TesId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result =dBContext.Connection.Execute("Testimonial_Package.DeleteTestimonial", p, commandType: CommandType.StoredProcedure);
         }
        public Testimonial GetByTestimonialId(int id)
        {
            var p = new DynamicParameters();
            p.Add("TesId", id, dbType: DbType.Int32,direction: ParameterDirection.Input);
            IEnumerable<Testimonial> result =dBContext.Connection.Query<Testimonial>("Testimonial_Package.GetTestimonialById", p, commandType:CommandType.StoredProcedure);
            return result.FirstOrDefault()!;
        }
    }
}

