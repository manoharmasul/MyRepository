using Dapper;
using geerirajwebapis.Context;
using geerirajwebapis.Model;
using geerirajwebapis.Repositories.Interface;
using System.Data;

namespace geerirajwebapis.Repositories
{
    public class EnquiryMailRepository:IEnquiryMailRepository
    {
        private readonly DapperContext context;
        public EnquiryMailRepository(DapperContext context)
        {
            this.context = context;
        }

        public async Task<int> AddEnquiryMail(EnquiryMailModel model)
        {
            var Proc = "sp_InsertEnquiryMail";
            using(var connection=context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                //parameters.Add("@Id", prod.Id);
                parameters.Add("@Subject", model.Subject);
                parameters.Add("@Name", model.Name);
                parameters.Add("@Email", model.Email);
                parameters.Add("@PhoneNo", model.PhoneNo);
                parameters.Add("@Qty", model.Qty);
                parameters.Add("@CompanyName", model.CompanyName);
                parameters.Add("@CompanyType", model.CompanyType);
                parameters.Add("@Message", model.Message);

                var result = await connection.ExecuteAsync(Proc, parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public Task<int> ReadEnquiryMail(bool IsRead)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveEnquiryMail(bool IsSaved)
        {
            throw new NotImplementedException();
        }
    }
}
