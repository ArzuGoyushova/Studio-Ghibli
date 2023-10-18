using AutoMapper;
using GhibliServer.Application.Dtos.Category;
using GhibliServer.Application.Interfaces.Repository;
using GhibliServer.Application.Wrappers;
using GhibliServer.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Features.Commands.CategoryCommands
{
    public class CreateCategoryCommand : IRequest<ServiceResponse<Guid>>
    {
        public CategoryCreateOrUpdateDto CategoryDTO { get; set; }
    }

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, ServiceResponse<Guid>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Guid>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request.CategoryDTO);

            await _categoryRepository.CreateAsync(category);

            return new ServiceResponse<Guid>(category.Id);
        }

    }

}
