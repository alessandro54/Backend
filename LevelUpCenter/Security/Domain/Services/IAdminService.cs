using LevelUpCenter.Security.Domain.Models;
using LevelUpCenter.Security.Domain.Services.Communication;

namespace LevelUpCenter.Security.Domain.Services;

public interface IAdminService
{
    Task<User> RegisterAsync(AdminRegisterRequest request);
}
