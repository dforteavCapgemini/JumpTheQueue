using Devon4Net.Infrastructure.FluentValidation;
using Devon4Net.WebAPI.Implementation.Domain.Entities;
using FluentValidation;


namespace Devon4Net.WebAPI.Implementation.Business.JumpTheQueue.Validators
{


    public class VisitorFluentValidator : CustomFluentValidator<Visitor>
    {
        public VisitorFluentValidator(bool launchExceptionWhenError) : base(launchExceptionWhenError)
        {
        }

        public override void CustomValidate()
        {
            RuleFor(todo => todo.Name).NotNull();
            RuleFor(todo => todo.Name).NotEmpty();
        }
    }

}
