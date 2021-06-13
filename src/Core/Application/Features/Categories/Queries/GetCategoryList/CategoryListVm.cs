using System.Collections.Generic;

namespace Application.Features.Categories.Queries.GetCategoryList
{
    public class CategoryListVm
    {
        public List<CategoryDto> Categories { get; set; }
        public int Count { get; set; }
    }
}
