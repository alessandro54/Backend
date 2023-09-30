namespace LevelUpCenter.Coaching.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}