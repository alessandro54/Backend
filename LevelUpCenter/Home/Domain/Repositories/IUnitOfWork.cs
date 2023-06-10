namespace LevelUpCenter.Home.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}