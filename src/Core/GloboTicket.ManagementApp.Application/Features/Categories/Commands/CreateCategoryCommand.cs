using MediatR;

namespace GloboTicket.ManagementApp.Application.Features.Categories.Commands
{
    public class CreateCategoryCommand: IRequest<CreateCategoryCommandResponse>
    {
        public string Name { get; set; }
    }
}