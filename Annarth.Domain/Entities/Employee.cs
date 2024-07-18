using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Annarth.Domain.Entities
{
    public class Employee
    {
        /// <summary>
        /// Id de la tabla
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        /// <summary>
        /// Fecha Registro Empleado
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Fecha Borrado Empleado
        /// </summary>
        public DateTime? DeletedOn { get; set; }

        /// <summary>
        /// Email del Empleado
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Fax del Empleado
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// Nombre del Empleado
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Fecha Ultimo Logueo
        /// </summary>
        public DateTime? Lastlogin { get; set; }

        /// <summary>
        /// Contraseña del Empleado
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Campo Relacionado del Portal Id
        /// </summary>
        public int PortalId { get; set; }

        /// <summary>
        /// Campo Relacionado del Role Id
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Campo Relacionado del Status Id
        /// </summary>
        public int StatusId { get; set; }

        /// <summary>
        /// Telefono del Empleado
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// Fecha de Actualizacion del Empleado
        /// </summary>
        public DateTime? UpdatedOn { get; set; }

        /// <summary>
        /// Campo UserName del Empleado
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Relación con la tabla Company (clave foránea).
        /// </summary>
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId CompanyId { get; set; }

        [BsonIgnore]
        public Company Company { get; set; }
    }
}
