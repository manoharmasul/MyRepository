using Dapper;
using geerirajwebapis.Context;
using geerirajwebapis.Model;
using geerirajwebapis.Repositories.Interface;

namespace geerirajwebapis.Repositories
{
    public class CommonDropAsync : ICommanDropAsync
    {
        private readonly DapperContext context;
        public CommonDropAsync(DapperContext context)
        {
            this.context = context;
        }
        public async Task<List<ProductTypeModel>> GetProductTypeDrop()
        {
            string qauery = "select * from tblProductType";
            using(var connection=context.CreateConnection())
            {
                var result=await connection.QueryAsync<ProductTypeModel>(qauery);
                return result.ToList();
            }
        }
    }
}
