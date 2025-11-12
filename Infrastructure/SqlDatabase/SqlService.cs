using Application.Abstractions.DataAccess;
using SharedKernel;

namespace Infrastructure.SqlDatabase
{

    internal sealed class SqlService : IDatabaseService , IDisposable
    {
        private List<Entity> _list = new List<Entity>();
        
        public SqlService(){}

        public void Dispose()
        {
            // TODO release managed resources here
        }

        public async Task<List<Entity>> getAsync()
        {
            await Task.Delay(1);
            return _list;
        }

        public async Task updateAsync(List<Entity> entities)
        {
            await Task.Delay(1);
            throw new NotImplementedException();
        }

        public async Task deleteAsync(List<Entity> entities)
        {
            await Task.Delay(1);
            throw new NotImplementedException();
        }

        public async Task<Guid> AddAsync(Entity entity)
        {
            await Task.Delay(1);
            throw new NotImplementedException();
        }
    }
    
}
