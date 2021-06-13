using Domain.Entities;

namespace Application.Contracts.Persistance
{
    public interface ICategoryDal
        : IEntityRepository<Category>
    {
    }
}
