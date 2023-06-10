namespace LevelUpCenter.LookUrClimb.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}