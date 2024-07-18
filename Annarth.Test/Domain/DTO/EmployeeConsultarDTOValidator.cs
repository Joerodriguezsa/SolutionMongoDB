using Annarth.Domain.DTO;
using FluentValidation;

namespace Annarth.Test.Domain.DTO
{
    public class EmployeeConsultarDTOValidator : AbstractValidator<EmployeeConsultarDTO>
    {
        public EmployeeConsultarDTOValidator()
        {
            RuleFor(x => x.CreatedOn)
                .NotEmpty().WithMessage("Campo CreatedOn es requerido");
            RuleFor(x => x.Email)
                .MaximumLength(150).WithMessage("El campo Email no puede exceder los 150 caracteres");
            RuleFor(x => x.Fax)
                .MaximumLength(150).WithMessage("El campo Fax no puede exceder los 150 caracteres");
            RuleFor(x => x.Name)
                .MaximumLength(150).WithMessage("El campo Name no puede exceder los 150 caracteres");
            RuleFor(x => x.Password)
                .MaximumLength(150).WithMessage("El campo Password no puede exceder los 150 caracteres");
            RuleFor(x => x.Telephone)
                .MaximumLength(150).WithMessage("El campo Telephone no puede exceder los 150 caracteres");
            RuleFor(x => x.Username)
                .MaximumLength(150).WithMessage("El campo Username no puede exceder los 150 caracteres");
        }
    }
}
