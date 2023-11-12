namespace LevelUpCenter.Shared.Domain.Services.Communication;

public abstract class BaseResponse<T>
{
    protected BaseResponse(string message)
    {
        Message = message;
        Success = false;
        Resource = default;
    }

    protected BaseResponse(T resource)
    {
        Resource = resource;
        Success = true;
        Message = string.Empty;
    }

    public bool Success { get; set; }
    public string Message { get; set; }
    public T Resource { get; set; }
}
