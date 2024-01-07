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
    public class CategoryRepository:ICategoryRepository
    {
        //instance from IDbcontext interface 
        private readonly IDbContext _dbContext;

        // assgin value in const. 
        public CategoryRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Category> GetAllCategory()
        {

            IEnumerable<Category> result = _dbContext.Connection.Query<Category>("Category_Package.GetAllCategory",
                commandType: CommandType.StoredProcedure);
            return result.ToList();

        }



        public bool CreateCategory(Category category)
        {
            var p = new DynamicParameters();

            p.Add("cname", category.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("cimg", category.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("cpric", category.Price, dbType: DbType.Double, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("Category_Package.CreateCategory", p,
                commandType: CommandType.StoredProcedure);

            return result > 0;

        }
        public bool UpdateCategory(Category category)
        {
            var p = new DynamicParameters();

            p.Add("cID", category.Categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("cname", category.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("cimg", category.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("cpric", category.Price, dbType: DbType.Double, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("Category_Package.UpdateCategory", p,
                commandType: CommandType.StoredProcedure);


            return result > 0;
        }


        public bool DeleteCategory(int id)
        {

            var p = new DynamicParameters();

            p.Add("cid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("Category_Package.DeleteCategory", p,
                commandType: CommandType.StoredProcedure);
            return result > 0;
        }



        public Category GETBYID(int id)
        {
            var p = new DynamicParameters();
            p.Add("CID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Category>("Category_Package.GETBYID", p,
                commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
