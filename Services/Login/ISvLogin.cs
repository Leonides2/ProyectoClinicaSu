using Entidades;

namespace Services.Login
{
    public interface ISvLogin
    {
        Task<UserResponse> ReturnToken(UserRequest request, string secret);
    }
}
