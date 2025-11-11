namespace geerirajwebapis.Repositories.Interface
{
    public interface IUserRepositoryAsync
    {
        Task<int> UserLogIn(string MobileNo);
        Task<int> ValidateMobileOtp(string Otp,string MobileNo);
    }
}
