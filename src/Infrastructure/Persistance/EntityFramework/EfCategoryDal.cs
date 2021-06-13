using Application.Contracts.Persistance;
using Domain.Entities;

namespace Persistance.EntityFramework
{
    public class EfCategoryDal
        : EfEntityRepositoryBase<Category>, ICategoryDal
    {
        public EfCategoryDal(NorthwindContext context)
            : base(context)
        {
        }
    }
}
