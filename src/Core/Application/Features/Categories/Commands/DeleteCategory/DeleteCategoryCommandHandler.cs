using Application.Contracts.Persistance;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler
        : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly ICategoryDal _categoryDal;

        public DeleteCategoryCommandHandler(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryDal.Get(x => x.CategoryId == request.Id);
            if (category == null)
                throw new Exception($"{nameof(Category)} - {request.Id}");

            await _categoryDal.Delete(category);
            return Unit.Value;
        }
    }
}
