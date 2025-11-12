using SharedKernel;

namespace Application.Abstractions.DataAccess;

public interface IDatabaseService
{
    Task<List<Entity>> getAsync();
    Task updateAsync(List<Entity> entities);
    Task deleteAsync(List<Entity> entities);
    Task<Guid> AddAsync(Entity entity);
}