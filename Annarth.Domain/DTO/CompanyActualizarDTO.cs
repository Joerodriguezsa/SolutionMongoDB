using System.ComponentModel.DataAnnotations;

namespace Annarth.Domain.DTO
{
    public class CompanyActualizarDTO
    {
        [Required(ErrorMessage = "El nombre de la compañía es requerido")]
        public string CompanyName { get; set; }

        public bool State { get; set; }
    }
}
