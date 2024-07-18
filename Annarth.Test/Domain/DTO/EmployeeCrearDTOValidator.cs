using Annarth.Domain.DTO;
using FluentValidation;

namespace Annarth.Test.Domain.DTO
{
    public class EmployeeCrearDTOValidator : AbstractValidator<EmployeeCrearDTO>
    {
        public EmployeeCrearDTOValidator()
        {
            RuleFor(x => x.CompanyId)
                .NotEmpty().WithMessage("Campo CompanyId es requerido");
            RuleFor(x => x.CreatedOn)
                .NotEmpty().WithMessage("Campo CreatedOn es requerido");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Campo Email es requerido");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Campo Name es requerido");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Campo Password es requerido");
            RuleFor(x => x.PortalId)
                .NotEmpty().WithMessage("Campo PortalId es requerido");
            RuleFor(x => x.RoleId)
                .NotEmpty().WithMessage("Campo RoleId es requerido");
            RuleFor(x => x.StatusId)
                .NotEmpty().WithMessage("Campo StatusId es requerido");
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Campo Username es requerido");
        }
    }
}
