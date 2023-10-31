using AutoMapper;
using LevelUpCenter.Coaching.Domain.Repositories;
using LevelUpCenter.Security.Domain.Models;
using LevelUpCenter.Security.Domain.Repositories;
using LevelUpCenter.Security.Domain.Services;
using LevelUpCenter.Security.Domain.Services.Communication;
using LevelUpCenter.Security.Exceptions;

namespace LevelUpCenter.Security.Services;

public class AdminService : IAdminService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AdminService(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<User> RegisterAsync(AdminRegisterRequest request)
    {
        if (request.Secret != "77a384752c7fd0ae764b0629")
            throw new AppException("Invalid secret");
        if (_userRepository.ExistsByUsername(request.Username))
            throw new AppException("Username already exists");

        var user = _mapper.Map<User>(request);

        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

        user.Role = UserRole.Admin;

        try
        {
            await _userRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();
            return user;
        }
        catch (Exception e)
        {
            throw new AppException($"An error occurred while saving the amin");
        }
    }
}
