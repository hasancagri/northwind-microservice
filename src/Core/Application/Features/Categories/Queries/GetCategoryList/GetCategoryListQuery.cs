using MediatR;

namespace Application.Features.Categories.Queries.GetCategoryList
{
    public class GetCategoryListQuery
         : IRequest<CategoryListVm>
    {
    }
}
