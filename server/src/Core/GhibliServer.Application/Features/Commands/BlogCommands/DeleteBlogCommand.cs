using GhibliServer.Application.Interfaces.Repository;
using GhibliServer.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Features.Commands.BlogCommands
{
    public class DeleteBlogCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid BlogId { get; set; }
    }
    public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand, ServiceResponse<Guid>>
    {
        private readonly IBlogRepository _blogRepository;

        public DeleteBlogCommandHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<ServiceResponse<Guid>> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            var existingBlog = await _blogRepository.GetItemByIdAsync(request.BlogId);

            if (existingBlog == null)
            {
                return null;
            }

            await _blogRepository.DeleteAsync(request.BlogId);

            return new ServiceResponse<Guid>(request.BlogId);
        }
    }
}
