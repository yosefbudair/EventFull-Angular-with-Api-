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
    public class ReviewRepository : IReviewRepository
    {
        private readonly IDbContext dbContext;
        public ReviewRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool CreateReview(Review review)
        {
            var p = new DynamicParameters();
            p.Add("RV", review.Reviewvalue, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("UID", review.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("REVIEW_PACKAGE.CREATEREVIEW", p, commandType: CommandType.StoredProcedure);
            return result > 0;
        }
        public bool updateReview(Review review)
        {
            var p = new DynamicParameters();
            p.Add("RVID", review.Reviewid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("RV", review.Reviewvalue, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("UID", review.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("REVIEW_PACKAGE.UPDATEREVIEW", p, commandType: CommandType.StoredProcedure);
            return result > 0;
        }
        public bool DeleteReview(int id)
        {
            var p = new DynamicParameters();
            p.Add("RVID",id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("REVIEW_PACKAGE.DELETEREVIEW", p, commandType: CommandType.StoredProcedure);
            return result > 0;
        }
        public List<Review> GetAllReview()
        {
            IEnumerable<Review> result = dbContext.Connection.Query<Review>("REVIEW_PACKAGE.GETALLREVIEW", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public Review getReviewById(int id)
        {
            var p = new DynamicParameters();
            p.Add("RVID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Review> result = dbContext.Connection.Query<Review>("REVIEW_PACKAGE.GetreviewById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault()!;
        }
    }
}
