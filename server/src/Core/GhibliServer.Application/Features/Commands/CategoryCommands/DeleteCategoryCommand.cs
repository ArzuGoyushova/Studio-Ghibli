using GhibliServer.Application.Interfaces.Repository;
using GhibliServer.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Features.Commands.CategoryCommands
{
    public class DeleteCategoryCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid CategoryId { get; set; }
    }


    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, ServiceResponse<Guid>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ServiceResponse<Guid>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var existingCategory = await _categoryRepository.GetItemByIdAsync(request.CategoryId);

            if (existingCategory == null)
            {
                return null;
            }

            await _categoryRepository.DeleteAsync(existingCategory.Id);

            return new ServiceResponse<Guid>(existingCategory.Id);
        }
    }
}
