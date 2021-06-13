using Application.Contracts.Persistance;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Categories.Queries.GetCategoryList
{
    public class GetCategoryListQueryHandler
        : IRequestHandler<GetCategoryListQuery, CategoryListVm>
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IMapper _mapper;

        public GetCategoryListQueryHandler(ICategoryDal categoryDal, IMapper mapper)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
        }

        public async Task<CategoryListVm> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var categoryList = await _categoryDal.GetList();
            var list = _mapper.Map<List<CategoryDto>>(categoryList);
            return new CategoryListVm
            {
                Categories = list,
                Count = categoryList.Count
            };
        }
    }
}
