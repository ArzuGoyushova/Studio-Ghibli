using AutoMapper;
using GhibliServer.Application.Dtos.Category;
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
    public class UpdateCategoryCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid CategoryId { get; set; }
        public CategoryCreateOrUpdateDto CategoryDTO { get; set; }
    }

    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, ServiceResponse<Guid>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Guid>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var existingCategory = await _categoryRepository.GetItemByIdAsync(request.CategoryId);

            if (existingCategory == null)
            {
                return null;
            }

            _mapper.Map(request.CategoryDTO, existingCategory);

            await _categoryRepository.UpdateAsync(existingCategory.Id, existingCategory);

            return new ServiceResponse<Guid>(existingCategory.Id);
        }
    }
}
