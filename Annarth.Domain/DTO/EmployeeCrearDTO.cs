using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Annarth.Domain.DTO
{
    public class EmployeeCrearDTO
    {
        [Required(ErrorMessage = "Campo CompanyId es requerido")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CompanyId { get; set; }

        [Required(ErrorMessage = "Campo CreatedOn es requerido")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DeletedOn { get; set; }

        [Required(ErrorMessage = "Campo Email es requerido")]
        public string Email { get; set; }

        public string Fax { get; set; }

        [Required(ErrorMessage = "Campo Name es requerido")]
        public string Name { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? Lastlogin { get; set; }

        [Required(ErrorMessage = "Campo Password es requerido")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Campo PortalId es requerido")]
        public int PortalId { get; set; }

        [Required(ErrorMessage = "Campo RoleId es requerido")]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "Campo StatusId es requerido")]
        public int StatusId { get; set; }

        public string Telephone { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? UpdatedOn { get; set; }

        [Required(ErrorMessage = "Campo Username es requerido")]
        public string Username { get; set; }
    }
}
