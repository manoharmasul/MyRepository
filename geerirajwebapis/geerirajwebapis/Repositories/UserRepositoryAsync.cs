using Dapper;
using geerirajwebapis.Context;
using geerirajwebapis.Repositories.Interface;
using System;
using System.Data;
using static System.Net.WebRequestMethods;

namespace geerirajwebapis.Repositories
{
    public class UserRepositoryAsync : IUserRepositoryAsync
    {
        private readonly DapperContext context;
        public UserRepositoryAsync(DapperContext context)
        {

            this.context = context;
        }
        public async Task<int> UserLogIn(string MobileNo)
        {
            var proc = "Sp_InsertOtp";
            using(var connection=context.CreateConnection())
            {
                Random random = new Random();
                int otp = random.Next(100000, 999999); // generates a 6-digit number
                var parameter = new DynamicParameters();
                parameter.Add("Otp",otp);
                parameter.Add("MobileNo",MobileNo);
                var result = await connection.QuerySingleAsync<int>(proc, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<int> ValidateMobileOtp(string Otp, string MobileNo)
        {
            var proc = "Sp_ValidateOtp";
            using(var connection=context.CreateConnection())
            {
                var parameter = new DynamicParameters();
                parameter.Add("Otp", Otp);
                parameter.Add("MobileNo", MobileNo);
                var result = await connection.QueryFirstOrDefaultAsync<int>(proc, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
