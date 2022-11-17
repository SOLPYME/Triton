namespace Triton.Sample.Application.Contracts.Persistence
{
    public interface IUnitOfWork : Core.Application.Contracts.Persistence.IUnitOfWork
    {
        IStreamerRepository StreamerRepository { get; }
        IVideoRepository VideoRepository { get; }
    }
}
