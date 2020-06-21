using Data.Context;

namespace Drafter.Logic.Services
{
    public abstract class BaseService
    {
        protected readonly AppDbContext Context;

        protected BaseService(AppDbContext context)
        {
            Context = context;
        }
    }
}