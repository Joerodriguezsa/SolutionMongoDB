﻿using System.ComponentModel.DataAnnotations;

namespace Annarth.Domain.DTO
{
    public class EmployeeCrearDTO
    {
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "Campo CreatedOn es requerido")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DeletedOn { get; set; }

        [StringLength(150)]
        public string Email { get; set; }

        [StringLength(150)]
        public string Fax { get; set; }

        [StringLength(150)]
        public string Name { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? Lastlogin { get; set; }

        [StringLength(150)]
        public string Password { get; set; }

        public int PortalId { get; set; }

        public int RoleId { get; set; }

        public int StatusId { get; set; }

        [StringLength(150)]
        public string Telephone { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? UpdatedOn { get; set; }

        [StringLength(150)]
        public string Username { get; set; }
    }
}
