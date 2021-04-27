using GloboTicket.ManagementApp.Application.Responses;

namespace GloboTicket.ManagementApp.Application.Features.Categories.Commands
{
    public class CreateCategoryCommandResponse : BaseResponse
    {
        public CreateCategoryCommandResponse():base()
        {
            
        }
        
        public CreateCategoryDto Category { get; set; }
    }
}