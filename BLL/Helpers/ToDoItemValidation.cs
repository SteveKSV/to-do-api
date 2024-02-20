using BLL.Dtos;
using FluentValidation;

namespace BLL.Helpers
{
    public class ToDoItemValidation : AbstractValidator<ToDoItemDto>
    {
        public ToDoItemValidation()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("The Title field is required.");
            RuleFor(x => x.Title).Length(1, 100).WithMessage("The minimum length of the Title field is 1 and the maximum length is 100");
        }
    }
}
