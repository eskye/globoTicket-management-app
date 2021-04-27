using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GloboTicket.ManagementApp.Application.Contracts.Persistence;
using GloboTicket.ManagementApp.Domain.Entities;
using MediatR;

namespace GloboTicket.ManagementApp.Application.Features.Categories.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Category> _categoryRepository;

        public CreateCategoryCommandHandler(IMapper mapper, IAsyncRepository<Category> categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var createCategoryCommandResponse = new CreateCategoryCommandResponse();
            var validator = new CreateCategoryCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
            {
                createCategoryCommandResponse.Success = false;
                createCategoryCommandResponse.ValidationErrors = new List<string>();
                foreach (var validationResultError in validationResult.Errors)
                {
                    createCategoryCommandResponse.ValidationErrors.Add(validationResultError.ErrorMessage);
                }
            }

            if (!createCategoryCommandResponse.Success) return createCategoryCommandResponse;
            var category = new Category {Name = request.Name};
            category = await _categoryRepository.AddAsync(category);
            createCategoryCommandResponse.Category = _mapper.Map<CreateCategoryDto>(category);

            return createCategoryCommandResponse;
        }
    }
}